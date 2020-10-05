﻿using System.Collections;
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

    


    // delegate subscription
    private void OnEnable()
    {
        GameManager.onEnemySpawn += spawnEnemy;
    }

    private void OnDisable()
    {
        GameManager.onEnemySpawn -= spawnEnemy;
    }

    

    Vector3 RandomCircle(int i)
    {
        float angle = AngleOffset * i;
        Vector3 pos = Vector3.zero;
        pos.x = centre.position.x + spawnRadius * Mathf.Sin(angle);
        pos.z = centre.position.z + spawnRadius * Mathf.Cos(angle);
        return pos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(centre.position, spawnRadius);
    }

    public void spawnEnemy()
    {
        AngleOffset = 360 / enemiesToSpawn;
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 spawnPos = RandomCircle(i);
            spawnPos.y = enemyPrefab.transform.position.y;
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            enemy.GetComponent<Enemy>().setTarget(centre);
        }
    }
}
