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
     if(Time.time > lastimeshot + shootingdelay)
        {
            float angle = Mathf.Atan2(director.y, director.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

            GameObject newbullet = Instantiate(bullet, transform.position, q);

            newbullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, bulletspeed));
            lastimeshot = Time.time;
        }
    }

    private void FixedUpdate()
    {
        director = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + director * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {

        }
    }
}
