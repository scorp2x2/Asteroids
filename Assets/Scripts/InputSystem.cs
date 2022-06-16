using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public GameController gameController;

    float speedRotation;
    float speedMove;

    // Update is called once per frame
    void Update()
    {
        if (gameController.IsGameOver) return;

        Rotate(speedRotation);
        Move(speedMove);
    }

    public void OnRotate(InputValue input)
    {
        speedRotation = input.Get<Vector2>().x;
    }

    public void OnMove(InputValue input)
    {
        speedMove = input.Get<float>();
    }

    void Rotate(float rotate)
    {
        gameController.core.Ship.Rotate(rotate*Time.deltaTime);
    }

    void Move(float speed)
    {
        gameController.core.Ship.AddSpeed(speed * Time.deltaTime);
    }

    void OnShootGun()
    {
        gameController.core.Ship.ShootGun();
    }

    void OnShootLaser()
    {
        gameController.core.Ship.ShootLaser();
    }
}
