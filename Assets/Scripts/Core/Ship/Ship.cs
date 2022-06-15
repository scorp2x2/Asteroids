using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MoveController, ITimeWarp
{
    public int CountLaser { get; private set; }

    public delegate void ShipShoot(Bullet bullet);
    public event ShipShoot OnShoot;

    public float TimeShootLaser { get; private set; }

    public Ship()
    {
        CountLaser = GlobalParametrs.MaxCountLaser;
        Position = new Vector2();
    }

    public void Rotate(float rotation)
    {
        Rotation -= GlobalParametrs.StepRotationSheep * rotation;

        if (Rotation < 0) Rotation += Mathf.PI * 2;
        else if (Rotation > Mathf.PI * 2) Rotation -= Mathf.PI * 2;
    }

    public void AddSpeed(float speed)
    {
        Speed += GlobalParametrs.StepUpSpeedSheep * speed;
        if (Speed < 0) Speed = 0;
        if (Speed > GlobalParametrs.MaxSpeedSheep) Speed = GlobalParametrs.MaxSpeedSheep;
    }

    public void SetSpeed(float speed)
    {
        Speed = speed;
    }

    public bool ShootGun()
    {
        OnShoot?.Invoke(new Bullet(BulletType.gun, this));
        return true;
    }

    public void AddLaser()
    {
        CountLaser++;
        if (CountLaser > GlobalParametrs.MaxCountLaser) CountLaser = GlobalParametrs.MaxCountLaser;
    }

    public bool IsFullLaser()
    {
        return CountLaser == GlobalParametrs.MaxCountLaser;
    }

    public bool ShootLaser()
    {
        if (CountLaser > 0)
        {
            if (IsFullLaser()) TimeShootLaser = GlobalParametrs.TimeReloadLaser;

            CountLaser--;
            OnShoot?.Invoke(new Bullet(BulletType.laser, this));

            return true;
        }
        return false;
    }

    public void AddTime(float time)
    {
        Move(time);

        AddSpeed(-time * GlobalParametrs.StepDownSpeedSheep);

        if (!IsFullLaser())
            TimeShootLaser -= time;
        if (TimeShootLaser < 0)
        {
            AddLaser();
            if (!IsFullLaser()) TimeShootLaser = GlobalParametrs.TimeReloadLaser;
        }
    }

}
