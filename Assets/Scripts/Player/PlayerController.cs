using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Components
    public BoxCollider2D col;
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;

    //Movement
    [Space]
    public float speed;

    //Portal
    [Space]
    public LevelLoader portal;

    //Shooting
    public GameObject Bullet;
    private Vector3 mouse_pos;
    public Transform gun;
    public Transform gunTip;
    private Vector3 object_pos;
    private float angle;
    

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    // Update is called once per frame
    void Update()
    {
        // Player & Gun faces the mouse at all times
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= gameObject.transform.position.x)
        {
            spriteRenderer.flipX = false;
            gun.transform.localPosition = new Vector3(1, 0, 0);
        } 
        else
        {
            spriteRenderer.flipX = true;
            gun.transform.localPosition = new Vector3(-1, 0, 0);
        }

        //Rotate Bullet Exit toward the cursor
        mouse_pos = Input.mousePosition;
        mouse_pos.z = -10; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(gun.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Primary Button
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
        
        // Secondary Button
        if (Input.GetMouseButtonDown(1)) 
        {

        }

        // Interact Button 'E'
        if (Input.GetKeyDown(KeyCode.E))
        {
            portal.teleport();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal"))
        {
            portal = collision.GetComponent<LevelLoader>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal"))
        {
            portal = null;
        }
    }

    private void LateUpdate()
    {
        // Movement

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    private void Shoot()
    {
        Quaternion direction = Quaternion.Euler(new Vector3(0, 0, angle));

        Instantiate(Bullet, gunTip.position, direction);
    }
}
