using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public Weapon DefaultWeaponPrefab;
    public Weapon ActiveWeapon;
    Transform _t;

    private void Awake()
    {
        _t = GetComponent<Transform>();
    }

    void Start()
    {
        if (DefaultWeaponPrefab == null)
        {
            Debug.LogWarning("Default weapon for " + name + " was not set!");
        } else
        {
            ChangeWeapon(DefaultWeaponPrefab);
        }
    }

    public void ChangeWeapon(Weapon weaponPrefab)
    {
        if(ActiveWeapon != null)
        {
            ActiveWeapon.DeactivateWeapon();
        }

        if (weaponPrefab != null)
        {
            ActiveWeapon = Instantiate<Weapon>(weaponPrefab, _t.position, _t.rotation, _t);
            ActiveWeapon.ActivateWeapon();
        }
    }
}
