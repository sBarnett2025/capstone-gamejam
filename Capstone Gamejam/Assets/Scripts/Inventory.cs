using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> itemsHeld = new List<string>();
    public List<string> placedItems = new List<string>();
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        string default1 = "Medium Window";
        string default2 = "Small Window";
        string default3 = "Large Door";
        string default4 = "Small Staircase";
        string default5 = "Large Archway";
        string default6 = "Large Balcony";
        string default7 = "Medium Door";
        string default8 = "External Pillar";
        itemsHeld.Add(default1);
        itemsHeld.Add(default2);
        itemsHeld.Add(default3);
        itemsHeld.Add(default4);
        itemsHeld.Add(default5);
        itemsHeld.Add(default6);
        itemsHeld.Add(default7);
        itemsHeld.Add(default8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
