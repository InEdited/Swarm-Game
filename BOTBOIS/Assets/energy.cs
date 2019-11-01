using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy : MonoBehaviour
{
    int charge;
    bool isInCharger;

    CircleCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Charge()
    {
        charge = charge + 10;
        yield return new WaitForSeconds(.1f);
        
    }
}
