using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource = null;

    public void Play(){
        Debug.Log("AUDIO -> Play()");
        audioSource.Play();
        Debug.Log("AUDIO -> isPlaying: " + audioSource.isPlaying);
    }
}