using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float MoveSpeed = 10.0f;      // Units per second
    Transform _t;
    private void Awake()
    {
        _t = GetComponent<Transform>();
    }
    public void Move(Vector2 dir)
    {
        // Since we're not using physics or rigidbodies, we can just use Transform's Translate()
        _t.Translate(dir);
    }
    public void MoveForward()
    {
        MoveForwards(MoveSpeed);
    }
    public void MoveForwards(float speed)
    {
        Move(_t.right * speed * Time.deltaTime);
    }
    public void MoveTowards(Vector2 pos)
    {
        MoveTowards(pos, MoveSpeed * Time.deltaTime);
    }
    public void MoveTowards(Vector2 pos, float maxDistance)
    {
        _t.position = Vector2.MoveTowards(_t.position, pos, maxDistance);
    }
}
