using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    Transform player;
    GameManager gameManager;
    ObjectiveManager objectiveManager;





    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = FindObjectOfType<GameManager>();
        objectiveManager = FindObjectOfType<ObjectiveManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    void OnDestroy()
    {
        //Debug.Log(transform.name + "  destroyed!");
        objectiveManager.keyFound(transform.name);
        gameManager.keyCollected(transform);
    }
}
