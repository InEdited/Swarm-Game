using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spider;
    public bool assembling = false;
    public Vector3 centerPosition;

    public float explosionForce = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            IntoTheSpiderverse();
        }
        if (assembling) {
            bool init = true;
            foreach (Transform child in transform) {
                if ((centerPosition - child.position).magnitude > 1.5) {
                        init = false;
                }
            }


            if (init) {
                InitiateSomething();

                assembling = false;
            }

        }
        
    }

    void IntoTheSpiderverse() {
        int childCount = transform.childCount;
        Vector3 centerOfGravity = transform.GetChild(Random.Range(0, childCount)).position;
        foreach (Transform child in transform) {
            Rigidbody2D rigidbody = child.GetComponent<Rigidbody2D>();
            rigidbody.gravityScale = 0;
            rigidbody.velocity = centerOfGravity - child.position;
            rigidbody.drag = 1;
            
            child.GetComponent<Collider2D>().enabled = false;
            //child.GetComponent<Collider2D>().isTrigger = true;
        }
        centerPosition = centerOfGravity;
        assembling = true;
    }

    void InitiateSomething() {
        foreach (Transform child in transform) {
            Rigidbody2D rb = child.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(0.25f*explosionForce, 0.25f*explosionForce);
        }

        Instantiate(spider, centerPosition, Quaternion.Euler(0f, 0f, 0f));
    }
}
