using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Components
    public BoxCollider2D col;
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;

    //Movement
    [Space]
    public float speed;

    //Shooting
    public GameObject Bullet;
    private Vector3 mouse_pos;
    public Transform gun;
    private Vector3 object_pos;
    private float angle;
    

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed *= 0.01f;                                     // Scales the movement to a more manageable amount     x * 0.01f = x
    }



    // Update is called once per frame
    void Update()
    {
        // Player & Gun faces the mouse at all times
        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= gameObject.transform.position.x)
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

        if (Input.GetMouseButtonDown(0)) // Primary Button
        {
            Shoot();
        }

        if (Input.GetMouseButtonDown(1)) // Secondary Button
        {

        }

    }

    private void LateUpdate()
    {
        // Movement

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
    }

    private void Shoot()
    {
        Quaternion direction = Quaternion.Euler(new Vector3(0, 0, angle));

        Instantiate(Bullet, gun.position, direction);
    }
}