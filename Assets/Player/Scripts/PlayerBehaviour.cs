using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Animator anim;

    public float movementSpeed = 5;
    public float runningSpeed = 5;
    public float rotationSpeed = 100;

    public bool isRunning = false;
    public bool isCrouched = false;
    public bool scared = false;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!scared)
        {
            handlePlayerInput();
            handleMovement();
        }
        else
        {
            anim.SetTrigger("scared");
        }
    }

    void handlePlayerInput()
    {
        isRunning = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouched = !isCrouched;
            if(isCrouched)
            {
                isRunning = false;
            }
        }
    }

    void handleMovement()
    {
        // handle actual motion of model
        float speed;
        if (isRunning && !isCrouched)
            speed = runningSpeed;
        else
            speed = movementSpeed;

        float xMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float yMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 motion = new Vector3(xMovement, 0, yMovement);
        
        //Vector3 rotation = new Vector3(0, xMovement, 0);

        transform.Translate(motion);
        //transform.Rotate(rotation);


        // handle the animations of the model
        anim.SetBool("moving", yMovement != 0 || xMovement!=0);

        anim.SetBool("running", isRunning && yMovement>0 && !isCrouched);

        anim.SetBool("crouched", isCrouched);
        
    }

    public void jumpScare()
    {
        scared = true;
    }
}
