using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyMovement>().spriteRenderer.flipX = !collision.gameObject.GetComponent<EnemyMovement>().spriteRenderer.flipX;
        }
    }
}
