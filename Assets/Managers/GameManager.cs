using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPaused;

    public static float mainSound;
    public static float effectsSound;
    public static float speechSound;

    public static bool mute;

    //void Start()
    //{

    //}

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
        //TODO restart scene here
    }
}
