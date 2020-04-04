using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audiosource;

    [SerializeField]
    AudioClip[] sounds;

    void playSound()
    {
        audiosource.clip = sounds[Random.Range(0, sounds.Length)];
        audiosource.Play();
    }


}//class

