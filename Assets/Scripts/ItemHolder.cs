using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public Transform spawnPosition;
    public List<GameObject> items = new List<GameObject>();
    public int maxItems = 2;

    public void insert(GameObject item) {
        print("Item received at the " + gameObject.name);
        items.Add(item);
        item.GetComponent<Item>().setLocation(gameObject);

        // move position
        item.transform.position = spawnPosition.position;
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
