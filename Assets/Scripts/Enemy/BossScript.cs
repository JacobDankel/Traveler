using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    //Components
    public Rigidbody2D bod;
    public Collider2D col;
    private GameController gameController;
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
    public float health;
    private bool notDead = true;

    //Attack
    [Space]
    public GameObject bullet;
    public GameObject player;
    public Transform gunExit;
    public float cooldown;
    public bool canShoot;
    public float angle;
    public GameObject[] spawners;

    private void Start()
    {
        bod = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        gameController = FindObjectOfType<GameController>();
        anim = GetComponent<Animator>();

        health = maxHP;
        canShoot = true;
        //gameObject.SetActive(false);
    }

    private void Update()
    {
        if (health <= 0)
        {
            notDead = false;
            gameController.UpdateTime(25);
            destroySpawners();
            Destroy(gameObject);
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
        if (movingLeft && notDead)
        {
            gameObject.transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        } 
        else
        {
            gameObject.transform.position = new Vector3(transform.position.x + speed * Time.deltaTime * -1, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("Boss Hit");
            health -= 1;
        }
    }

    public void destroySpawners()
    {
        for(int i = 0; i < spawners.Length; i++)
        {
            Destroy(spawners[i]);
        }
        for (int i = 0; i < 100; i++)
        {
            GameObject tempObj = FindObjectOfType<BossGuardScript>().gameObject;
            if (tempObj == null)
                break;
            Destroy(tempObj);

        }

    }

    public void setTarget(GameObject player)
    {
        this.player = player;
    }

    /*
      
        mouse_pos = Input.mousePosition;
        object_pos = Camera.main.WorldToScreenPoint(gun.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x)* Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    
     */

    IEnumerator shoot()
    {
        Vector3 aim = transform.position - player.transform.position;

        angle = Mathf.Atan2(aim.x, aim.y) * Mathf.Rad2Deg;

        Instantiate(bullet, gunExit.position, Quaternion.Euler(new Vector3(0,0,angle)));
        Debug.Log("shooting");

        canShoot = false;

        yield return new WaitForSecondsRealtime(cooldown);

        canShoot = true;
    }
}
