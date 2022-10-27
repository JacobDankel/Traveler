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

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        bulSpd *= 100;
        delay = 2;


        Debug.Log(transform.rotation.z + ", " + transform.rotation.w);
        rb.AddForce(new Vector2(transform.rotation.z * bulSpd * Time.deltaTime, transform.rotation.w * bulSpd * Time.deltaTime));

        Destroy(gameObject, delay);
    }
}
