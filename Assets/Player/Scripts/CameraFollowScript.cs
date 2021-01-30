using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform cameraLookCube;
    public Transform player;
    public float rotateSpeed;

    void LateUpdate()
    {
        float xRotation = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float yRotation = -Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
        if (!Input.GetKey(KeyCode.LeftAlt))
        {
            cameraLookCube.transform.rotation = player.transform.rotation;
            player.transform.Rotate(0, xRotation, 0);
            this.transform.Rotate(yRotation, 0, 0);

            Quaternion rot = this.transform.rotation;
            //float eulerX = Mathf.Clamp(rot.eulerAngles.x, -2, 35);
            float min = -4;
            float max = 30;
            float value = rot.eulerAngles.x;
            if (value > 300)
                value -= 359;
            float eulerX = value;
            
            if (value < min)
                eulerX = min;
            else if (value > max)
                eulerX = max;


            //rot = Quaternion.Euler(eulerX, transform.localEulerAngles.y, transform.localEulerAngles.z);
            rot = Quaternion.Euler(eulerX,3.2f, 0);
            transform.localRotation = rot;
            
        }
        else
        {
            cameraLookCube.transform.Rotate(yRotation, xRotation, 0);
        }

    }
}
