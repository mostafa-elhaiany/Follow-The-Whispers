using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ghost"))
        {
            //TODO call function to partol
        }
        else if (other.CompareTag("Nanny"))
        {
            //Physics.IgnoreCollision(other, this.GetComponent<cap>);
        }
    }
}
