using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private AudioSource audioSoursePlayer;
    public AudioClip[] audioClipsRun;
    public AudioClip testClip;
    void Start()
    {
        audioSoursePlayer = GetComponent<AudioSource>();
    }

     public void PlaySoundStep()
    {
        // audioSoursePlayer.PlayOneShot(audioClipsRun[Random.Range(0, audioClipsRun.Length)]);
        audioSoursePlayer.PlayOneShot(testClip);
    }
}
