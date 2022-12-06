using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Components
    public Rigidbody2D bod;
    public Collider2D col;

    private Animator anim;

    //Movement
    [Space]
    public Transform target;
    public float speed;

    //Health
    [Space]
    [SerializeField]
    public float maxHP;
    public float health;

    // Time
    private GameController gameController;
    public int score;

    private void Start()
    {
        bod = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        //target = FindObjectOfType<PlayerController>();
        score = 5;
        health = maxHP;

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(health <= 0)
        {
            //anim.SetBool("IsHurt", true);
            gameController.UpdateTime(score);
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("Enemy Hit");
            health -= 1;
        }
    }
    private void move()
    {
        if (target == null)
        {
            return;
        }
        //Movement
        Vector2 currentPos = gameObject.transform.position;
        Vector2 targetPos = target.position;
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

        gameObject.transform.position = new Vector3(transform.position.x + speedX * Time.deltaTime, transform.position.y + speedY * Time.deltaTime, transform.position.z);

        if (diff.x != 0 || diff.y != 0)
        {
            anim.SetFloat("X", diff.x * -1);
            anim.SetFloat("Y", diff.y * -1);
            anim.SetBool("IsWalking", true);
        } else
        {
            anim.SetBool("IsWalking", false);
        }
        if (diff.x <= 0.001 || diff.y <= 0.001)
        {
            anim.SetBool("IsAttacking", true);
        } else
        {
            anim.SetBool("IsAttacking", false);
        }
    }

    public void setTarget(Transform newTarget)
    {
        target = newTarget;
    }
}