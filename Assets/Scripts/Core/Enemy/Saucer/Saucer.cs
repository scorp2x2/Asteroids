using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saucer : Enemy
{
    readonly MoveController positionShip;
    public Saucer(Vector2 position, MoveController positionShip)
    {
        Position = position;
        this.positionShip = positionShip;
        Speed = GlobalParametrs.SpeedSaucer;

        Score = GlobalParametrs.ScoreSaucer;
    }

    public override void Move(float time)
    {
        var v = positionShip.Position - Position;
        var vector = v / v.magnitude;

        Position += vector * Speed * time;

        CheckBorderScreen();
    }
}
