using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{

    // roep de rigibody aan
    public Rigidbody2D rb;

    //ship te laten bewegen
    public float thrust;
    public float turnThrust;
    private float thrustInput;
    private float turnInput;

    //scherm wraping zo dat je niet uit de map kan
    public float screentop;
    public float screendown;
    public float screenleft;
    public float screenright;

    //schieten
    public GameObject  bullet;
    public float bulletforce;

    // Update is called once per frame
    void Update()
    {
        thrustInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        //check input van de vuur knop en maak kogels aan
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newbullet = Instantiate(bullet, transform.position, transform.rotation);
            newbullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletforce);
            Destroy(newbullet, 7.0f);
        }

        //zo dat je niet uit de map vlieg
        Vector2 newPos = transform.position;
        if (transform.position.y > screentop)
        {
            newPos.y = screendown;
        }
        if (transform.position.y < screendown)
        {
            newPos.y = screentop;
        }
        if (transform.position.x > screenright)
        {
            newPos.x = screenleft;
        }
        if (transform.position.x < screenleft)
        {
            newPos.x = screenright;
        }

        transform.position = newPos;
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * thrustInput);
        rb.AddTorque(-turnInput); 
    }
}