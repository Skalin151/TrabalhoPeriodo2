using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public float MovementSpeed = 5;
    public Animator animator;
    public float jumpforce;
    Rigidbody2D rb;
    BoxCollider2D bc;
    private bool isGrounded;
    private object raycastHit2D;
    float horizontalmove = 0f;
    public float cooldown = 3f;
    private float timeStamp;
    private bool canJump;
    float coolDownTime = 3;
    public float JumpHeight;
    public float cooldownTime = 2;
    public float nextjump; 

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();

    }

    



    void jump()
    {
        float jumpforce = 7f;
        rb.velocity = Vector2.up * jumpforce;
        canJump = true;

   if(Time.time-nextjump < cooldown)
        {
            return;
        }
        nextjump = Time.time;
      

    }




    private void FixedUpdate()
    {
        float Xinput = Input.GetAxis("Horizontal");
       transform.position += new Vector3(Xinput, 0, 0) * Time.deltaTime * MovementSpeed;


        animator.SetFloat("Speed", Mathf.Abs(MovementSpeed));
    }
    void  Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            jump();
            ;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump();
        }
                

    }


    private void OnTriggerEnter2D(Collider2D other)
       
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("Keys"))
        {
            Destroy(other.gameObject);
            
        }
        if (other.gameObject.CompareTag("Doors"))
        {
            Destroy(other.gameObject);
        }
               
        
    }
   

}



