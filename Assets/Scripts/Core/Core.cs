using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Core : ITimeWarp
{
    public Ship Ship { get; private set; }
    public Spawner Spawner { get; private set; }

    public List<Bullet> Bullets;

    public int gameScore;

    public Core()
    {
        gameScore = 0;
        Ship = new Ship();
        Spawner = new Spawner(Ship);
        Spawner.OnAddScore += AddScore;

        Bullets = new List<Bullet>();
        Ship.OnShoot += Ship_OnShoot;
    }

    private void Ship_OnShoot(Bullet bullet)
    {
        Bullets.Add(bullet);
        bullet.OnClear += (bullet) => Bullets.Remove(bullet);
    }

    public void AddTime(float time)
    {
        Ship.AddTime(time);
        Spawner.AddTime(time);

        for (int i = 0; i < Bullets.Count; i++)
            Bullets[i].AddTime(time);
    }

    public void ClearBullets()
    {
        foreach (var item in Bullets)
            item.Clear();
        Bullets.Clear();
    }

    public void AddScore(int score)
    {
        gameScore += score;
    }
}