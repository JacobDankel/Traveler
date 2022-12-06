using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    //Components
    public Rigidbody2D bod;
    public Collider2D col;

    private Animator anim;

    //Movement
    [Space]
    public GameObject nodeL;
    public GameObject nodeR;
    public float speed;
    public bool movingLeft;

    //Health
    [Space]
    [SerializeField]
    public float maxHP;
    private float health;

    //Attack
    [Space]
    public GameObject bullet;
    public GameObject player;
    public Transform gunExit;
    public float cooldown;
    public bool canShoot;

    private void Start()
    {
        bod = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        //target = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();

        health = maxHP;
        canShoot = true;
    }

    private void Update()
    {
        if (health <= 0)
        {
            anim.SetBool("IsHurt", true);
            //Destroy(gameObject);
        }
        if (canShoot)
        {
            StartCoroutine(shoot());
        }
    }
    void LateUpdate()
    {
        move();
    }

    private void move()
    {
        if (transform.position.x < nodeL.transform.position.x)
        {
            movingLeft = true;
        }
        if (transform.position.x > nodeR.transform.position.x)
        {
            movingLeft = false;
        }
        if (movingLeft)
        {
            gameObject.transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        } 
        else
        {
            gameObject.transform.position = new Vector3(transform.position.x + speed * Time.deltaTime * -1, transform.position.y, transform.position.z);
        }
    }

    public void setTarget(GameObject player)
    {
        this.player = player;
    }

    IEnumerator shoot()
    {
        Vector2 aim = transform.position - player.transform.position;
        Quaternion spread = Quaternion.Euler(aim);
        Instantiate(bullet, gunExit.position, spread);
        Debug.Log("shooting");

        canShoot = false;

        yield return new WaitForSecondsRealtime(cooldown);

        canShoot = true;
    }
}
