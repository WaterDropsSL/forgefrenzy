using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    private bool isBlocked = false;
    private bool isProcessing = false;
    private GameObject item;
    public float processTimer = 5.0f;
    private float processTimeLeft = 5.0f;
    public GameObject storageArea;
    public GameObject conveyorBelt;

    // Update is called once per frame
    void Update()
    {
        if (isProcessing) {
            if (processTimeLeft < 0) {
                // process done
                isProcessing = false;           
                print("Item finished!");
                emptyStation();
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
}
