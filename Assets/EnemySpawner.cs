using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRadius = 10;
    public float AngleOffset;
    public float offset = 30f;
    public int enemiesToSpawn = 5;
    public GameObject enemyPrefab;
    public Transform centre;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 spawnPos = RandomCircle(i);
            spawnPos.y = enemyPrefab.transform.position.y;
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            enemy.GetComponent<Enemy>().setTarget(centre);
        }

    }


    Vector3 RandomCircle(int i)
    {
        float angle = AngleOffset * i;
        Vector3 pos = Vector3.zero;
        pos.x = centre.position.x + spawnRadius * Mathf.Sin(angle) + offset;
        pos.z = centre.position.z + spawnRadius * Mathf.Cos(angle) + offset;
        return pos;
    }
}
