using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class station : MonoBehaviour
{
    public bool blocked = false;
    public GameObject weapon;

    void inputWeapon(GameObject weapon) {
        if (blocked == false) {
            blocked = true;
            // play animation
            this.weapon = weapon;
            // gameObject.GetComponent<Animation>().Play();
            // release
            blocked = false;
        }
    }

    void retrieveWeapon() {
        if (blocked == false) {
            
        }
    }

}
