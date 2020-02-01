
using System.Collections;
using UnityEngine;

class ItemDragHandler : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;
    private Vector3 initialPosition;


    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        initialPosition = transform.position;
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
            Debug.DrawLine(ray.origin, hit.point);
        if (hit.transform.tag == "Station")  // check if object we are hovering over is a station
        {
            Debug.Log("Hit: " + hit.transform.gameObject.name);

            string weaponTag = gameObject.GetComponent<Item>().getNextStation();
            Debug.Log("next station for weapon is: " + weaponTag);
            if (hit.collider.gameObject.name == weaponTag)  // check if it is the next station to process
            {
                Debug.Log("hit the next station!");
                // if it is, check if the station is available
                if (hit.collider.gameObject.GetComponent<Station>().isAvailable())
                {
                    // play sound itemAccept
                    hit.collider.gameObject.GetComponent<Station>().insert(gameObject);  // insert in station
                    gameObject.GetComponent<Item>().getLocation().GetComponent<ItemHolder>().remove(gameObject);
                    return;
                }
            }
        }

        transform.position = initialPosition;

    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
    }
}
