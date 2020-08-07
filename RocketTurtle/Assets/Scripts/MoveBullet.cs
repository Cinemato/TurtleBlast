using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        switch (transform.parent.tag)
        {
            case "UpperCannon":
                rb.velocity = new Vector2(speed, 0.7f);
                break;
            case "MiddleCannon":
                rb.velocity = new Vector2(speed, 0);
                break;
            case "LowerCannon":
                rb.velocity = new Vector2(speed, -0.7f);
                break;
        }

    }
}
