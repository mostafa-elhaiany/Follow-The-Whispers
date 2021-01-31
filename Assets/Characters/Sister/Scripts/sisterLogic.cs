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
            timer = 15;
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


        GameObject[] playerGameObject = GameObject.FindGameObjectsWithTag("Player");
        player = playerGameObject[0];

        GameObject[] nannyArray = GameObject.FindGameObjectsWithTag("Nanny");
        //there is only one nanny, access first index only
        nanny = nannyArray[0];

        if(!isRescued && cuffs.activeSelf==false){
            //once ur not rescued, the equality prevents unnecessary assignments at each time frame
            //Debug.Log("GOT CAUGHT SIS");
             //brother got caught by nanny, reactivate cuffs
             cuffs.SetActive(true);
             //move back to old location
             transform.position = initialTransform;
             //disable navmesh
             sister.enabled=false;
            
            
        }

        // if(!isRescued){
        //     //keep checking check if player is close using distance from me to player
        //     float distance = Vector3.Distance(transform.position, player.transform.position);
        //     if(distance<= minDistanceToBeRescued){
        //         Debug.Log("yay");
        //         if(Input.GetKeyDown(KeyCode.E)){ //player interacted with sister
        //             isRescued=true;
        //         }
        //     }
        // }

        if(isRescued){
            //remove cuffs
            cuffs.SetActive(false);
            //start following brother after getting up
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

            //animator stuff that can only take place if the sister is rescued eg walking.
            sisterAnim.SetBool("brotherRunning", wasRunning && !agentIdle);
            sisterAnim.SetBool("brotherWalking", wasWalking && !agentIdle); 
            sisterAnim.SetBool("brotherScared", player.GetComponent<PlayerBehaviour>().scared); 
            sisterAnim.SetBool("brotherIdle",agentIdle); 
            //change the speed of navmesh according to whether the player is running or not
            if(wasRunning){
                sister.speed=4.1f;
            }
            if(wasWalking){
                sister.speed=3.5f;
            }

        }
        
         
         sisterAnim.SetBool("isRescued", isRescued); 
        
    }
    //  private void OnTriggerEnter(Collider other) {
        
    //      //check if player saved me (not already rescued)
    //      if(other.CompareTag("Player") && !isRescued){
    //          //player collided
    //          Debug.Log("rscued");
    //          isRescued=true;
    //      }
        
    // }
}
