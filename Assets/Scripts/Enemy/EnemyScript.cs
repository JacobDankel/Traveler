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

    // Time
    private GameController gameController;

    private void Start()
    {
        bod = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        //target = FindObjectOfType<PlayerController>();

        health = maxHP;
    }

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);

            gameController.UpdateTime(5);
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

        gameObject.transform.position = new Vector3(transform.position.x + speedX * Time.deltaTime, transform.position.y + speedY * Time.deltaTime, transform.position.z);
    }

    public void setTarget(GameObject newTarget)
    {
        target = newTarget;
    }
}