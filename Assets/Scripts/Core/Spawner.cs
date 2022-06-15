using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Spawner : ITimeWarp
{
    public bool IsSpawn { get; set; }

    float timeForSpawn;

    public List<Enemy> Enemies;
    public Ship ship;

    public delegate void SpawnEnemy(Enemy enemy);
    public event SpawnEnemy OnSpawnEnemy;

    public delegate void AddScore(int score);
    public event AddScore OnAddScore;

    public Spawner(Ship ship)
    {
        this.ship = ship;
        Enemies = new List<Enemy>();
    }

    public void AddTime(float time)
    {
        timeForSpawn -= time;
        if (timeForSpawn < 0 && IsSpawn)
            Spawn();

        foreach (var item in Enemies)
            item.AddTime(time);
    }

    void Spawn()
    {
        if (Enemies.Count < GlobalParametrs.MaxCountEnemy)
        {
            var wall = Random.Range(0, 4);
            Vector3 pos = new Vector3();
            switch (wall)
            {
                case 0: //Верхняя
                    pos = new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), Screen.height / 2, 0);
                    break;
                case 1: //Правая
                    pos = new Vector3(Screen.width / 2, Random.Range(-Screen.width / 2, Screen.width / 2), 0);
                    break;
                case 2: //Нижняя
                    pos = new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2), -Screen.height / 2, 0);
                    break;
                case 3: //Левая
                    pos = new Vector3(Screen.width / 2, Random.Range(-Screen.width / 2, -Screen.width / 2), 0);
                    break;
                default:
                    break;
            }

            if (Random.Range(0, 30) == 0)
                SpawnSaucer(pos);
            else
                SpawnAsteroid(Random.Range(0, 3), pos);

            timeForSpawn = Random.Range(1f, 3f);
        }
    }

    public void Clear()
    {
        while (Enemies.Count != 0)
            Enemies[0].Destroy();
    }

    public void SpawnAsteroid(int lvl, Vector2 position)
    {
        var enemy = new Asteroid(lvl, position);
        enemy.OnSpawnAsteroid += SpawnAsteroid;
        enemy.OnDestroyEnemy += Enemy_OnDestroyEnemy;
        Enemies.Add(enemy);
        OnSpawnEnemy?.Invoke(enemy);
    }

    private void Enemy_OnDestroyEnemy(Enemy enemy)
    {
        OnAddScore(enemy.Score);
        Enemies.Remove(enemy);
    }

    public void SpawnSaucer(Vector2 position)
    {
        var enemy = new Saucer(position, ship);
        enemy.OnDestroyEnemy += Enemy_OnDestroyEnemy;
        Enemies.Add(enemy);
        OnSpawnEnemy?.Invoke(enemy);
    }
}

