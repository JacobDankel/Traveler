using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //Components
    [SerializeField]
    private Rigidbody2D rb;
    private CircleCollider2D col;

    //Bullet Params
    public float bulSpd;
    private float delay;
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float angle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        bulSpd *= 100;
        delay = 2;

        mouse_pos = Input.mousePosition;
        mouse_pos.z = -10;
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        //Relative force added since bullet is rotated toward mouse
        rb.AddRelativeForce(new Vector2(1 * bulSpd, 1));

        Destroy(gameObject, delay);
    }
}
