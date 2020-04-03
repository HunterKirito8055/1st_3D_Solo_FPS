using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character_controller;
    private Vector3 move_direction;


    public float go_speed;
    public float normal_speed = 5f;
    public float sprint_speed = 7.5f;
    private float gravity =20f;

    public float jump_force = 10f;
    private float vertical_velocity;


    private PlayerFootSteps playerfoot;

    private float sprint_vol = 1f;
    private float normal_vol_min = 0.2f, normal_vol_max = 0.6f;
    private float normal_step_dist = 0.40f;
    private float sprint_step_dist = 0.25f;



    private void Awake()
    {
        character_controller = GetComponent<CharacterController>();
        playerfoot = GetComponentInChildren<PlayerFootSteps>();
    }

    private void Start()
    {
        playerfoot.vol_min = normal_vol_min;
        playerfoot.vol_max = normal_vol_max;
        playerfoot.step_dist = normal_step_dist;

    }

    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
        Sprint();
    }
    void MoveThePlayer()
    {
        //X-left,right || Y-up and down || Z-forward and backward
        //actual function is Input.GetAxis("funcName");
        move_direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0, Input.GetAxis(Axis.VERTICAL));
        //print("transfa" + transform.TransformDirection(move_direction));
        move_direction = transform.TransformDirection(move_direction);//local transform to WorldSpace if any child object altered...
        //best if we do this....
        move_direction *= go_speed * Time.deltaTime;
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
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            go_speed = sprint_speed;
            playerfoot.step_dist = sprint_step_dist;
            //if we sprint we want same max volume
            playerfoot.vol_min = sprint_vol;
            playerfoot.vol_max = sprint_vol;
           
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            go_speed = normal_speed;

            playerfoot.vol_min = normal_vol_min;
            playerfoot.vol_max = normal_vol_max;
            playerfoot.step_dist = normal_step_dist;
        }
    }



}//class






































