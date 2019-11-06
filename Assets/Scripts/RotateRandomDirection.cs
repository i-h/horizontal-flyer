using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRandomDirection : MonoBehaviour
{
    public float RotationSpeed = 3.0f;
    Vector3 _direction;
    Transform _t;

    private void Awake()
    {
        _direction = Random.onUnitSphere;
        _t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _t.Rotate(_direction*RotationSpeed);
    }
}
