using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy : MonoBehaviour
{
    public bool isCharging;

    public int charge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isCharging &charge <100)
        {
            //StartCoroutine(ChargeMe());
            charge += Mathf.CeilToInt(5f* Time.deltaTime);
        }

    }

    public IEnumerator ChargeMe()
    {
        charge = charge + 10;
      
        isCharging = false;
        print("charging");
        yield return new WaitForSeconds(1f);
    }
}
