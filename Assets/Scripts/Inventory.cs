using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory<T>
{
    private List<T> items = new List<T>();

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void RemoveItem(T item)
    {
        items.Remove(item);
    }

    public void PrintInventory()
    {
        foreach (T item in items)
        {
            Console.WriteLine(item.ToString());
        }
    }
}

