using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sisterLogic : MonoBehaviour
{
    public bool isRescued;
    public GameObject cuffs;
    GameObject player;
    GameObject nanny;
    bool agentIdle;
    Vector3 initialTransform;
    private UnityEngine.AI.NavMeshAgent sister;
    Animator sisterAnim;
    public float minDistanceToBeRescued;
    //used tp stpre the last movements done by the player. Used to avoid the agent sliding across the floor
    bool wasRunning;
    bool wasWalking;

    float timer = 15;
    float timeApart = 20;
    bool startCountDown = false;
    
    // Start is called before the first frame update
    void Start()
    {
        sister = GetComponent<UnityEngine.AI.NavMeshAgent>();
        initialTransform = transform.position;
        sisterAnim = GetComponent<Animator>();
        
    }
public void Rescued(){
    isRescued=true;
}
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            timer = 10;
            if(!isRescued)
            {
                int rand = Random.Range(0, 3);
                AudioManager aManager = FindObjectOfType<AudioManager>();
                switch(rand)
                {
                    case 0:
                        aManager.play("girl1");
                        break;
                    case 1:
                        aManager.play("girl2");
                        break;
                    case 2:
                        aManager.play("girl3");
                        break;
                    case 3:
                        aManager.play("girl4");
                        break;
                }
            }

        }

        if(!isRescued && startCountDown)
        {
            timeApart -= Time.deltaTime;
            if(timeApart==0)
            {
                FindObjectOfType<GameManager>().playerCaught();
                startCountDown = false;
                timeApart = 20;
            }
        }


        player = GameObject.FindGameObjectWithTag("Player");

        if (!isRescued && cuffs.activeSelf==false){
             transform.position = initialTransform;
             cuffs.SetActive(true);
             sister.enabled=false;
        }

        if(isRescued){
            cuffs.SetActive(false);
            sister.enabled = true;
            sister.SetDestination(player.transform.position);
            if(player.GetComponent<Animator>().GetBool("moving")){
                wasWalking = true;
                wasRunning = false;
            }
            
            if(player.GetComponent<PlayerBehaviour>().isRunning && Input.GetAxis("Vertical")>0){
                wasRunning = true;
                wasWalking = false;
            }
            
            
            agentIdle = Vector3.Distance (sister.transform.position, player.transform.position) <= sister.stoppingDistance;

            sisterAnim.SetBool("brotherRunning", wasRunning && !agentIdle);
            sisterAnim.SetBool("brotherWalking", wasWalking && !agentIdle); 
            sisterAnim.SetBool("brotherScared", player.GetComponent<PlayerBehaviour>().scared); 
            sisterAnim.SetBool("brotherIdle",agentIdle); 
            if(wasRunning){
                sister.speed=4.1f;
            }
            if(wasWalking){
                sister.speed=3.5f;
            }

            float dist = Vector3.Distance(sister.transform.position, player.transform.position);
            if (dist>=10)
            {
                isRescued = false;
                cuffs.SetActive(true);
                sister.enabled = false;
                startCountDown = true;
                AudioManager aManager = FindObjectOfType<AudioManager>();
                aManager.play("girl1");
            }
            else
            {
                startCountDown = false;
                timeApart = 20;
            }
        }
        
         
         sisterAnim.SetBool("isRescued", isRescued); 
        
    }
}
