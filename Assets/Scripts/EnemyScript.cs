using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Components
    public Rigidbody2D bod;
    public Collider2D col;

    //Movement
    [Space]
    public GameObject target;
    public float speed;

    //Health
    [Space]
    [SerializeField]
    public float maxHP;
    private float health;

    private void Start()
    {
        bod = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        health = maxHP;
        speed *= 0.01f;
    }

    private void LateUpdate()
    {
        //Movement
        Vector2 currentPos = gameObject.transform.position;
        Vector2 targetPos = target.transform.position;
        Vector2 diff = currentPos - targetPos;

        float speedX;
        float speedY;

        if (diff.y <= 0)
        {
            //move.y = 1 * speed;
            speedY = speed;
        }
        else
        {
            //move.y = -1 * speed;
            speedY = -speed;
        }
        if (diff.x <= 0)
        {
            //move.x = 1 * speed;
            speedX = speed;
        }
        else
        {
            //move.x = -1 * speed;
            speedX = -speed;
        }

        gameObject.transform.position = new Vector3(transform.position.x + speedX, transform.position.y + speedY, transform.position.z);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit!");
    }
}