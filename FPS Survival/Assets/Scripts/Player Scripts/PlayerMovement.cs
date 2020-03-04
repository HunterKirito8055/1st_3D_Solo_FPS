 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character_controller;
    private Vector3 move_direction;
   
    public float move =5f ; //default running speed

    [SerializeField]
    private Transform Look_Root;    //Look root has main camera
    public float run = 5f;
   
    public float sprint_speed = 7f;
    public float crouch_speed = 2.5f;

    private float stand_height = 1.8f;
    private float crouch_height = 1.2f;

    [SerializeField]
    private bool is_Crouching;

    private float gravity =20f;

    public float jump_force = 10f;
    private float vertical_velocity;
    private void Awake()
    {
        character_controller = GetComponent<CharacterController>();
        Look_Root = transform.GetChild(0);
    }
    
    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
        Sprint();
        Crouch();
    }
    void MoveThePlayer()
    {
        //X-left,right || Y-up and down || Z-forward and backward
        //actual function is Input.GetAxis("funcName");
        move_direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0, Input.GetAxis(Axis.VERTICAL));

        move_direction = transform.TransformDirection(move_direction);//local transform to WorldSpace if any child object altered...
                                                                      //best if we do this....
        
        move_direction *= move * Time.deltaTime;
        //if (move_direction.x > 0)
        //    print("delta time " + Time.deltaTime); to check the Delta Time

        ApplyGravity();

        character_controller.Move(move_direction);   
    }//Movement
    void ApplyGravity()
    {
        if(character_controller.isGrounded)
        {
           // vertical_velocity -= gravity * Time.deltaTime;
          //  print("VVGTD " + vertical_velocity);
            //apply jump as it is on the Ground
            PlayerJump();
        }
        else
        {
            vertical_velocity -= gravity * Time.deltaTime;
        }

        move_direction.y = vertical_velocity * Time.deltaTime;
    }//gravity

    void PlayerJump()
    {
        if(character_controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            vertical_velocity = jump_force;
        }
    }

    void Sprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching)
        {
            move = sprint_speed;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching)
        {
            move = run;
        }
    }
    void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(is_Crouching)    //if crouching is true, then by press C, he needs to stand
            {
                Look_Root.localPosition = new Vector3(0, stand_height , 0);

                move = run;
             
                is_Crouching = false;
            }
            else    //if not crouching by press C, then he needs to Crouch
            {
                Look_Root.localPosition = new Vector3(0, crouch_height  , 0);
                move = crouch_speed;

                is_Crouching = true;
            }
        }
        character_controller.height = Mathf.Lerp(character_controller.height, Look_Root.localPosition.y, 5f * Time.deltaTime);
        

    }


}//class






































