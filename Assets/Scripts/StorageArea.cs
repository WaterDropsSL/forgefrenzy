using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageArea : ItemHolder
{
    private string[] occupiedSpots;

    void Start() {
        occupiedSpots = new string[maxItems];
    }

    public override void insert(GameObject item)
    {

        System.Array.ForEach(occupiedSpots, Debug.Log);
        base.insert(item);
        Vector3 offset = new Vector3();
        for (int position = 0; position < occupiedSpots.Length; position++) {
            if (occupiedSpots[position] == null) { // spot free
                offset = Vector3.right * position;
                occupiedSpots[position] = item.GetComponent<Item>().id.ToString();
                break;
            }
        }
        item.transform.position = item.transform.position + offset;
    }

    public override void remove(GameObject item)
    {
        base.remove(item);
        for (int position = 0; position < occupiedSpots.Length; position++) {
            if (occupiedSpots[position] == item.GetComponent<Item>().id.ToString()) {
                occupiedSpots[position] = null;
            }
        }
    }
}
