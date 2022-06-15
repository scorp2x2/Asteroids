using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Enemy
{
    public int Level { get; set; }

    public delegate void SpawnAsteroid(int lvl, Vector2 position);
    public event SpawnAsteroid OnSpawnAsteroid;

    public Asteroid(int lvl, Vector2 position)
    {
        if (lvl > 2)
        {
            Debug.LogError("Таких астероидов не существует!");
            return;
        }

        Position = position;
        Level = lvl;
        Speed = GlobalParametrs.SpeedAsteroid * (Level + 1);

        Score = GlobalParametrs.ScoreAsteroid*(Level + 1);
        Rotation = Random.Range(0, Mathf.PI * 2);
    }

    public override void Destroy()
    {
        if (Level != 2)
            for (int i = 0; i < 2; i++)
                OnSpawnAsteroid?.Invoke(Level + 1, Position);

        base.Destroy();
    }
}
