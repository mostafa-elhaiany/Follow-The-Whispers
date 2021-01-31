using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScript : MonoBehaviour
{
    GameManager gameManager;
    AudioManager audioManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void collect()
    {
        //ToDo write collect script here;
    }
}
