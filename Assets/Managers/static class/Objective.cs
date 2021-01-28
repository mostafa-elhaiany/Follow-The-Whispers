using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objective
{

    public string title;
    public string description;
    public bool isActive;
    public Transform target;
    private bool isCompleted = false;
    public GameObject[] tobeActive;

    public void setAsComplete()
    {
        isCompleted = true;
    }
    public bool isComplete()
    {
        return isCompleted;
    }
}