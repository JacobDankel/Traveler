using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        gameObject.transform.position = new Vector3 (player.transform.position.x, 0, -10);
    }
}
