using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider fxSlider;
   public AudioSource sourseMusic;
   //public AudioSource sourseFX;
   public Transform audioSourseMusic;
   //public Transform audioSourseFX;

    void Start()
    {
        musicSlider.value = Settings.musicLevel;
        fxSlider.value = Settings.fxLevel;
        sourseMusic = audioSourseMusic.gameObject.GetComponent<AudioSource>();
        //sourseFX = audioSourseFX.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        sourseMusic.volume = musicSlider.value;
        //sourseFX.volume = fxSlider.value;
    }
}
