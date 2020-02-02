using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public Vector3 spawnPosition;
    public List<GameObject> items;
    public int maxItems = 2;

    public void insert(GameObject item) {
        print("Item received at the " + gameObject.name);
        items.Add(item);
        item.GetComponent<Item>().setLocation(gameObject);

        // move position
        Vector3 newItemPosition = transform.position + Vector3.up;
        item.transform.position = newItemPosition;
    }

    public void remove(GameObject item)
    {
        print("number of items before removing: " + this.items.Count);
        this.items.Remove(item);
    }

    public bool isFull()
    {
        return items.Count == maxItems;
    }

}
