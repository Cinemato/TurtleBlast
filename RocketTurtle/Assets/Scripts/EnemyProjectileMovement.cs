using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileMovement : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 5f;

    Rigidbody2D rb;
    Vector2 direction;
    PlayerMovement player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        move();
    }

    public void move()
    {
        direction = (player.transform.position - transform.position).normalized * projectileSpeed;
        rb.velocity = new Vector2(direction.x, direction.y);
    }

    public void moveAgain()
    {
        rb.velocity = new Vector2(direction.x, direction.y);
    }
}
