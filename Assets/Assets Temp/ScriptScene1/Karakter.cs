﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : MonoBehaviour
{
    public GameObject canvas_mc;
    bool sedanglompat;
    float delaylompat;
    // Animator an;

    Rigidbody2D rb;
    float dx;
    Vector2 pos;
    Vector2 flip;Animator an;
    // Start is called before the first frame update
    void Start()
    {
        // an=gameObject.GetComponent<Animator>();
        delaylompat=70f;
        sedanglompat=false;
        flip=transform.localScale;
        rb=gameObject.GetComponent<Rigidbody2D>(); 
        an=gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.A))
        {
            flip.x=-1;
            transform.localScale=flip;
            dx=-3;
             an.SetBool("SedangJalan",true);
            
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            flip.x=1;
            transform.localScale=flip;
            dx=3;
             an.SetBool("SedangJalan",true);
        }
        if (Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))
        {
            an.SetBool("SedangJalan",false);
            dx=0;
        }
        if(Input.GetKeyDown(KeyCode.Space) && sedanglompat==false){
            // gameObject.GetComponent<SoundEffect>().playSound(1,false,1f);
            sedanglompat=true;
            an.SetBool("sedangLompat",true);
            rb.AddForce(new Vector2(rb.velocity.x,6),ForceMode2D.Impulse);
        }
        rb.velocity = new Vector2(dx,rb.velocity.y);

    }
    private void FixedUpdate() {
        if (sedanglompat)
        {
            delaylompat--;
            if(delaylompat<0)
            {
                delaylompat=70f;
                sedanglompat=false;
                an.SetBool("sedangLompat",false);
            }
        }
    }
    // Start is called before the first frame update    
}
