using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    public string zoneNum;

    public GameObject player;

    public EnemyScript[] enemies;

    public BossScript boss;

    private bool isBoss = false;
    public string getZoneNum()
    {
        return zoneNum; 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for(int i = 0; i < enemies.Length; i++)
            {
                enemies[i].setTarget(player.transform);
            }
            if (isBoss)
            {
                boss.setTarget(player);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].setTarget(null);
            }
        }
    }

    private void Awake()
    {
        if (zoneNum == "4")
        {
            isBoss = true;
        }
    }
}
