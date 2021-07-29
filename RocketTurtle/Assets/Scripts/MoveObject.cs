using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] bool towardsRight = true;

    Rigidbody2D rb;

    void Start()
    {
        //Moving Object Using Rigidbody
        rb = GetComponent<Rigidbody2D>();
        move();
    }

    public void move()
    {
        if (!towardsRight)
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        else
        {
            rb.velocity = new Vector2(speed, 0);
        }
    }

    public void upperBullet()
    {
        rb.velocity = new Vector2(speed, 0.7f);
    }

    public void lowerBullet()
    {
        rb.velocity = new Vector2(speed, -0.7f);
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public void setTowardsRight(bool towardsRight)
    {
        this.towardsRight = towardsRight;
    }

    public bool getTowardsRight()
    {
        return towardsRight;
    }

    public float getSpeed()
    {
        return speed;
    }

    public IEnumerator OriginalSpeed(Animator anime)
    {
        yield return new WaitForSeconds(0.5f);

        rb.velocity = new Vector2(-speed, 0);

        anime.SetBool("IsHurt", false);
    }
}
