using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliensscript : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 director;
    public float speed;
    public float shootingdelay;
    public float lastimeshot = 0f;
    public float bulletspeed;

    public Transform player;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void FixedUpdate()
    {
        director = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + director * speed * Time.fixedDeltaTime);
    }
}
