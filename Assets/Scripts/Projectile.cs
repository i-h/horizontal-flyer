using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectMover))]
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    ObjectMover _mover;
    Rigidbody2D _rb;
    float _spawnTime;
    public AnimationCurve ProjectileFlightPath = new AnimationCurve();

    private void Awake()
    {
        _spawnTime = Time.time;
        _mover = GetComponent<ObjectMover>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _mover.MoveForward();
    }

    public void Dispose()
    {
        Destroy(gameObject);
    }
}
