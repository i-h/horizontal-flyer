using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectMover))]
public class Projectile : MonoBehaviour
{
    ObjectMover _mover;
    public AnimationCurve ProjectileFlightPath = new AnimationCurve();

    private void Awake()
    {
        _mover = GetComponent<ObjectMover>();
    }

    // Update is called once per frame
    void Update()
    {
        _mover.MoveForward();


    }
}
