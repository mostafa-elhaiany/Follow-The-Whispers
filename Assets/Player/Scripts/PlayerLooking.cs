using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLooking : MonoBehaviour
{
    public Camera cam;
    public Text text;

    
    void Update()
    {
        text.text = "";
        RaycastHit hitInfo;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo,5))
        {
            if(hitInfo.transform.CompareTag("Key") || hitInfo.transform.CompareTag("ActiveKey"))
            {
                text.text = "Press  E  to  Carry  Key";
                if(Input.GetKeyDown(KeyCode.E))
                    pickupKey(hitInfo.transform);
            }
        }

    }

    void pickupKey(Transform key)
    {
        Destroy(key.gameObject);
        if (key.CompareTag("ActiveKey"))
        {
            FindObjectOfType<AudioManager>().stop("whispers");
        }
    }
}
