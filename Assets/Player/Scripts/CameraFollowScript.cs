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
            float eulerX = Mathf.Clamp(rot.eulerAngles.x, 5, 30);
            rot = Quaternion.Euler(eulerX, transform.localEulerAngles.y, transform.localEulerAngles.z);
            transform.localRotation = rot;
            
        }
        else
        {
            cameraLookCube.transform.Rotate(yRotation, xRotation, 0);
        }

    }
}
