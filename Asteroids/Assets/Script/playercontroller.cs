using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject bullet;
    public float bulletforce;

    //score
    public int score;
    public Text scoretext;

    //ship leven
    public float deathforce;
    public int lives;
    public Text livestext;
    public GameObject explosion;
    public Color inColor;
    public Color normalColor;

    //gameover
    public GameObject gameoverpanal;

    // Use this for intialization
    private void Start()
    {
        score = 0;

        scoretext.text = "score " + score;

        // update de leven text
        livestext.text = "Lives X" + lives;
    }


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

        //rotatie schip
        transform.Rotate(Vector3.forward * turnInput * Time.deltaTime * -turnThrust);

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
        //rb.AddTorque(-turnInput); 
    }

    void scorepoint(int pointsadd)
    {
        score += pointsadd;
        scoretext.text = "score " + score;
    }

    void Respawn()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;

       SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.enabled = true;
        sr.color = inColor;
        Invoke("Invulnerable", 3f);
    }


    void Invulnerable()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = normalColor;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.relativeVelocity.magnitude);

        if (col.relativeVelocity.magnitude > deathforce)
        {
            lives--;
            GameObject newExplosion = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(newExplosion, 3f);
            livestext.text = "Lives X" + lives;
            //respwan wanneer je dood ben
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Invoke("Respawn", 3f);

            if (lives <= 0)
            {
                //gameover
                SceneManager.LoadScene("Leaderboard");
            }
        }
    }

    // als je dood bent
    void Gameover()
    {
        CancelInvoke();
        gameoverpanal.SetActive(true);
    }

    //opnieuw spelen
    public void playagain()
    {
        SceneManager.LoadScene("level");
    }
}