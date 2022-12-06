using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{

    public bool canSpawn = true;

    public GameObject enemy;

    private void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(spawnEnemy());
        }
    }

    IEnumerator spawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);

        canSpawn = false;

        yield return new WaitForSecondsRealtime(5);

        canSpawn = true;
    }
}
