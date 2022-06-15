using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Enemy : MoveController, ITimeWarp
{
    public delegate void DestroyEnemy(Enemy enemy);
    public event DestroyEnemy OnDestroyEnemy;

    public int Score { get; protected set; }

    public void AddTime(float time)
    {
        Move(time);
    }

    public virtual void Destroy()
    {
        OnDestroyEnemy?.Invoke(this);
    }
}
