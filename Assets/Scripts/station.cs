using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    private bool isBlocked = false;
    private bool isProcessing = false;
    private GameObject item;
    private float processTimeLeft = 5.0f;
    private Sprite originalSprite;
    private int currentProgress = 1;
    private Queue<GameObject> capacityBarItems = new Queue<GameObject>();

    public float processTimer = 5.0f;
    public Sprite hintSprite;
    public StorageArea storageArea;
    public ConveyorBelt conveyorBelt;
    public AudioClip processingSound;
    public GameObject progressBar;
    public Sprite[] progressBarSprites;
    public Sprite[] capacityBarSprites;
    public GameObject capacityBar;
    public int maxItemsCapacityBar = 3;
    public GameObject vfx;

    private AudioManager audioManager;

    void Start() {
        progressBar.GetComponent<SpriteRenderer>().enabled = false;
        capacityBar.GetComponent<SpriteRenderer>().enabled = false;
        vfx.GetComponent<SpriteRenderer>().enabled = false;
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isProcessing) {
            if (processTimeLeft < 0)
            {
                // process done
                isProcessing = false;
                print("Item finished!");

                emptyStation();
                
            }
            else {
                int newProgress = Mathf.FloorToInt((1 - processTimeLeft / processTimer) / 0.25f);
                if (newProgress > currentProgress) {
                    updateProgressBar(newProgress);
                }
                
            }

            processTimeLeft -= Time.deltaTime;
            // print("Weapon will be ready in: " + processTimeLeft);
        }
    }

    private void processItem(GameObject item) {
        isBlocked = true;
        //AudioSource.PlayClipAtPoint(processingSound, transform.position);
        audioManager.play(gameObject.name);
        progressBar.GetComponent<SpriteRenderer>().enabled = true;
        vfx.GetComponent<SpriteRenderer>().enabled = true;
        updateProgressBar(0);

        Debug.Log("Station " + gameObject.name + " received item: " + item.name);
        item.GetComponent<Item>().hideItem();
        item.GetComponent<Item>().nextStation(); // update status
        this.item = item;
        isProcessing = true;
        processTimeLeft = processTimer;
        // play animation
        // gameObject.GetComponent<Animation>().Play();
    }

    private void enqueueItem(GameObject item) {
        Debug.Log("Station " + gameObject.name + " enqueued item: " + item.name);
        capacityBar.GetComponent<SpriteRenderer>().enabled = true;
        // we add it to the queue
        capacityBarItems.Enqueue(item);
        item.GetComponent<Item>().hideItem();
        updateCapacityBar();
    }
    

    public void insert(GameObject item) {
        if (!isBlocked)
        {
            processItem(item);
        }
        else {
            // if we have room for more items in the capacity bar
            if (capacityBarItems.Count < maxItemsCapacityBar) {
                enqueueItem(item);
            }
        }
    }

    void emptyStation() {

        vfx.GetComponent<SpriteRenderer>().enabled = false;
        if (item.GetComponent<Item>().isRepaired())  // send to conveyor belt if item has been repaired
        {
            int scorePoints = item.GetComponent<Item>().scorePoints;
            print("Item " + item.name + " has been repaired, got " + scorePoints + " points.");
            //item.GetComponent<Item>().setSprite(item.GetComponent<Item>().repairedSprite);
            item.GetComponent<Item>().repair();
            ScoreManager.instance.addScore(scorePoints);
            conveyorBelt.insert(item);
            audioManager.play("itemRepaired");
            //AudioSource.PlayClipAtPoint(item.GetComponent<Item>().repairedSound, transform.position);
        }
        else {
            if (!storageArea.isFull())
            {
                storageArea.insert(item);
            }
            else
            {
                print("Storage full.");
                conveyorBelt.insert(item);
            }
        }
        resetProgressBar();
        item.GetComponent<Item>().unHideItem();
        

        if (capacityBarItems.Count > 0)
        {
            // we start processing next item
            print("processing an enqueued item...");
            processItem(capacityBarItems.Dequeue());
            updateCapacityBar();
        }
        else {
            isBlocked = false;
        }
    }

    public bool isAvailable() {
        // checkear si está libre, sino devolver si hay hueco en la cola o no
        return !isBlocked || capacityBarItems.Count < maxItemsCapacityBar;
    }

    public void hint() {
        originalSprite = GetComponent<SpriteRenderer>().sprite;
        GetComponent<SpriteRenderer>().sprite = hintSprite;
    }

    public void restoreSprite() {
        GetComponent<SpriteRenderer>().sprite = originalSprite;
    }

    private void updateProgressBar(int progress) {
        progressBar.GetComponent<SpriteRenderer>().sprite = progressBarSprites[progress];
        currentProgress = progress;
    }

    private void updateCapacityBar()
    {
        if (capacityBarItems.Count == 0) {
            capacityBar.GetComponent<SpriteRenderer>().enabled = false;
        } else {
            capacityBar.GetComponent<SpriteRenderer>().sprite = capacityBarSprites[capacityBarItems.Count - 1];
        }
        
    }

    private void resetProgressBar() {
        //progressBar
        progressBar.GetComponent<SpriteRenderer>().enabled = false;
        updateProgressBar(1);
    }
}
