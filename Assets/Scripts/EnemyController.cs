using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    protected Enemy enemy;

    public virtual void SetEnemy(Enemy enemy)
    {
        this.enemy = enemy;
        enemy.OnDestroyEnemy += Enemy_OnDestroyEnemy;
    }

    private void Enemy_OnDestroyEnemy(Enemy enemy)
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            collision.gameObject.GetComponent<BulletController>().bullet.Destroy();
            enemy.Destroy();
        }
        if (collision.tag == "Laser")
        {
            enemy.Destroy();
        }
        if (collision.tag == "Ship")
        {
            GameController.Instance.GameOver();
        }
    }

    void Update()
    {
        transform.localPosition = enemy.Position;
        transform.localRotation = Quaternion.Euler(0, 0, enemy.Rotation * 180 / Mathf.PI);
    }
}
