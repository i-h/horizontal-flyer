using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectMover))]
public class PlayerTouchController : MonoBehaviour
{
    ObjectMover _mover;
    Transform _t;

    WeaponSlot[] _weapons;

    private void Awake()
    {
        _mover = GetComponent<ObjectMover>();
        _t = GetComponent<Transform>();
        _weapons = GetComponentsInChildren<WeaponSlot>();
    }

    private void Start()
    {
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            // Since MoveTowards() takes a Vector2, the z value is discarded and we don't have to worry about that
            Vector2 mousePos = Input.mousePosition;

#if UNITY_ANDROID && !UNITY_EDITOR
            mousePos = Input.touchCount > 0 ? Input.GetTouch(0).position : mousePos;
#endif
            Vector2 targetPosition = Camera.main.ScreenToWorldPoint(mousePos);
            targetPosition.x = Mathf.Clamp(targetPosition.x, -Screen.width / 2, 0);
            _mover.MoveTowards(targetPosition);     
        }
    }
    private void Update()
    {
        // Fire all weapons
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Firing manually");
            foreach (WeaponSlot wpn in _weapons) wpn.Fire();
        }
#elif UNITY_ANDROID
        if (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Began)
        {
            Debug.Log("Firing manually");
            foreach (WeaponSlot wpn in _weapons) wpn.Fire();
        }
#endif
    }
}
