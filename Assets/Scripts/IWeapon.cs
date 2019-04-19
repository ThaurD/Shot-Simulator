using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon 
{
    void Fire();
    void ReAmmo();
    void AmmoFilled();
    void CloneBullet();
}
