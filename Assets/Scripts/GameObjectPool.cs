﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool
{
    private readonly GameObject prefab;
    private readonly Queue<GameObject> items;
    private int whatevs = 5;


    public GameObjectPool(GameObject prefab, int initialAmount = 0)
    {
        this.prefab = prefab;
        items = new Queue<GameObject>();
        Create(initialAmount);
    }

    public GameObject Withdraw()
    {
        if (items.Count == 0)
        {
            Create(1);
        }
        GameObject item = items.Dequeue();
        item.SetActive(true);
        return item;
    }

    public void Deposit(GameObject item)
    {
        item.SetActive(false);
        items.Enqueue(item);
    }

    private void Create(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject item = Object.Instantiate(prefab);
            item.SetActive(false);
            items.Enqueue(item);
        }
    }
}
