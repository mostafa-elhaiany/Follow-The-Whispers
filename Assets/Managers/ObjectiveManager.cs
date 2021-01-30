using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    Objective[] doors;
    public void keyFound(string keyname)
    {
        if (doors == null)
            return;
        GameObject DoorObject;
        foreach (Objective door in doors)
        {
            if(keyname.Contains(door.requiredKey))
            {
                //ToDo make the door interactable here
                DoorObject = door.door;
                DoorObject.GetComponent<MoveObjectController>().setKey(true);
                door.keyFound = true;
            }
        }

    }
    
}
