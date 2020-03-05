using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoootSteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] Foot_Clip;

    private AudioSource footstep_sound;
    private CharacterController _characterController;   // need to get from parent
    
    [HideInInspector]
    public float volMax, volMin;
    [HideInInspector]
    public float step_dist;

    private float accumulated_distance;     //travelled distance from previous position to User given position in magnitude

    private void Awake()
    {
        _characterController = GetComponentInParent<CharacterController>();
        footstep_sound = GetComponent<AudioSource>();

    }
    private void Update()
    {
        PlayStepSounds();
    }

    void PlayStepSounds()
    {
        //if player is in the air dont play sound
        if(!_characterController.isGrounded)
        {
            return;
        }



        //sqrmagnitude > 0 means moving,, then play sound
        if(_characterController.velocity.sqrMagnitude>0)
        {
            accumulated_distance += Time.deltaTime;//0+time elapsed .... 

            if(accumulated_distance>step_dist)  //we will produce amount of step_dist from playermovement script
            {
                footstep_sound.volume = Random.Range(volMin, volMax);
                footstep_sound.clip = Foot_Clip[Random.Range(0, Foot_Clip.Length)];
                footstep_sound.Play();

                accumulated_distance = 0f;
            }
        }
        //else not moves, no sounds
        else
        {
            accumulated_distance = 0f;
        }
    }


}//class








