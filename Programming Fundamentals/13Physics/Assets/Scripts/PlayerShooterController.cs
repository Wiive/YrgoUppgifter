using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterController : MonoBehaviour
{
    public float speed = 5;
    public float jumpPower = 10;

    public GameObject shot;
    public Transform shotSpawn;
    public float shotSpeed = 10;

    Rigidbody2D rb2d;
    Animator animator;
    SpriteRenderer spriteRenderer;
    AudioSource shootSound;
    private Vector2 fireDirection;

    Vector2 movement = new Vector2();

    bool grounded = false;
    bool jump;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        shootSound = GetComponent<AudioSource>();
        fireDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Fireing
        if (Input.GetButtonDown("Fire1"))
        {
            shootSound.Play();
            GameObject firedShot = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            firedShot.GetComponent<Rigidbody2D>().velocity = shotSpawn.up * shotSpeed;
        }

        //Movement
        float x = Input.GetAxis("Horizontal");

        movement = new Vector3(x * speed, rb2d.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(x));
        animator.SetFloat("Fall", rb2d.velocity.y);

        if (x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (x > 0)
        {
            spriteRenderer.flipX = false;
        }


        if (Input.GetButtonDown("Jump") && grounded)
        {

            jump = true;
        }

        if (jump)
        {
            animator.SetTrigger("Jump");
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }


    }

    private void FixedUpdate()
    {
        rb2d.velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        grounded = true;
        animator.SetTrigger("Landed");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        grounded = true;
    }
}
