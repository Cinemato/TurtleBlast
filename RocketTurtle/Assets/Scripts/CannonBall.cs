using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float force;
    [SerializeField] float areaDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

            foreach (Collider2D c in colliders)
            {
                Enemy e = c.GetComponent<Enemy>();
                Rigidbody2D rb = c.GetComponent<Rigidbody2D>();

                Vector2 direction = c.transform.position - transform.position;

                if (e != null && e.getHealth() < 800 && !e.GetComponent<Armored>())
                {
                    Animator anime = e.GetComponent<Animator>();
                    anime.SetBool("IsHurt", true);
                    e.recieveDamage(areaDamage);                    
                    rb.AddForce(direction * force);
                }

            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
