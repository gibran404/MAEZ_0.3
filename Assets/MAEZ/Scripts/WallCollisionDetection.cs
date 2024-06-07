using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionDetection : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the other GameObject has the tag "Structure"
        if (other.gameObject.tag == "Structure" && other.gameObject != gameObject.transform.parent.gameObject)
        {
            // If it does, delete this GameObject's parent
            Debug.Log("Wall Destroyed 1");
            Destroy(transform.parent.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        // Check if the other GameObject has the tag "Structure"
        if (other.gameObject.tag == "Structure" && other.gameObject != gameObject.transform.parent.gameObject)
        {
            // If it does, delete this GameObject's parent
            Debug.Log("Wall Destroyed 2");
            Destroy(transform.parent.gameObject);
        }
    }
}
