using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutsideScreen : MonoBehaviour
{
    Transform _t;
    Vector3 _screenPos = new Vector3();

    private void Awake()
    {
        _t = GetComponent<Transform>();
    }
    void LateUpdate()
    {
        _screenPos = Camera.main.WorldToScreenPoint(_t.position);

        if(_screenPos.x < 0 || _screenPos.x > Screen.width || _screenPos.y < 0 || _screenPos.y > Screen.height)
        {
            Destroy(gameObject);
        }
    }
}
