using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //telt hoeveel astroied je hebt in je scene
    public int numberOfAstroied;
    public int levelnummber = 1;
    public GameObject asteroid;

    public void updateNumberOfAstroied(int change)
    {
        numberOfAstroied += change;

        if(numberOfAstroied <= 0)
        {
            Invoke("startnewlevel", 3f);
        }
    }

    public void startnewlevel()
    {
        levelnummber++;

        for (int i = 0; i < levelnummber*2; i++)
        {
            Vector2 spawn = new Vector2(Random.Range(-12f, 12f),7f);
            Instantiate(asteroid,spawn,Quaternion.identity);
            numberOfAstroied++;
        }
    }
}
