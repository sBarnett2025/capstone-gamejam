using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
        Debug.Log(correctPositions.Count);

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
            //if the object is in the correct place and mouse button is released, place object down, get rid of this object
            
            if (Input.GetMouseButton(0) == false)
            {
                if (obj.GetComponent<dragAndDrop>() != null)
                {
                    Debug.Log("Parent name is: ");
                    Debug.Log(correctName);
                    Debug.Log("Child name is: ");
                    Debug.Log(obj.GetComponent<dragAndDrop>().name);
                    if (obj.GetComponent<dragAndDrop>().objectName == correctName && obj.GetComponent<dragAndDrop>().replacement != null)
                    {//also makes sure not to try to do this if there's no replacement object.
                        Instantiate(obj.GetComponent<dragAndDrop>().replacement, obj.transform.position, obj.transform.rotation);
                        objects.Remove(obj);
                        correctNames.Remove(correctName);
                        correctPositions.Remove(correctPos);
                        Destroy(obj);
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
