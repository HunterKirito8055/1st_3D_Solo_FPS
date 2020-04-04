using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{
    private AudioSource footsounds;

    [SerializeField]
    private AudioClip[] footclips = default;

    private CharacterController character_controller;

    [HideInInspector]
    public float vol_min, vol_max;

    private float accumulated_dist;

    [HideInInspector]
    public float step_dist;

    private void Awake()
    {
        footsounds = GetComponent<AudioSource>();

        character_controller = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckToPlaySounds();        
    }

    void CheckToPlaySounds()
    {
        //if not on ground..we return and dont play sound
        if (!character_controller.isGrounded)
            return;
        if(character_controller.velocity.sqrMagnitude >0)
        {
            //accumulated distance is nothing but a time appending distance from the begionning of the motion
            accumulated_dist += Time.deltaTime;
            if(accumulated_dist >step_dist)
            {
                footsounds.volume = Random.Range(vol_min, vol_max);
                footsounds.clip = footclips[Random.Range(0, footclips.Length)];
                footsounds.Play();

                accumulated_dist = 0;
            }
        }
        else
        {
            accumulated_dist = 0;
        }
    }






}//class











