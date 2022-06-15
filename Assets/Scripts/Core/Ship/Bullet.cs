using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class Bullet : MoveController, ITimeWarp
{
    public delegate void DestroyBullet(Bullet bullet);
    public event DestroyBullet OnDestroy;

    public BulletType bulletType;

    public Bullet(BulletType bulletType, MoveController moveController)
    {
        this.bulletType = bulletType;
        Speed = bulletType == BulletType.gun ? GlobalParametrs.SpeedGun : GlobalParametrs.SpeedLaser;
        Position = moveController.Position;
        Rotation = moveController.Rotation;
    }

    public void AddTime(float time)
    {
        Vector2 vector = new Vector2(Mathf.Cos(Rotation), Mathf.Sin(Rotation));
        Position += vector * Speed * time;

        if (Position.x < -Screen.width / 2)
            Destroy();
        else if (Position.x > Screen.width / 2)
            Destroy();

        if (Position.y < -Screen.height / 2)
            Destroy();
        else if (Position.y > Screen.height / 2)
            Destroy();
    }

    public void Destroy()
    {
        OnDestroy?.Invoke(this);
    }
}

public enum BulletType
{
    gun,
    laser
}

