using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ghost"))
        {
            other.GetComponent<EnemyLogic>().ghostForcedPatrolling();
        }
        else if (other.CompareTag("Nanny"))
        {
            //Physics.IgnoreCollision(other, this.GetComponent<cap>);
        }
    }
}
