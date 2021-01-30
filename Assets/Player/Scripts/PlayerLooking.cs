using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLooking : MonoBehaviour
{
    public Camera cam;
    public Text text;
    GameManager manager;

    private void Start()
    {
        text = GameObject.FindGameObjectWithTag("KeyText").GetComponent<Text>();
        manager = FindObjectOfType<GameManager>();
    }

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
            else if(hitInfo.transform.CompareTag("Battery"))
            {
                text.text = "Press  E  to  collect  Batteries";
                if (Input.GetKeyDown(KeyCode.E))
                    collectBattery(hitInfo.transform);
            }
        }

    }

    void collectBattery(Transform battery)
    {
        //Destroy(battery.gameObject,1);
        manager.refilBatteries();
    }

    void pickupKey(Transform key)
    {
        manager.keyCollected(key);
        FindObjectOfType<ObjectiveManager>().keyFound(key.name);
        manager.keyCollected(key);
        Destroy(key.gameObject);
    }
}
