using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField]
    protected float range;
    [SerializeField]
    protected string owner;
    [SerializeField]
    protected float fireRate;
    protected float fireCount;
    public string Owner { get => owner; }
    public float Range { get => range; }
    public abstract void Shoot();
}
