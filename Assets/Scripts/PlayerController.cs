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
        // Player faces the mouse at all times
        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= gameObject.transform.position.x)
        {
            spriteRenderer.flipX = false;
        } 
        else
        {
            spriteRenderer.flipX = true;
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
}
