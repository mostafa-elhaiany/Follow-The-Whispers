using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    Objective[] doors;

    public void keyFound(string keyname)
    {
        foreach(Objective door in doors)
        {
            if(keyname.Contains(door.requiredKey))
            {
                //ToDo make the door interactable here
            }
        }
    }
    
}
