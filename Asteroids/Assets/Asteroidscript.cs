using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroidscript : MonoBehaviour
{
    public float maxThrust;
    public float maxTorque;
    public Rigidbody2D rb;
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;

    // Start is called before the first frame update
    void Start()
    {
        // Add a random amount of torque and thrust 
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust,maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce (thrust);
        rb.AddTorque (torque);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;
        if (transform.position.y > screenTop){
            newPos.y = screenBottom;
        }
        if (transform.position.y < screenBottom){
            newPos.y = screenTop;
        }
        if (transform.position.x > screenRight){
            newPos.x = screenLeft;
        }
        if (transform.position.x < screenLeft){
            newPos.x = screenLeft;
        }
        transform.position = newPos;
    }
}
