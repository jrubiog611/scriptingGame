﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class Pooling : MonoBehaviour
{
    public Action OnShoot;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private List<GameObject> pool = new List<GameObject>();
    void Start()
    {
        OnShoot += CreateBullet;
    }

    private void CreateBullet()
    {
        if (pool.Count == 0)
        {
            pool.Add(Instantiate(bullet, transform.position, transform.rotation));
            return;
        }
        if (pool.Count >= 1)
        {
            if (ReuseBullet(pool))
            {
                print("Need a bulltet. Creating a bullet");
                pool.Add(Instantiate(bullet, transform.position, transform.rotation));
            }
            else
                print("Reusing a bullet");
        }
    }
    private bool ReuseBullet(List<GameObject> pool)
    {
        bool value = false;
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeSelf)
            {
                pool[i].transform.position = transform.position;
                pool[i].transform.rotation = transform.rotation;
                pool[i].SetActive(true);
                Bullet bullet = pool[i].GetComponent<Bullet>();
                bullet.enabled = true;
                i = pool.Count;
                value = false;
                break;
            }
            else
                value = true;
        }
        return value;
    }

}
