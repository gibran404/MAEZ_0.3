using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WallCollision : MonoBehaviour
{
    // private Collider coll;

    // Start is called before the first frame update
    void Start()
    {
        // coll = GetComponent<Collider>();
        // Debug.Log("Collider collected");

        // Collider[] colliders = Physics.OverlapSphere(transform.position, .01f);

        // foreach (Collider collider in colliders)
        // {
        //     Debug.Log("in loop");
        //     if(collider.tag == "Structure")
        //     {
        //         Destroy(gameObject);
        //         Debug.Log("Wall Destroyed 3");

        //         return;
        //     }
        // }

        // GetComponent<Collider>().enabled = true;

    }

    // void OnTriggerStay(Collider other)
    // {
    //     Debug.Log("triggerer by: "+other.tag);
    //     if(other.gameObject.tag == "Structure")
    //     {
    //         Debug.Log("Wall Destroyed 2");
    //         Destroy(gameObject);
    //     }
    // }
}