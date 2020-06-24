using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 velocity;
    Animator anime;

    [SerializeField] float speed;
    [SerializeField] Joystick js;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    
    void Update()
    {
        //Getting Player Input From Joystick
        Vector2 playerInput = new Vector2(js.Horizontal, js.Vertical);
        velocity = playerInput.normalized * speed;

        //Checking If Player Is Going Forward Or Not
        if(js.Horizontal <= 0)
        {
            anime.SetBool("isGoingForward", false);
        }
        else
        {
            anime.SetBool("isGoingForward", true);
        }
        
    }

    private void FixedUpdate()
    {
        //Movement Using Rigidbody
        rb.MovePosition(rb.position + (velocity * Time.deltaTime));
    }
 
}
