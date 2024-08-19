using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPosition : MonoBehaviour
{

    //acceptable distance
    public float distanceReqForCorrect;

    // objects
    public List<GameObject> objects = new List<GameObject>();

    // correct pos
    public List<Vector3> correctPositions = new List<Vector3>(); //where the object is meant to go
    public List<string> correctNames = new List<string>(); //what object goes there
    

    // lines
    /*public GameObject linePrefab;
    public List<LineRenderer> lines = new List<LineRenderer>();*/ //for debug purposes

    //non-draggable object.


    // score
    float totalScore;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            // add child to list
            objects.Add(transform.GetChild(i).gameObject);

            // generate random correct pos --- for now, unnecessary, set correct positions on a per level basis.
            /*Vector3 rand = new Vector3(Random.Range(-5f, 5f), 1f, Random.Range(-5f, 5f));
            correctPositions.Add(rand); */

            // add line 
            /*GameObject l = Instantiate(linePrefab);
            lines.Add(l.GetComponent<LineRenderer>());*/ //debug
        }

        //check the inventory to see if an item of the same name has already
        if (GameObject.Find("Inventory") != null)
        {
            for (int i = 0; i < correctNames.Count; i++)
            {
                //Debug.Log(correctNames[i]);
                for (int j = 0; j < GameObject.Find("Inventory").GetComponent<Inventory>().placedItems.Count; j++)
                {
                    //Debug.Log(GameObject.Find("Inventory").GetComponent<Inventory>().placedItems[j]);
                    if (GameObject.Find("Inventory").GetComponent<Inventory>().placedItems[j] == correctNames[i])
                    {
                        Debug.Log("Item placed already");
                        correctNames.Remove(correctNames[i]);
                        correctPositions.Remove(correctPositions[i]);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].transform.position = correctPositions[i];
            }
        }

        totalScore = objects.Count;
        for (int i = 0; i < objects.Count; i++)
        {
            CheckPos(objects[i], correctPositions[i], correctNames[i]); //lines[i]
        }
    }

    void CheckPos(GameObject obj, Vector3 correctPos, string correctName) //Linerenderer line, Debug
    {
        float distance = (obj.transform.position - correctPos).magnitude;
        if (distance < distanceReqForCorrect)
        {
            obj.transform.position = correctPos;
            //Debug.Log("Contact");
            //if the object is in the correct place and mouse button is released, place object down, get rid of this object
            
            if (Input.GetMouseButton(0) == false)
            {
                if (obj.GetComponent<dragAndDrop>() != null)
                {
                    /*Debug.Log("Parent name is: ");
                    Debug.Log(correctName);
                    Debug.Log("Child name is: ");
                    Debug.Log(obj.GetComponent<dragAndDrop>().objectName);*/
                    if (obj.GetComponent<dragAndDrop>().objectName == correctName && obj.GetComponent<dragAndDrop>().replacement != null)
                    {//also makes sure not to try to do this if there's no replacement object.
                        Instantiate(obj.GetComponent<dragAndDrop>().replacement, obj.transform.position, obj.transform.rotation);
                        objects.Remove(obj);
                        correctNames.Remove(correctName);
                        correctPositions.Remove(correctPos);
                        if (GameObject.Find("Inventory") != null)
                        {
                            GameObject.Find("Inventory").GetComponent<Inventory>().placedItems.Add(correctName);
                            GameObject.Find("Inventory").GetComponent<Inventory>().itemsHeld.Remove(correctName);
                        }
                        Destroy(obj);

                        float buildCount = 0;
                        for (int i  = 0; i < correctPositions.Count; i++)
                        {
                            buildCount += correctPositions[i].x;
                            buildCount += correctPositions[i].y;
                            buildCount += correctPositions[i].z;
                        }

                        if (buildCount == 0)
                        {
                            string sceneName;
                            sceneName = SceneManager.GetActiveScene().name;
                            if (GameObject.Find("ColorController") != null)
                            {
                                if (sceneName == "House1")
                                {
                                    GameObject.Find("ColorController").GetComponent<ColorControl>().completedBuildings[0] = true;
                                } else if (sceneName == "House2")
                                {
                                    GameObject.Find("ColorController").GetComponent<ColorControl>().completedBuildings[1] = true;
                                } else if (sceneName == "House3")
                                {
                                    GameObject.Find("ColorController").GetComponent<ColorControl>().completedBuildings[2] = true;
                                }
                                else if (sceneName == "House4")
                                {
                                    GameObject.Find("ColorController").GetComponent<ColorControl>().completedBuildings[3] = true;
                                }
                                else if (sceneName == "House5")
                                {
                                    GameObject.Find("ColorController").GetComponent<ColorControl>().completedBuildings[4] = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        //line.SetPosition(0, obj.transform.position);
        //line.SetPosition(1, correctPos); Debug

        // score deduction
        float deduction = 1;
        if (distance < 5)
        {
            deduction = distance / 5;
        }

        totalScore -= deduction;
    }
}
