using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47Bullet : Bullet
{
    public override void BulletMovement()
    {
        transform.Translate(0, 0, bulletSpeed * Time.deltaTime);
    }
}
