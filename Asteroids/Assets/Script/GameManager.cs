using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //telt hoeveel astroied je hebt in je scene
    public int numberOfAstroied;
    public int levelnummber = 1;
    public GameObject asteroidlarge;
    public GameObject astroidmedium;
    public GameObject astroidsmall;
    public GameObject ufored;

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

        for (int i = 0; i < levelnummber*1; i++)
        {
            Vector2 spawn = new Vector2(Random.Range(-12f, 12f),7f);
            Instantiate(asteroidlarge,spawn,Quaternion.identity);
            numberOfAstroied++;
        }

        for (int i = 0; i < levelnummber*1; i++)
        {
            Vector2 spawn = new Vector2(Random.Range(-12f, 12f), 7f);
            Instantiate(astroidmedium, spawn, Quaternion.identity);
            numberOfAstroied++;
        }

        for (int i = 0; i < levelnummber * 3; i++)
        {
            Vector2 spawn = new Vector2(Random.Range(-12f, 12f), 7f);
            Instantiate(astroidsmall, spawn, Quaternion.identity);
            numberOfAstroied++;
        }
    }
}
