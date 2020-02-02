using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected Queue<string> stationsLeft;
    public GameObject location;
    public Sprite selectedSprite;
    public Sprite brokenSprite;
    public Sprite brokenSelectedSprite;
    public Sprite repairedSprite;
    //public GameObject spawnObject;

    public Item() {
        this.stationsLeft = new Queue<string>();
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

    public bool isRepaired() {

        //bool result = 
        ////print("isRepaired: " + result);
        return stationsLeft.Count == 0; ;
    }

    public void setSprite(Sprite newSprite) {
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    void OnBecameInvisible()
    {
        location.GetComponent<ItemHolder>().remove(gameObject);
        print("Destroying object...");
        Destroy(gameObject);
    }
}
