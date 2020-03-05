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
  
    private float gravity =20f;

    public float jump_force = 10f;
    private float vertical_velocity;

    //we need to apply theese movements later on in script
    //optional  scripting
    public float sprint_speed = 7f;
    public float crouch_speed = 2.5f;

    private float target_height;
    private float stand_height = 1.8f;
    private float crouch_height = 1.2f;

    [SerializeField]
    private bool is_Crouching;

    // need to access data from playerfootsteps script
    private PlayerFoootSteps _playerfootsteps;

    private float sprint_vol = 1f;
    float crouch_vol = 0.1f;
    float walk_vol_min = 0.3f, walk_vol_max = 0.6f;
    //giving step distances
    float walk_step_dist = 0.4f;
    float sprint_step_dist = 0.25f;
    float crouch_step_dist = 0.3f;
    private void Awake()
    {
        character_controller = GetComponent<CharacterController>();

        Look_Root = transform.GetChild(0);
        //getting script component
        _playerfootsteps = GetComponentInChildren<PlayerFoootSteps>();

    }

    private void Start()
    {
        _playerfootsteps.volMin = walk_vol_min;
        _playerfootsteps.volMax = walk_vol_max;
        _playerfootsteps.step_dist = walk_step_dist;
    }
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
            _playerfootsteps.step_dist = sprint_step_dist;
            _playerfootsteps.volMax = sprint_vol;
            _playerfootsteps.volMin = sprint_vol;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching)
        {
            move = run;

            _playerfootsteps.step_dist = walk_step_dist;
            _playerfootsteps.volMin = walk_vol_min;
            _playerfootsteps.volMax = walk_vol_max;
            
        }
    } //sprinting



    void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(is_Crouching)    //if crouching is true, then by press C, he needs to stand
            {
                //Look_Root.localPosition = new Vector3(0, stand_height , 0);
                target_height = stand_height;
                move = run;

                //he is standing
                _playerfootsteps.step_dist = walk_step_dist;
                _playerfootsteps.volMin = walk_vol_min;
                _playerfootsteps.volMax = walk_vol_max;

                is_Crouching = false;
            }
            else    //if not crouching by press C, then he needs to Crouch
            {
                //Look_Root.localPosition = new Vector3(0, crouch_height  , 0);
                target_height = crouch_height;
                move = crouch_speed;

                _playerfootsteps.step_dist = crouch_step_dist;
                _playerfootsteps.volMax = crouch_vol;
                _playerfootsteps.volMin = crouch_vol;

                is_Crouching = true;
            }
           
        }

        character_controller.height = Mathf.Lerp(character_controller.height, target_height, 5f * Time.deltaTime);
        Look_Root.transform.position = Vector3.Lerp(Look_Root.transform.position, new Vector3(Look_Root.transform.position.x,character_controller.transform.position.y + target_height - 0.1f, Look_Root.transform.position.z),5 * Time.deltaTime);
        // Look_Root.transform.position = Vector3.Lerp(Look_Root.transform.position,new Vector3(Look_Root.transform.position.x,target_height,Look_Root.transform.position.z),5 * Time.deltaTime);
    }


}//class






































