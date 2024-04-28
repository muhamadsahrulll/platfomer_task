using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damageAmount = 10;
    public float knockbackForce = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                // Kurangi darah player
                player.TakeDamage(damageAmount);

                // Terapkan knockback
                Vector2 knockbackDirection = (player.transform.position - transform.position).normalized;
                player.ApplyKnockback(knockbackDirection, knockbackForce);
            }
        }
    }
}
