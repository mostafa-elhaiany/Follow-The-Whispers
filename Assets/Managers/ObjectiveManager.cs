using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public Objective[] doors;
    static float dist;
    Transform player;
    GameObject[] keys;

    AudioManager audioManager;
    GameManager gameManager;

    public float minSound = -80;
    public float maxSound = 0;
    bool songPlayed = false;
    bool ready = false;
    static bool functionCalled=false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    IEnumerator setKeys()
    {
        yield return new WaitForSeconds(1f);
        keys = GameObject.FindGameObjectsWithTag("ActiveKey");
        ready = true;
    }
    void Update()
    {
        if (!ready)
        {
            if(!functionCalled)
            {
                StartCoroutine("setKeys");
                functionCalled = true;
            }
            return;
        }

        float minDist = 5000;
        string kname = "";
        foreach(GameObject key in keys)
        {
            if (key == null)
                continue;
            dist = Vector3.Distance(player.position, key.transform.position);
            if (dist <= minDist)
            {
                kname = key.transform.name;  
                minDist = dist;
            }
        }
        float maxDistane = 18;
        
        if (minDist <= maxDistane)
        {
            float percentage = ((1 - (minDist / maxDistane)) * 100) - 80;
            percentage = Mathf.Clamp(percentage, minSound, maxSound);
            audioManager.setWhisperSound(percentage);
            if (!songPlayed)
            {
                audioManager.play("whispers");
                songPlayed = true;
            }
        }
        else
        {
            if (songPlayed)
            {
                audioManager.stop("whispers");
                songPlayed = false;
            }
        }
    }
    public void keyFound(string keyname)
    {
        keys = GameObject.FindGameObjectsWithTag("ActiveKey");
        if (doors == null)
            return;
        GameObject DoorObject;
        foreach (Objective door in doors)
        {
            if(keyname.Contains(door.requiredKey))
            {
                //ToDo make the door interactable here
                Debug.Log(keyname);
                DoorObject = door.door;
                DoorObject.GetComponent<MoveObjectController>().setKey(true);
                door.keyFound = true;
            }
        }
        if (songPlayed)
        {
            audioManager.stop("whispers");
            songPlayed = false;
        }
    }

    public void closeDoors()
    {
        GameObject DoorObject;
        foreach (Objective door in doors)
        {
            DoorObject = door.door;
            DoorObject.GetComponent<MoveObjectController>().CloseDoor();
        }
    }


}
