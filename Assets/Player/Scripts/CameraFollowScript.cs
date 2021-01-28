using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform cameraLookCube;
    public Transform player;
    public float rotateSpeed;

    private void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        //transform.Rotate(-1 * Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime, 0, 0);
        float xRotation = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float yRotation = -Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
        if (!Input.GetKey(KeyCode.LeftAlt))
        {
            cameraLookCube.transform.rotation = player.transform.rotation;
            player.transform.Rotate(0, xRotation, 0);
            this.transform.Rotate(yRotation, 0, 0);

            //this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            cameraLookCube.transform.Rotate(yRotation, xRotation, 0);
            //this.transform.Rotate(yRotation, 0, 0);
        }

    }
}
