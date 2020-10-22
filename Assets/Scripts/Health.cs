using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 5;
            if (health <= 0)
            {
                Destroy(transform.gameObject);
                // aqui muere el jugador/enemigo
            }
        }
    }

    public void TakeDamage(float amount)
    {
        if (health > 0)
        {
            health = health - amount;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
