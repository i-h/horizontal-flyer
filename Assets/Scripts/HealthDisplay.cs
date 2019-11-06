using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthDisplay : MonoBehaviour
{
    Image _img;
    private void Awake()
    {
        _img = GetComponent<Image>();
    }
    
    void FixedUpdate()
    {
        float health = GameSession.Instance.GetLives() / (float) GameSession.Instance.MaxLives;
        _img.fillAmount = health;
    }
}
