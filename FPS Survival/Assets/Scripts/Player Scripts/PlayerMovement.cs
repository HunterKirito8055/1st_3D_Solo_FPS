using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character_controller;
    private Vector3 move_direction;

    public float speed = 5f;
    private float gravity =20f;

    public float jump_force = 10f;
    private float vertical_velocity;
    private void Awake()
    {
        character_controller = GetComponent<CharacterController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
    }
    void MoveThePlayer()
    {
        //X-left,right || Y-up and down || Z-forward and backward
        //actual function is Input.GetAxis("funcName");
        move_direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0, Input.GetAxis(Axis.VERTICAL));

        move_direction = transform.TransformDirection(move_direction);//local transform to WorldSpace if any child object altered...
        //best if we do this....
        move_direction *= speed * Time.deltaTime;
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
            print("VVGTD " + vertical_velocity);
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




}//class






































