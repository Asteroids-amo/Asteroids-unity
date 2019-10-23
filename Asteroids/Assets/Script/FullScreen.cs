using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    public void fullScreen()
    {
        if (Screen.fullScreen == true)
        {
            // Window
            Screen.SetResolution(1680, 1050, false);
        }
        else
        {
            // Full
            Screen.SetResolution(1920, 1080, true);
        }
    }
}   