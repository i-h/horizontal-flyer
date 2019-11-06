using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObjectMover : MonoBehaviour
{
    public float MoveSpeed = 10.0f;      // Units per second
    Transform _t;
    Rigidbody2D _rb;
    private void Awake()
    {
        _t = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
    }
    public void MoveRaw(Vector2 dir)
    {
        _rb.MovePosition((Vector2)_t.position + dir);
    }

    public void Move(Vector2 dir)
    {
        MoveRaw(dir.normalized * MoveSpeed * Time.deltaTime);
    }
    public void MoveTowards(Vector2 pos, float maxDistance)
    {
        _rb.MovePosition(Vector2.MoveTowards(_t.position, pos, maxDistance));
    }

    public void MoveForward()
    {
        MoveForward(MoveSpeed);
    }
    public void MoveForward(float speed)
    {
        MoveRaw(_t.right * speed * Time.deltaTime);
    }
    public void MoveTowards(Vector2 pos)
    {
        MoveTowards(pos, MoveSpeed * Time.deltaTime);
    }

    public void SetRotation(float patternRotation)
    {
        Vector3 rot = _t.localEulerAngles;
        rot.z = patternRotation;
        _t.localEulerAngles = rot;
    }
}
