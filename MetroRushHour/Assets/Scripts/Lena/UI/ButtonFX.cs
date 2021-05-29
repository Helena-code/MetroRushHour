using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    public AudioSource audioButtonFX;
    public AudioClip buttonHover;
    public AudioClip buttonClick;
    public AudioClip buttonBackClick;

    public void HoverButton()
    {
        audioButtonFX.PlayOneShot(buttonHover);
    }
    public void ClickButton()
    {
        audioButtonFX.PlayOneShot(buttonClick);
    }
    public void ClickBackButton()
    {
        audioButtonFX.PlayOneShot(buttonBackClick);
    }
}
