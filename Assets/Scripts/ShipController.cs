using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    Ship ship;

    public void StartGame(Ship ship)
    {
        this.ship = ship;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, ship.Rotation * 180 / Mathf.PI);
        transform.localPosition = ship.Position;
    }
}
