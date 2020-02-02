using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    public float spawnTime = 5.0f;
    public Transform spawnLocation;
    public GameObject[] spawnItems;
    public GameObject conveyorBelt;
    private float timer = 0.0f;
    private GameObject nextItem;

    // Start is called before the first frame update
    void Start()
    {
        processNextItem();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer > spawnTime)
        {
            spawnItem(nextItem);
            timer = timer - spawnTime;
        }
    }

    private void processNextItem() {
        int randomIndex = Random.Range(0, spawnItems.Length);
        nextItem = spawnItems[randomIndex];

        Sprite nextSprite = nextItem.GetComponent<SpriteRenderer>().sprite;

    }

    void spawnItem(GameObject itemPrefab) {
        print("Spawning item!");

        
        GameObject newItem = Instantiate(itemPrefab, spawnLocation.position, Quaternion.identity);
        conveyorBelt.GetComponent<ConveyorBelt>().insert(newItem);
    }

}
