using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    public string zoneNum;

    public GameObject player;

    public EnemyScript[] enemies;

    public string getZoneNum()
    {
        return zoneNum; 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player in Zone " + zoneNum);
            for(int i = 0; i < enemies.Length; i++)
            {
                enemies[i].setTarget(player);
            }
        }
    }
}