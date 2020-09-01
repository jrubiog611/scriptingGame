using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LootChance : MonoBehaviour
{
    public List<GameObject> h;
    public int[] table;
    private int hIndex;

    public int dropChance;
    private bool drop;

    public int total;
    public int randomPicker, randomDrop;
    void Start()
    {        
        foreach (var item in table)
        {
            total += item;
        }

        randomPicker = UnityEngine.Random.Range(0, total);
        Debug.Log(randomPicker);

        randomDrop = UnityEngine.Random.Range(0, 100);
        Debug.Log("drop chance " + randomDrop);

        if (randomDrop <= dropChance)
            drop = true;

        for(int i = 0; i<table.Length;i++)
        {
            if (randomPicker <= table[i])
            { 
                
                //instance loot object
                hIndex = i;
                return;
                
            }
            else
            {
                randomPicker -= table[i];
            }
        }


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Destroy(gameObject);
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        if (drop)
        {
            Instantiate(h[hIndex]);
            Debug.Log("It Works");
        }
    }
}
