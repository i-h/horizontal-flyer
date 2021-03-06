﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : IWeapon
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
        if (AutoFire && Time.timeSinceLevelLoad - _lastFire > FireDelay)
        {
            Fire();
            _lastFire = Time.timeSinceLevelLoad;
        }
    }

    public override void ActivateWeapon()
    {
        // TODO: For activation effects and setup
        Debug.Log("Weapon " + name + " activated!");
    }

    public override void Fire()
    {
        if(BulletPrefab == null)
        {
            Debug.LogWarning("Projectile prefab for " + name + " is empty!");
            return;
        }

        // TODO: Could do pooling here, but in this prototype it's not necessary
        Projectile bulletInstance = Instantiate<Projectile>(BulletPrefab, _t.position, _t.rotation);
    }

    public override void DeactivateWeapon()
    {
        // TODO: For deactivation effects and stowing procedure
        Debug.Log("Weapon " + name + " deactivated.");
    }
}
