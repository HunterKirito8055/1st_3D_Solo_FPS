using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{

    private AudioSource audiosource;

    [SerializeField]
    private AudioClip scream, die_clip;

    [SerializeField]
    private AudioClip[] attack_clip;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void PlayScream()
    {
        audiosource.clip = scream;
        audiosource.Play();
    }

    public void Play_AttackSound()
    {
        audiosource.clip = attack_clip[Random.Range(0, attack_clip.Length)];
        audiosource.Play();
    }

    public void Play_DeadSound()
    {
        audiosource.clip = die_clip;
        audiosource.Play();
    }




}//class




















