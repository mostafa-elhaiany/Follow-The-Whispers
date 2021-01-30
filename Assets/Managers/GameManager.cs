using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPaused;

    public static float mainSound;
    public static float effectsSound;
    public static float speechSound;
    public static float whisperSound;

    public static bool mute;


    ///GAME ATTRIBUTES
    float batteryPower=0.4f;
    int livesLeft;
    int keysCollected;
    int activeKeysCollected;

    //void Start()
    //{

    //}
    public float getBatteryPower()
    {
        return batteryPower;
    }
    public void depletePower(float val)
    {
        batteryPower -= val;
    }


    public void refilBatteries()
    {
        batteryPower = 1;
    }


    public void keyCollected(Transform key)
    {
        keysCollected++;
        if (key.CompareTag("ActiveKey"))
            activeKeysCollected++;
    }


    void Update()
    {
        handleCursur();
        handlePause();
    }

    void handlePause()
    {
        Time.timeScale = isPaused ? 0 : 1;
    }

    void handleCursur()
    {
        Cursor.visible = isPaused;
        Cursor.lockState = isPaused ? CursorLockMode.None: CursorLockMode.Locked;
    }

    public void playerCaught()
    {
        
        if(--livesLeft<=0)
        {
            //GAME OVER LOGIC HERE
        }
        //TODO restart scene here

    }
}
