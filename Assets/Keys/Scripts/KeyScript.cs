using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    Transform player;
    AudioManager audioManager;
    GameManager gameManager;
    ObjectiveManager objectiveManager;
    public float maxDistane=10;
    public float dist;
    bool songPlayed = false;


    public float minSound = -80;
    public float maxSound = 0;

    // Start is called before the first frame update
    void Start()
    {
        maxDistane = 30;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
        objectiveManager = FindObjectOfType<ObjectiveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float minDist = 5000;
        if(transform.gameObject.CompareTag("ActiveKey"))
        {
            dist = Vector3.Distance(player.position, transform.position);
            if (dist < minDist)
                minDist = dist;
        }
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

    void OnDestroy()
    {
        //Debug.Log(transform.name + "  destroyed!");
        objectiveManager.keyFound(transform.name);
        gameManager.keyCollected(transform);
    }
}
