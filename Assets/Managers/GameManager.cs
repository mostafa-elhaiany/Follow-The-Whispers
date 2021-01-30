using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static bool isPaused;

    public static float mainSound;
    public static float effectsSound;
    public static float speechSound;
    public static float whisperSound;

    public static bool mute;

    bool restarted = false;


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
        livesLeft = 3;
        GameObject.FindGameObjectWithTag("StrikesTag").transform.GetComponent<Text>().text = "Strikes Left: " + livesLeft;

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

        GameObject.FindGameObjectWithTag("GameInfo").transform.GetComponent<inGameScript>().keyName = key.name;

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
        if(!restarted)
        {
            restarted = true;
            Debug.Log("player is caught");
            player.GetComponent<PlayerBehaviour>().jumpScare();
            if(--livesLeft<=0)
            {
                SceneManager.LoadScene("GameOver");
            }
            GameObject.FindGameObjectWithTag("StrikesTag").transform.GetComponent<Text>().text = "Strikes Left: " + livesLeft;
            StartCoroutine("restartScene");
        }
        

    }
    IEnumerator restartScene()
    {
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        //add fade out anim
        yield return new WaitForSeconds(1);
        player.transform.position = room.position;
        sister.transform.position = girlLockedPosition.position;
        foreach (GameObject ghost in ghosts)
        {
            ghost.GetComponent<EnemyLogic>().ghostForcedPatrolling();
        }
        GameObject.FindGameObjectWithTag("Nanny").GetComponent<EnemyLogic>().ghostForcedPatrolling();
        GameObject.FindGameObjectWithTag("Nanny").GetComponent<EnemyLogic>().restart();

        yield return new WaitForSeconds(1);
        player.GetComponent<PlayerBehaviour>().restarted();
        FindObjectOfType<ObjectiveManager>().closeDoors();
        restarted = false;
        //close doors 
        //add fade in anim

    }
}
