using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageArea : ItemHolder
{

    //private List<GameObject> storedWeapons = new List<GameObject>();

    public override void insert(GameObject item)
    {
        base.insert(item);
        Vector3 offset = Vector3.right * (items.Count - 1);
        item.transform.position = item.transform.position + offset;
    }

        //public void insertWeapon(GameObject weapon) {
        //    storedWeapons.Add(weapon);
        //    print("Weapon stored!");
        //    Vector3 newWeaponPosition = transform.position + new Vector3(0, 0, -2);
        //    weapon.GetComponent<Weapon>().setLocation(gameObject);
        //    weapon.transform.position = newWeaponPosition;
        //}

        //public void removeWeapon(GameObject weapon) {
        //    storedWeapons.Remove(weapon);
        //    print("Weapon " + weapon + " removed." );
        //}
    }
