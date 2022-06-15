using UnityEngine;

public abstract class MoveController
{
    /// <summary>
    /// Угол поврота в радианах
    /// </summary>
    public float Rotation { get; set; }
    public Vector2 Position { get; set; }
    public float Speed { get; set; }

    public virtual void Move(float time)
    {
        Vector2 vector = new Vector2(Mathf.Cos(Rotation), Mathf.Sin(Rotation));
        Position += vector * Speed * time;

        CheckBorderScreen();
    }

    public void CheckBorderScreen()
    {
        if (Position.x < -Screen.width / 2)
            Position = new Vector3(Screen.width / 2, Position.y);
        else if (Position.x > Screen.width / 2)
            Position = new Vector3(-Screen.width / 2, Position.y);

        if (Position.y < -Screen.height / 2)
            Position = new Vector3(Position.x, Screen.height / 2);
        else if (Position.y > Screen.height / 2)
            Position = new Vector3(Position.x, -Screen.height / 2);
    }
}