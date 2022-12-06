using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGuardScript : EnemyScript
{
    private void Awake()
    {
        target = FindObjectOfType<PlayerController>().GetComponent<Transform>();
        score = 10;
    }
}
