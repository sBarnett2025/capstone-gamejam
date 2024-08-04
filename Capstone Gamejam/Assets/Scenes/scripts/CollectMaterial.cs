using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectMaterial : MonoBehaviour
{
    public List<GameObject> fauxInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
                    fauxInventory.Add(hit.collider.GetComponent<Collectable>().Collect());
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
