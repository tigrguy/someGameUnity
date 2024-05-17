using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    AudioSource run;
    public float speed;

    private Rigidbody2D rb;
    public Joystick joystick;
    private GameObject joystickObject; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joystickObject = joystick.gameObject; 

        run = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
        float moveInput = joystick.Horizontal;

        
        if (Mathf.Abs(joystick.Vertical) >= 0.9f)
        {
            joystickObject.SetActive(false);
            run.Stop();

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
                }
            }
            else
            {
                run.Stop();
            }

        }
    }
}
