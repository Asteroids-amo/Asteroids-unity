using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource volumeAudio;
    public void VolumeController()
    {
        volumeAudio.volume = volumeSlider.value;
    }
}
