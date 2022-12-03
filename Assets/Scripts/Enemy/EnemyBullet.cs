using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //Components
    [SerializeField]
    private Rigidbody2D rb;
    private CircleCollider2D col;

    public int bulSpd;
    private float delay = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        col = GetComponent<CircleCollider2D>();
        rb.AddRelativeForce(new Vector2(1 * bulSpd, 1));
        Destroy(gameObject, delay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
