using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, ITarget
{
    Collider targetCollider;
    Renderer targetRend;
    Renderer[] targetChildRend;
    Collider[] targetChildColllider;
    public int targetHealth;
    // Start is called before the first frame update
    void Start()
    {
        targetRend = GetComponent<Renderer>();
        targetCollider = GetComponent<Collider>();
        targetChildRend = GetComponentsInChildren<Renderer>();
        targetChildColllider = GetComponentsInChildren<Collider>();

        targetHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Heal(); 
    }

    public void Heal() // Hedefin canini yeniler
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            targetHealth = 100;
            Debug.Log("Target Health :" + targetHealth);
            targetRend.enabled = true; // Hedefi gorunur hale getirir.
            targetCollider.enabled = true; // Hedefin collider'ini aktif hale getirir.
            foreach (Collider c in targetChildColllider)
            {
                c.enabled = true;
            }
            foreach (Renderer r in targetChildRend)
            {
                r.enabled = true;
            }
        }

        if (targetHealth <= 0) // Hedefin cani sifirin altina inerse
        {
            if(targetRend.enabled == true)
            {
                targetRend.enabled = false; // Hedefi gorunmez hale getirir
                targetCollider.enabled = false; // Hedefin collider'ini pasif hale getirir
                foreach (Collider c in targetChildColllider)
                {
                    c.enabled = false;
                }
                foreach(Renderer r in targetChildRend)
                {
                    r.enabled = false;
                }
                Debug.Log("Target destroyed");
            }
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ak47Bullet")
        {
            targetHealth -= 5;
            Debug.Log("Target Health :" + targetHealth);
        }
        if (col.gameObject.tag == "DeagleBullet")
        {
            targetHealth -= 40;
            Debug.Log("Target Health :" + targetHealth);
        }
    }

}
