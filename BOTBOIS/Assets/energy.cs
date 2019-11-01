using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy : MonoBehaviour
{
    public bool isCharging;

    int charge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator ChargeMe()
    {
        charge = charge + 10;
        yield return new WaitForSeconds(5);
        isCharging = false;
        print("charging");
    }
}
