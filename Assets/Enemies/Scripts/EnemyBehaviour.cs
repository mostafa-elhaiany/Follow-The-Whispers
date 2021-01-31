using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    GameObject player;
    GameManager manager;
    NavMeshAgent agent;
    public GameObject[] patrolPoints;
    Vector3 restartPos;
    int patrolIndx;
    bool patrollingStarted = false;

    public float radius;
    public float fieldOfViewAngle;
    float playerSeenTime;
    Vector3 lastPlayerPos;
    enum State
    {
        Waiting,
        Patroling,
        Catching
    }
    State state;


    void Start()
    {
        patrolIndx = 0;
        state = State.Patroling;
        restartPos = this.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        switch (state)
        {
            case State.Waiting:
                break;
            case State.Patroling:
                handlePatrol();
                break;
            case State.Catching:
                handleCatchingPlayer();
                break;
        }
    }

    void handlePatrol()
    {
        patrolIndx = patrolIndx % patrolPoints.Length;
        //Debug.Log(patrolIndx);
        if(!patrollingStarted)
        {
            agent.SetDestination(patrolPoints[patrolIndx].transform.position);
            patrollingStarted = true;
        }
        else
        {
            Vector3 enemyPos = transform.position;
            Vector3 patrolPos = patrolPoints[patrolIndx].transform.position;
            float dist = Vector3.Distance(enemyPos, patrolPos);
            if(dist<=agent.stoppingDistance) // destination reached
            {
                patrollingStarted = false;
                patrolIndx++;
            }
        }

        handlePlayerInSight();
    }

    void handlePlayerInSight()
    {
        bool playerSeen=false;
        Vector3 direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < radius)
        {
            if (angle < fieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + (Vector3.up*2), direction.normalized, out hit, radius))
                {
                    if (hit.transform.tag == "Player")
                    {
                        playerSeenTime = Time.time;
                        state = State.Catching;
                        playerSeen = true;
                    }
                    else if (hit.transform.tag == "Door")
                    {
                        //hit.transform.gameObject.GetComponent<MoveObjectController>().OpenDoor();
                        StartCoroutine("closeDoor",hit.transform.gameObject);
                    }
                }
            }
        }
        if(!playerSeen && state == State.Catching)
        {
            if (Mathf.Abs(Time.time - playerSeenTime) > 20)
            {
                state = State.Patroling;
                patrollingStarted = false;
            }
        }
    }

    void handleCatchingPlayer()
    {

        Vector3 enemyPos = transform.position;
        Vector3 playerPos = player.transform.position;
        float dist = Vector3.Distance(enemyPos, playerPos);

        if (!player.transform.GetComponent<PlayerBehaviour>().isCrouched || dist<=(radius*0.25))
        {
            agent.SetDestination(player.transform.position);
            lastPlayerPos = player.transform.position;
        }

        if (dist <= agent.stoppingDistance) // player caught
        {
            manager.playerCaught();
            restartEnemy();
        }


        handlePlayerInSight();
    }

    public void ghostForcedPatrolling()
    {
        this.state = State.Patroling;
        patrollingStarted = false;
    }

    public void restartEnemy()
    {
        this.transform.position = restartPos;
        agent.SetDestination(restartPos);
        this.state = State.Waiting;
        StartCoroutine("patrol");

    }
    IEnumerator patrol()
    {
        yield return new WaitForSeconds(2);
        state = State.Patroling;
        patrollingStarted = false;
    }
    IEnumerator closeDoor(GameObject door)
    {
        yield return new WaitForSeconds(2);
        door.GetComponent<MoveObjectController>().CloseDoor();
    }
}
