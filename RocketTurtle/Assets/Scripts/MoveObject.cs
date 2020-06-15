using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    Rigidbody2D rb;

    void Start()
    {
        //Moving Object To The Left Direction Using Rigidbody
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

}
