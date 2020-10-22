using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int dmg;
    private Rigidbody rb;
    public float speed;
    public Pooling pool;
    // Start is called before the first frame update
    void Awake()
    {
        print("Start");
        rb = transform.GetComponent<Rigidbody>();
    }
    private void Shoot()
    {
        print("bullet vel before reset: " + rb.velocity);
        rb.velocity = Vector3.zero;
        print("bullet vel after reset: " + rb.velocity);
        rb.velocity = (transform.forward * speed);
        print("bullet vel after force: " + rb.velocity);
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Colision: " + collision.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Health hp = collision.gameObject.GetComponent<Health>();
            hp.TakeDamage(dmg);
        }
        //after he did everything disable the obj
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Gun") && !collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            enabled = false;
        }
    }
    private void OnEnable()
    {
        Shoot();
    }
}
