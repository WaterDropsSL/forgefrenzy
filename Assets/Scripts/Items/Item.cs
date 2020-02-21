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
    public AudioClip repairedSound;
    public int scorePoints;
    private bool hidden = false;
    public AudioManager audioManager;
    //public GameObject spawnObject;
    public System.Guid id { get; private set; }
    // Other properties, etc.

    public Item() {
        this.stationsLeft = new Queue<string>();
        this.id = System.Guid.NewGuid();
    }

    void Awake() {
        audioManager = FindObjectOfType<AudioManager>();
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

    public void repair() {

        // setSprite
        setSprite(repairedSprite);
        
        gameObject.layer = 2; // if its repaired, disable raycasting
        // TODO: handle every move in ItemManager

    }

    public bool isRepaired() {
        return stationsLeft.Count == 0; ;
    }

    public void setSprite(Sprite newSprite) {
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void hideItem() {
        hidden = true;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        print("item invisible");
    }

    public void unHideItem()
    {
        hidden = false;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
        print("item visible");
    }

    void OnBecameInvisible()
    {
        if (!hidden) {
            location.GetComponent<ItemHolder>().remove(gameObject);
            if (!isRepaired()) {
                ScoreManager.instance.breakCombo();
                audioManager.play("breakCombo");
            }
            print("Destroying object...");
            Destroy(gameObject);
        }
        
    }
}
