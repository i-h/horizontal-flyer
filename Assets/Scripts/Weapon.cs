using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Projectile BulletPrefab;
    public bool AutoFire = true;
    public float FireDelay = 0.25f;

    Transform _t;
    float _lastFire = -1;

    private void Awake()
    {
        _t = GetComponent<Transform>();
    }

    void Update()
    {
        if (AutoFire && Time.time - _lastFire > FireDelay)
        {
            Fire();
            _lastFire = Time.time;
        }
    }

    public void ActivateWeapon()
    {
        // TODO: For activation effects and setup
        Debug.Log("Weapon " + name + " activated!");
    }

    public void Fire()
    {
        if(BulletPrefab == null)
        {
            Debug.LogWarning("Projectile prefab for " + name + " is empty!");
            return;
        }

        // TODO: Could do pooling here, but in this prototype it's not necessary
        Projectile bulletInstance = Instantiate<Projectile>(BulletPrefab, _t.position, _t.rotation);
    }

    public void DeactivateWeapon()
    {
        // TODO: For deactivation effects and stowing procedure
        Debug.Log("Weapon " + name + " deactivated.");
    }
}
