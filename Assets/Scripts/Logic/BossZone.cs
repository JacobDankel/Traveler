using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZone : MonoBehaviour
{
    public GameObject boss;
    public GameObject[] spawners;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boss.SetActive(true);
            for(int i = 0; i < spawners.Length; i++)
            {
                spawners[i].SetActive(true);
            }
        }
    }
}
