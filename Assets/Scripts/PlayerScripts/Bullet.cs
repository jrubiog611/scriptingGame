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
    private string owner;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Setup(string _owner)
    {
        owner = _owner;
    }
    private void Shoot()
    {
        rb.velocity = Vector3.zero;
        rb.velocity = (transform.forward * speed);
    }

    public void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Colision: " + collision.name);
        //after he did everything disable the obj
        if (!collision.gameObject.CompareTag(owner) && !collision.gameObject.CompareTag("Gun") && !collision.gameObject.CompareTag("Bullet"))
        {
            if (collision.GetComponent<Health>() != null)
            {
                Health hp = collision.gameObject.GetComponent<Health>();
                hp.TakeDamage(dmg);
            }
            gameObject.SetActive(false);
            enabled = false;
        }
    }
    public void OnEnable()
    {
        Shoot();
    }
}
