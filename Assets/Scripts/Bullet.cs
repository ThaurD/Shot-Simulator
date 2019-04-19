using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour, IBullet
{
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5f);
        bulletSpeed = 50;
    }

    // Update is called once per frame
    void Update()
    {
        BulletMovement();
    }

    public abstract void BulletMovement();

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "target") // veya bellirli bir sure sonra mermiyi yok et!!!!
        {
            Destroy(this.gameObject);
        }
    }
}
