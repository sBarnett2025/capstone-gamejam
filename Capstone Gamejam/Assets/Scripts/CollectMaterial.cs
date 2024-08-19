using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectMaterial : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast (ray, out hit))
            {
                if (hit.collider.GetComponent<Collectable>() != null)
                {
                    if (GameObject.Find("Inventory")  != null)
                    { //add the clicked on item to the inventory
                        GameObject.Find("Inventory").GetComponent<Inventory>().itemsHeld.Add(hit.collider.GetComponent<Collectable>().Collect());
                    } //there easily could be an item limit by preventing this if itemsHeld is longer than 8, but whatever.
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
