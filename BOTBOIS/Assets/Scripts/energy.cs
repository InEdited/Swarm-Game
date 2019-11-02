using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public bool isCharging;

    public int charge;

    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isCharging &charge <100)
        {
            StopCoroutine(Discharge());
            StartCoroutine(Charge());
        }
        else
        {
            StopCoroutine(Charge());
            StartCoroutine(Discharge());
        }

        if (charge > 75)
        {
            this.GetComponent<CharacterController2D>().isActivated = true;
            this.GetComponent<SpriteRenderer>().sprite = sprites[0];
            Debug.Log("More than 75");
        }
        else if(charge>50 && charge <= 75)
        {
            this.GetComponent<CharacterController2D>().isActivated = true;
            this.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else if (charge <= 50&&charge>0)
        {
            this.GetComponent<CharacterController2D>().isActivated = true;
            this.GetComponent<SpriteRenderer>().sprite = sprites[2];

        }
        else if (charge <= 0)
        {
            this.GetComponent<CharacterController2D>().isActivated = false;
        }

    }

    private IEnumerator Discharge()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            charge -= Mathf.FloorToInt(1f*Time.deltaTime);
        }
    }

    private IEnumerator Charge()
    {

        while (true)
        {
            yield return new WaitForSeconds(1);
            charge++;
        }
    }

}
