using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objective
{

    public string ID;
    public GameObject target;
    public bool isDoor;
    public string requiredKey;
    private bool keyFound = false;
    
   
}