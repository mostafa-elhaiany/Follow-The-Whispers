﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooking : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo,50))
        {
            //Debug.Log(hitInfo.transform.name);
        }
    }
}
