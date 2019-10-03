using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public float maxThrust;
    public float maxTorque;
    public Rigidbody2D rb;

    //scherm wraping zo dat je niet uit de map kan
    public float screentop;
    public float screendown;
    public float screenleft;
    public float screenright;

    //Als de astroied vernietieg worden
    public int astroidSize; // 3 large // 2 medium // 1 small
    public GameObject astroidMedium;
    public GameObject astroidSmall;

    // Start is called before the first frame update
    void Start()
    {
        //push de astroide als de game start
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust,maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);

        astroidSize = 3; // grote astroied
    }

    // Update is called once per frame
    void Update()
    {
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("shoot"))
        {   
            // vernietig de kogel
            Destroy(other.gameObject);

            // controlleer de groot van de astroide
            if(astroidSize == 3)
            {
                //split het naar 2 dus medium astroide
                Instantiate(astroidMedium, transform.position, transform.rotation);
                Instantiate(astroidMedium, transform.position, transform.rotation);
            }
            else if(astroidSize == 2)
            {
                //split het naar 2 dus kleine astroide
                Instantiate(astroidSmall, transform.position, transform.rotation);
                Instantiate(astroidSmall, transform.position, transform.rotation);
            }
            else if(astroidSize == 1)
            {
                //vernietig de astroide
            }

            //vernietig nu astroide
            Destroy(gameObject);
        }

    }
}
