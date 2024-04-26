using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    AudioSource audiosource;
    Rigidbody2D rb2D;

    float x;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal") * speed;
        rb2D.velocity = new Vector2(x, rb2D.velocity.y);
        if (rb2D.velocity.x == 6)
        {
            if (!audiosource.isPlaying)
                audiosource.Play();
        }
        else
        {
            audiosource.Stop();
        }
    }
}