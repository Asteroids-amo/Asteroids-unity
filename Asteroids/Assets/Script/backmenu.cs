using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backmenu : MonoBehaviour
{
    public void mainmenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("MainScene");
    }

    public void submit()
    {
        SceneManager.LoadScene("Gameover");
    }

    //opnieuw spelen
    public void playagain()
    {
        SceneManager.LoadScene("Medium");
    }

}
