using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        thrustInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        //screen wraping
        Vector2 newPos = transform.position;
        if (transform.position.y > screentop)
        {
            newPos.y = screendown;
        }
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * thrustInput);
        rb.AddTorque(-turnInput); 
    }
}
