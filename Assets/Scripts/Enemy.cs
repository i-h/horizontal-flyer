﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectMover))]
public class Enemy : MonoBehaviour
{
    public int Health = 2;
    [Header("Curve: 0 = straight 1 = upwards -1 = downwards")]
    public AnimationCurve MovementPattern = new AnimationCurve();   // How to modify y value during movement
    public float MovementPatternStrength = 2.0f;                    // What factor to use for the animation curve value
    public float MovementPatternDuration = 1.0f;                    // How many seconds to go through the animation curve

    ObjectMover _mover;
    Transform _t;

    float _startTime;
    int _score;

    float _movementSyncBreak;

    private void Awake()
    {
        _mover = GetComponent<ObjectMover>();
        _t = GetComponent<Transform>();

        _startTime = Time.timeSinceLevelLoad;
        _score = Health;
        _movementSyncBreak = Random.Range(0.9f, 1.2f);
    }

    private void FixedUpdate()
    {
        // Might get heavy with a lot of enemies
        float patternRotation = MovementPattern.Evaluate((Time.timeSinceLevelLoad - _startTime)/MovementPatternDuration*_movementSyncBreak)*MovementPatternStrength;
        _mover.MoveForward();
        _mover.SetRotation(patternRotation);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "PlayerBullet")
        {
            TakeDamage();
            Projectile p = c.GetComponent<Projectile>();
            if (p != null) p.Dispose();
        }

    }
    void TakeDamage()
    {
        Health--;
        if (Health <= 0) Die();
    }

    public void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        GameSession.Instance.GainScore(_score);
        StartCoroutine(FadeOut());
    }

    public void OutOfBounds()
    {
        Destroy(gameObject);
    }

    IEnumerator FadeOut()
    {
        float duration = 2.0f; // Hardcoding this duration in here in lack of coherent animation system
        float startTime = Time.timeSinceLevelLoad;
        Renderer r = GetComponentInChildren<Renderer>();
        Color invis = r.material.color;
        invis.a = 0;
        r.material.color = Color.white;

        while (r.material.color.a > 0 )
        {
            r.material.color = Color.Lerp(r.material.color, invis, (Time.timeSinceLevelLoad - startTime)/duration);
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }
}
