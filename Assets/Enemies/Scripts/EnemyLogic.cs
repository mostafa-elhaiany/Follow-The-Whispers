using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{

Transform playerTransform;
public float fieldOfViewAngle;
//public Vector3 lastSighting; 
public Transform room;
public Transform[] PatrolPoints;
public bool seenPlayer;
private UnityEngine.AI.NavMeshAgent enemy;
private SphereCollider sphereCollider;
Vector3 center;
public float radius;
public bool waiting; //used by animator
public Transform initialPos;
GameObject player;
int index;
public bool playerReported; //used by other ghosts to tell the nanny they found him

void awake(){

    initialPos = transform;
    

}
// Start is called before the first frame update
    void Start()
    {
        
        fieldOfViewAngle=110f;
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>(); //gebt component mn el game object that is assigned
        index =0;  //which target am i at
        enemy.SetDestination(PatrolPoints[index].position);
        center = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] playerGameObject = GameObject.FindGameObjectsWithTag("Player");
        playerTransform = playerGameObject[0].transform;
        player = playerGameObject[0];
        //constantly checks if the player is seen and updates global variable seenPlayer
        playerSeenStatusUpdate();
        //I either saw the player, or I am the nanny and someone reported it
        if(seenPlayer || (tag =="Nanny" && playerReported)){
            //I saw player, I will go to it
            enemy.SetDestination(playerTransform.position+ Vector3.forward*0.2f); //adding some space just to avoid bumping into player
            //if I am the nanny and I am close to player return player to home and cut scene 
            //tag check is to prevent ghosts from returing the kid to the room

             if(enemy.remainingDistance <=0.14f && tag =="Nanny"){

                //TODO add scene cut 
                playerTransform.position = room.position;
                Debug.Log("yes");
                
                
             }
            //ghosts make the kid scream and the nanny finds him
            //If i am not the nanny, access the nannys script and set playerReported to true
             if(tag != "Nanny"){
                 GameObject[] nanny = GameObject.FindGameObjectsWithTag("Nanny");
                 //there is only one nanny, access first index only
                 //set boolean to true
                 nanny[0].GetComponent<EnemyLogic>().playerReported=true;

                

             }
             if(playerTransform.position== room.position){ //the player went to his room, reset the seenPlayer and go back to initial pos
                 //reset seenPlayer
                //reset my position
                 seenPlayer = false;
                 playerReported=false;
                 enemy.SetDestination(initialPos.position);
             }
             
             

        }
        else{
            //patrol
            if(enemy.remainingDistance <=0.15f){ //less than 5 cm, I reached current goal, time to update

            index++;
            if(index>=PatrolPoints.Length){
                index =0;

            }
            //wait a bit in place
            //WaitLookAround(0.5f);
             
            
        } 
        enemy.SetDestination(PatrolPoints[index].position);
           
            
        }
        
    }

    private IEnumerator WaitLookAround(float waitTime)
    {
        waiting=true;
        yield return new WaitForSeconds(waitTime);
        //print("Coroutine ended: " + Time.time + " seconds");
        waiting=false;
    }

    void playerSeenStatusUpdate()
    {
                //first check distance
                //then check is the player in my field of view?
                //get direction from enemy to player
                Vector3 direction = player.transform.position - transform.position;
                //get angle between enemy and player
                float angle = Vector3.Angle(direction, transform.forward);
                float distance = Vector3.Distance(player.transform.position,transform.position );
                if(distance<radius){
                    Debug.Log("Player collided");
                if(angle <  fieldOfViewAngle*0.5f){
                    Debug.Log("Player in field");
                    //now check theres nothing blocking enemys view
                    RaycastHit hit;
                    if(Physics.Raycast(transform.position, direction.normalized, out hit, radius)){

                        if(hit.collider.gameObject.tag == "Player"){
                            //you saw player
                            //lets disable players torch ? set up invisible colliders to prevent them moving?
                            seenPlayer=true;
                            Debug.Log("Player raycast");

                        }

                    }
                }
    }
                

            //}
        //}
    }
}
