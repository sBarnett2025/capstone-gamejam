using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControl : MonoBehaviour
{
    public List<float> zvalues = new List<float>();
    public List<bool> completedBuildings = new List<bool>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("House1Complete") != null && completedBuildings[0] == true)
        {
            GameObject.Find("House1Complete").transform.position = new Vector3(GameObject.Find("House1Complete").transform.position.x, GameObject.Find("House1Complete").transform.position.y, zvalues[0]);
        }
        if (GameObject.Find("House2Complete") != null && completedBuildings[1] == true)
        {
            GameObject.Find("House2Complete").transform.position = new Vector3(GameObject.Find("House2Complete").transform.position.x, GameObject.Find("House2Complete").transform.position.y, zvalues[1]);
        }
        if (GameObject.Find("House3Complete") != null && completedBuildings[2] == true)
        {
            GameObject.Find("House3Complete").transform.position = new Vector3(GameObject.Find("House3Complete").transform.position.x, GameObject.Find("House3Complete").transform.position.y, zvalues[2]);
        }
        if (GameObject.Find("House4Complete") != null && completedBuildings[3] == true)
        {
            GameObject.Find("House4Complete").transform.position = new Vector3(GameObject.Find("House4Complete").transform.position.x, GameObject.Find("House4Complete").transform.position.y, zvalues[3]);
        }
        if (GameObject.Find("House5Complete") != null && completedBuildings[4] == true)
        {
            GameObject.Find("House5Complete").transform.position = new Vector3(GameObject.Find("House5Complete").transform.position.x, GameObject.Find("House5Complete").transform.position.y, zvalues[4]);
        }
    }
}
