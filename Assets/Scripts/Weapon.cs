using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    public GameObject bulletPrefab;
    public Transform bulletPoint; // Merminin cikis noktasi

    public int BulletPerMinutes { get; set; }
    public string ShotType { get; set; }
    public int Ammo { get; set; }
    public int Accuracy { get; set; }
    public int BulletDamage { get; set; }
    public int AmmoChangeTime { get; set; }

    public float TimeForBullet { get; set; }
    public float TimeForAmmo { get; set; }
    public bool AmmoStatus { get; set; }
    
    public abstract void Fire();
    public abstract void ReAmmo();
    public abstract void AmmoFilled();
    public abstract void CloneBullet();

}
