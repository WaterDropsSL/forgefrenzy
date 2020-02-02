using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : ItemHolder
{
    public float flowRate = 1.0f;

    void Update()
    {

        foreach (GameObject item in items)
        {
            float distance = Time.deltaTime * flowRate;
            item.transform.Translate(Vector3.right * distance);
            //item.transform.position = item.transform.position + Vector3(1, 0, 0);
        }
    }
}
