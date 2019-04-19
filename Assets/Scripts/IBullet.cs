using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    void BulletMovement();
    void OnCollisionEnter(Collision col);
}
