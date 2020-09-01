using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    private bool isEnable;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
    private void Shoot(Transform direction)
    {
        rb.AddForce(direction.forward * force);
    }
    private void OnEnable()
    {
        isEnable = true;
    }
    private void OnDisable()
    {
        isEnable = false;
    }
}
