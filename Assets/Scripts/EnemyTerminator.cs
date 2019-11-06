using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerminator : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null) enemy.OutOfBounds();
            GameSession.Instance.TakePlayerHit();
        }
    }
}
