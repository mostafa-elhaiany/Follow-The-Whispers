using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        //if(other.CompareTag("Ghost"))
        //{

        //}
        //else if (other.CompareTag("Nanny"))
        //{

        //}
    }
}
