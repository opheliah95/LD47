using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int interval = 10; // called every 10 frame

    // list of parameters to add difficulty
    public float speedBoost = 1.2f;
    public int enemyIncrease = 3;
    public float radiusBoost = 1.2f;

    // delegate for spawning enemy
    public delegate void SpawnEnemyDelegate();
    public static SpawnEnemyDelegate onEnemySpawn;

    // delegate for update UI
    public delegate void UpdateLifeDelegate(int life);
    public static UpdateLifeDelegate onLifeChange;

    bool initialSpawn = true;

    void Update()
    {
        if (Time.frameCount % interval == 0)
        {
            if (enemyCounter() == 0)
            {
                if (initialSpawn)
                {
                    FindObjectOfType<EnemySpawner>().LevelDifficulty();
                    initialSpawn = false;
                }
                else
                {
                    FindObjectOfType<EnemySpawner>().LevelDifficulty(enemyIncrease, speedBoost, radiusBoost);
                }

                onEnemySpawn();
            }
        }
       
    }

    public int enemyCounter()
    {
        return FindObjectsOfType(typeof(Enemy)).Length;
    }
}
