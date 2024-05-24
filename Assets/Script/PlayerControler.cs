using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControler : MonoBehaviour
{
    AudioSource run;
    public float speed;

    private Rigidbody2D rb;
    public Joystick joystick;
    private GameObject joystickObject;

    public Animator anime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joystickObject = joystick.gameObject; 

        run = GetComponent<AudioSource>();
        anime = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveInput = joystick.Horizontal;


        if (Mathf.Abs(joystick.Vertical) >= 0.9f)
        {
            joystickObject.SetActive(false);
            run.Stop();
            anime.SetBool("stop", true);
        }
        else
        {
            joystickObject.SetActive(true);
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            if (rb.velocity.x != 0)
            {
                if (!run.isPlaying)
                {
                    run.Play();
                    anime.SetBool("stop", false);
                }

            }
            else
            {
                run.Stop();
                anime.SetBool("stop", true);
            }
        }
    }

}
