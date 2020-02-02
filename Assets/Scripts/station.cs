using System.Collections;
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

    public float processTimer = 5.0f;
    public Sprite hintSprite;
    public GameObject storageArea;
    public GameObject conveyorBelt;
    public AudioClip processingSound;
    public GameObject progressBar;
    //public Transform progressBarLocation;
    public Sprite[] progressBarSprites;

    void Start() {
        progressBar.GetComponent<SpriteRenderer>().enabled = false;
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
                resetProgressBar();
            }
            else {
                int newProgress = Mathf.FloorToInt((1 - processTimeLeft / processTimer) / 0.25f);
                if (newProgress > currentProgress) {
                    print("newProgress: " + newProgress);
                    updateProgressBar(newProgress);
                }
                
            }

            processTimeLeft -= Time.deltaTime;
            // print("Weapon will be ready in: " + processTimeLeft);
        }
    }

    public void insert(GameObject item) {
        if (isBlocked == false) {
            // si al objeto le toca esta estacion


            //Debug.Log("WeaponTag: " + weaponTag);
            //Debug.Log("StationTag: " + gameObject.name);
            //if (weaponTag == gameObject.name)
            //{
            isBlocked = true;
            AudioSource.PlayClipAtPoint(processingSound, transform.position);
            updateProgressBar(0);
            progressBar.GetComponent<SpriteRenderer>().enabled = true;
            // play animation
            Debug.Log("Received item: " + item.name);
            item.GetComponent<Item>().nextStation(); // update status
            this.item = item;
            isProcessing = true;
            processTimeLeft = processTimer;
            //}
            // gameObject.GetComponent<Animation>().Play();
        }
    }

    void emptyStation() {

        if (item.GetComponent<Item>().isRepaired())  // send to conveyor belt if item has been repaired
        {
            print("Item " + item.name + " has been repaired!");
            item.GetComponent<Item>().setSprite(item.GetComponent<Item>().repairedSprite);
            conveyorBelt.GetComponent<ConveyorBelt>().insert(item);
        }
        else {
            if (!storageArea.GetComponent<StorageArea>().isFull())
            {
                storageArea.GetComponent<StorageArea>().insert(item);
            }
            else
            {
                print("Storage full.");
                conveyorBelt.GetComponent<ConveyorBelt>().insert(item);
            }
        }
        
        isBlocked = false;
    }

    public bool isAvailable() {
        return !isBlocked;
    }

    public void hint() {
        originalSprite = GetComponent<SpriteRenderer>().sprite;
        GetComponent<SpriteRenderer>().sprite = hintSprite;
    }

    public void restoreSprite() {
        GetComponent<SpriteRenderer>().sprite = originalSprite;
    }

    private void updateProgressBar(int progress) {
        print("progress is: " + progress);
        progressBar.GetComponent<SpriteRenderer>().sprite = progressBarSprites[progress];
        currentProgress = progress;
    }

    private void resetProgressBar() {
        //progressBar.
        progressBar.GetComponent<SpriteRenderer>().enabled = false;
        updateProgressBar(1);
    }
}
