using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 2;

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

    void Die()
    {
        Debug.Log(name + " dies!");
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float duration = 2.0f; // Hardcoding this duration in here in lack of coherent animation system
        float startTime = Time.time;
        Renderer r = GetComponentInChildren<Renderer>();
        Color invis = r.material.color;
        invis.a = 0;

        while (r.material.color.a > 0 )
        {
            r.material.color = Color.Lerp(r.material.color, invis, (Time.time - startTime)/duration);
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }
}
