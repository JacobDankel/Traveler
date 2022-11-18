using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public bool open = false;
    public GameObject collapseWall;

    public void destroyWall()
    {
        Destroy(collapseWall);
    }
}
