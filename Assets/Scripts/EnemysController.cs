using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysController : MonoBehaviour
{
    public Transform panelEnemys;
    public GameObject asteroidPrefub;
    public GameObject saucerPrefub;

    public void SpawnerAsteroids_OnSpawnEnemy(Enemy enemy)
    {
        if(enemy.GetType() == typeof(Asteroid))
        {
            Instantiate(asteroidPrefub, enemy.Position, new Quaternion(), panelEnemys).GetComponent<AsteroidController>().SetEnemy(enemy);
        }
        else if (enemy.GetType() == typeof(Saucer))
        {
            Instantiate(saucerPrefub, enemy.Position, new Quaternion(), panelEnemys).GetComponent<SaucerController>().SetEnemy(enemy);
        }
    }
}
