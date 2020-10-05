using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int interval = 10; // called every 10 frame
    // delegate for spawning enemy
    public delegate void SpawnEnemyDelegate();
    public static SpawnEnemyDelegate onEnemySpawn;

    void Update()
    {
        if (Time.frameCount % interval == 0)
        {
            if (enemyCounter() == 0)
            {
                onEnemySpawn();
            }
        }
       
    }

    public int enemyCounter()
    {
        return FindObjectsOfType(typeof(Enemy)).Length;
    }
}
