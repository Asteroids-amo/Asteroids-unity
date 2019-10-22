using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    public void fullScreen()
    {
        // Switch to 640 x 480 full-screen
        Screen.SetResolution(640, 480, true);
    }
}