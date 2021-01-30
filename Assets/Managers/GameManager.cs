using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isPaused;

    public static float mainSound;
    public static float effectsSound;
    public static float speechSound;
    public static float whisperSound;

    public static bool mute;



    ///GAME ATTRIBUTES

    public Transform room;
    Transform player;

    public Transform girlLockedPosition;
    Transform sister;

    float batteryPower=0.4f;
    int livesLeft;
    int keysCollected;
    int activeKeysCollected;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sister = GameObject.FindGameObjectWithTag("Sister").transform;
    }


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

        //ToDo call UI function

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
        Debug.Log("player is caught");
        player.GetComponent<PlayerBehaviour>().jumpScare();
        if(--livesLeft<=0)
        {
            //SceneManager.LoadScene("");
            StartCoroutine("restartScene");
        }
        StartCoroutine("restartScene");
        

    }
    IEnumerator restartScene()
    {
        //add fade out anim
        yield return new WaitForSeconds(1);
        player.transform.position = room.position;
        sister.transform.position = girlLockedPosition.position;
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<PlayerBehaviour>().restarted();
        FindObjectOfType<ObjectiveManager>().closeDoors();
        //close doors 
        //add fade in anim

    }
}
