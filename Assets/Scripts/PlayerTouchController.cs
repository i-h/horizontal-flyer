using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMover))]
public class PlayerTouchController : MonoBehaviour
{
    CharacterMover _mover;
    Transform _t;
    private void Awake()
    {
        _mover = GetComponent<CharacterMover>();
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
