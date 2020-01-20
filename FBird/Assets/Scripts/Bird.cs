﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 400;

    private bool taMorto = false;
  
    private Rigidbody2D rb2d;
    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!taMorto)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }

        rb2d.position = new Vector2(rb2d.position.x, Mathf.Clamp(rb2d.position.y, rb2d.position.y, 4.7f));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.velocity = Vector2.zero;
        taMorto = true;
        anim.SetTrigger("Morreu");
        Gamecontrol.gameControl.BirdDie();
    }
}
