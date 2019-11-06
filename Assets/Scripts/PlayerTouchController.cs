using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectMover))]
public class PlayerTouchController : MonoBehaviour
{
    ObjectMover _mover;
    Transform _t;
    private void Awake()
    {
        _mover = GetComponent<ObjectMover>();
        _t = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        { 
            // Since MoveTowards() takes a Vector2, the z value is discarded and we don't have to worry about that
            Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x = Mathf.Clamp(targetPosition.x, -Screen.width / 2, 0);
            _mover.MoveTowards(targetPosition);     
        }
    }
}
