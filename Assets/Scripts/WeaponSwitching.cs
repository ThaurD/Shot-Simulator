using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour, IWeaponSwitching
{
    public GameObject[] weapons;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SwitchWeapon();
    }

    public void SwitchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (weapons[0].active == false)
            {
                weapons[0].SetActive(true);
                weapons[1].SetActive(false);
            }
            else
            {
                weapons[1].SetActive(true);
                weapons[0].SetActive(false);
            }

        }
    }
}
