using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour
{
    [SerializeField]Vector2 boxSize;
    [SerializeField]LayerMask chargeableLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] list = Physics2D.OverlapBoxAll(gameObject.transform.position, boxSize, 0, chargeableLayerMask);
        foreach (Collider2D chargable in list)
        {
            print("is not empty");
            chargable.GetComponent<energy>().isCharging = true;
        }
    }
}
