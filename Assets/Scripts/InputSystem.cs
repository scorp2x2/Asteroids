using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public float speedRotation;
    public float speedMove;

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.IsGameOver) return;

        if (Input.GetKey(KeyCode.A))
            Rotate(-speedRotation);
        if (Input.GetKey(KeyCode.D))
            Rotate(speedRotation);
        if (Input.GetKey(KeyCode.W))
            Move(speedMove);
        if (Input.GetKeyDown(KeyCode.Space))
            ShootGun();
        if (Input.GetKeyDown(KeyCode.F))
            ShootLaser();
    }

    void Rotate(float rotate)
    {
        GameController.Instance.core.Ship.Rotate(rotate*Time.deltaTime);
    }

    void Move(float speed)
    {
        GameController.Instance.core.Ship.AddSpeed(speed * Time.deltaTime);
    }

    void ShootGun()
    {
        GameController.Instance.core.Ship.ShootGun();
    }

    void ShootLaser()
    {
        GameController.Instance.core.Ship.ShootLaser();
    }
}
