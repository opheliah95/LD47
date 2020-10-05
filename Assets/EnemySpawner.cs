using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRadius = 10;
    public float offset = 30f;
    public int enemiesToSpawn = 5;
    public GameObject enemyPrefab;
    public Transform centre;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 spawnPos = RandomCircle();
            //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, centre.position - spawnPos);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }

    }


    Vector3 RandomCircle()
    {
        float angle = Random.value * 360;
        Vector3 pos = Vector3.zero;
        pos.x = centre.position.x + spawnRadius * Mathf.Sin(angle * Mathf.Deg2Rad) + offset;
        pos.z = centre.position.z + spawnRadius * Mathf.Sin(angle * Mathf.Deg2Rad) + offset;
        return pos;
    }
}
