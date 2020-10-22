using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health;

    public Action DestroyInstance;


    // take damg on enemy collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 5;
            if (health <= 0)
            {
                if (DestroyInstance != null)
                    DestroyInstance();
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
            if (DestroyInstance != null)
                DestroyInstance();
        }
    }
}
