using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected Queue<string> stationsLeft;
    protected GameObject location;
    public GameObject spawnObject;

    public Item() {
        stationsLeft = new Queue<string>();
        location = spawnObject;
    }

    public string getNextStation() {
        return stationsLeft.Peek();
    }

    public void setLocation(GameObject location) {
        this.location = location;
    }

    public GameObject getLocation()
    {
        return this.location;
    }

    public string nextStation() {
        return stationsLeft.Dequeue();
    }
}
