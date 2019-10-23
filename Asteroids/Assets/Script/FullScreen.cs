using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    public void fullScreen()
    {
        // Toggle fullscreen
        Screen.fullScreen = !Screen.fullScreen;
    }
}   