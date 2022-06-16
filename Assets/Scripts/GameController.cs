using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool IsGameOver;

    public Core core;
    public ShipController shipController;

    public Transform panelBullets;
    public GameObject bulletPrefub;
    public GameObject laserPrefub;

    public GameOverPanel gameOverPanel;
    public EnemysController enemysController;
    void Start()
    {
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        core.AddTime(Time.deltaTime);
    }

    public void NewGame()
    {
        if (core != null)
        {
            core.Spawner.Clear();
            core.ClearBullets();
        }
        core = new Core();
        shipController.StartGame(core.Ship);
        core.Spawner.IsSpawn = true;
        core.Ship.OnShoot += CreateBullet;

        core.Spawner.OnSpawnEnemy += enemysController.SpawnerAsteroids_OnSpawnEnemy;
        IsGameOver = false;
    }

    public void CreateBullet(Bullet bullet)
    {
        switch (bullet.bulletType)
        {
            case BulletType.gun:
                Instantiate(bulletPrefub, bullet.Position, Quaternion.Euler(0, 0, bullet.Rotation * 180 / Mathf.PI), panelBullets).GetComponent<BulletController>().SetBullet(bullet);
                break;
            case BulletType.laser:
                Instantiate(laserPrefub, bullet.Position, Quaternion.Euler(0, 0, bullet.Rotation * 180 / Mathf.PI), panelBullets).GetComponent<BulletController>().SetBullet(bullet);
                break;
            default:
                Debug.LogError("Такого патрона не существует");
                break;
        }
    }

    public void GameOver()
    {
        core.Spawner.IsSpawn = false;
        core.Ship.SetSpeed(0);
        gameOverPanel.Show();
        IsGameOver = true;
    }
}
