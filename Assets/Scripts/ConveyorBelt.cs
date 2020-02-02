using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : ItemHolder
{
    public float speed = 1.0f;

    void Update()
    {
        float distance = Time.deltaTime * speed;
        foreach (GameObject item in items)
        {
            
            item.transform.Translate(Vector3.right * distance);
            //item.transform.position = item.transform.position + Vector3(1, 0, 0);
        }
    }
}
