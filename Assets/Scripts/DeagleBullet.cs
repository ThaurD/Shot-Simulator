using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeagleBullet : Bullet
{
    public override void BulletMovement()
    {
        transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
    }
}
