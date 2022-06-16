using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Bullet bullet;
    public void SetBullet(Bullet bullet)
    {
        this.bullet = bullet;
        bullet.OnDestroyUI += Bullet_OnDestroy;
    }

    private void Bullet_OnDestroy(Bullet bullet)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = bullet.Position;
        transform.localRotation = Quaternion.Euler(0, 0, bullet.Rotation * 180 / Mathf.PI);
    }
}
