using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public IWeapon DefaultWeaponPrefab;
    public IWeapon ActiveWeapon;
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

    public void ChangeWeapon(IWeapon weaponPrefab)
    {
        if(ActiveWeapon != null)
        {
            ActiveWeapon.DeactivateWeapon();
        }

        if (weaponPrefab != null)
        {
            ActiveWeapon = Instantiate<IWeapon>(weaponPrefab, _t.position, _t.rotation, _t);
            ActiveWeapon.ActivateWeapon();
        }
    }

    public void Fire()
    {
        if(ActiveWeapon != null) ActiveWeapon.Fire();
    }
}
