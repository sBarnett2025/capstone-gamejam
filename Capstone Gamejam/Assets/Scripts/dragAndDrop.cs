using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class dragAndDrop : MonoBehaviour
{
    private GameObject inventory;


    Vector3 mousePos;
    public string objectName;
    public GameObject replacement;

    // Start is called before the first frame update
    private void Start()
    {
        if (GameObject.Find("Inventory") != null)
        {
            inventory = GameObject.Find("Inventory");
            for (int i = 0; i < inventory.GetComponent<Inventory>().itemsHeld.Count; i++)
            {
                if (inventory.GetComponent<Inventory>().itemsHeld[i] == objectName)
                {
                    //Debug.Log(objectName);
                    transform.position = new Vector3(-5 + i % 2, 1, 3.7f - (i * 1.1f)); //two rows, descending order based on order in inventory.
                    transform.position = new Vector3(transform.position.x + Camera.main.transform.position.x, 1, transform.position.z + Camera.main.transform.position.z);
                }
            }
        }
    }
    private Vector3 getMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition - getMousePos();
        
    }

    private void OnMouseDrag()
    {
       Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
        if (pos.y < 1 || pos.y > 1)
        {
            pos.y = 1;
        }

        pos.x = Mathf.Round(pos.x * 10) / 10;
        pos.z = Mathf.Round(pos.z * 10) / 10;//lol rounding to a decimal place in unity is so dumb

       transform.position = pos;
    }

}
