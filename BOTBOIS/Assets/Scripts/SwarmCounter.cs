using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwarmCounter : MonoBehaviour
{
    List<GameObject> bots = new List<GameObject>();

    public Text counterUI;
    public int counter = 0;
 
    private GameObject currentFollow;
    public SmoothCamera2D cameraFollow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //counter = bots.Count;
//        Debug.Log(counter);
        //bots.Clear();
    }

    private void Update()
    {
        float highX = -999999;
        for (int i = 0; i < bots.Count; i++)
        {
            if (bots[i].transform.position.x > highX)
            {
                currentFollow = bots[i];
                highX = currentFollow.transform.position.x;
                cameraFollow.target = currentFollow.transform;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "bot" && !bots.Contains(collision.gameObject))
        {
            bots.Add(collision.gameObject);
            counter++;
        }
        updateUI();
    }

    private void updateUI() {
        counterUI.text = counter.ToString();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bot" && bots.Contains(collision.gameObject))
        {
            bots.Remove(collision.gameObject);
            counter--;
        }
        updateUI();
    }
}
