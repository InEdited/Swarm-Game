using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spider;
    public bool assmebling = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            IntoTheSpiderverse();
        }
        
    }

    void IntoTheSpiderverse() {
        int childCount = transform.childCount;
        Vector3 centerOfGravity = transform.GetChild(Random.Range(0, childCount)).position;
        foreach (Transform child in transform) {
            Rigidbody2D rigidbody = child.GetComponent<Rigidbody2D>();
            rigidbody.gravityScale = 0;
            rigidbody.velocity = centerOfGravity - child.position;
            rigidbody.drag = 1;//Mathf.Sqrt(rigidbody.velocity.magnitude);
            
            child.GetComponent<Collider2D>().isTrigger = true;
        }

        CircleCollider2D center = GetComponent<CircleCollider2D>();
        center.enabled = true;
        center.offset = centerOfGravity - transform.position;
        center.radius = 1;


    }

    void OnColliderEnter() {
        bool init = true;
        int in_coll = 0;
        foreach (Transform child in transform) {
            Vector3 offset = GetComponent<CircleCollider2D>().offset;
            if((child.position - (transform.position + offset)).magnitude > (1 + child.GetComponent<CircleCollider2D>().radius)) {
               init = false; 
            }
            in_coll++;
        }
        Debug.Log("In" + in_coll);

        if(init) {
            InitiateSomething();
        }
    }

    void InitiateSomething() {
        Debug.Log("Avengers Assemble");

    }
}
