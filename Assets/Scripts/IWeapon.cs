using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeapon : MonoBehaviour
{
    public abstract void Fire();
    public abstract void ActivateWeapon();
    public abstract void DeactivateWeapon();
}
