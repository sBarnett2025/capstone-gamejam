using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPosition : MonoBehaviour
{
    // objects
    public List<GameObject> objects = new List<GameObject>();

    // correct pos
    public List<Vector3> correctPositions = new List<Vector3>();

    // lines
    public GameObject linePrefab;
    public List<LineRenderer> lines = new List<LineRenderer>();


    // score
    float totalScore;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            // add child to list
            objects.Add(transform.GetChild(i).gameObject);

            // generate random correct pos
            Vector3 rand = new Vector3(Random.Range(-5f, 5f), 1f, Random.Range(-5f, 5f));
            correctPositions.Add(rand);

            // add line 
            GameObject l = Instantiate(linePrefab);
            lines.Add(l.GetComponent<LineRenderer>());
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
            CheckPos(objects[i], correctPositions[i], lines[i]);
        }
    }

    void CheckPos(GameObject obj, Vector3 correctPos, LineRenderer line)
    {
        float distance = (obj.transform.position - correctPos).magnitude;
        if (distance < 0.0125)
        {
            obj.transform.position = correctPos;
        }
        line.SetPosition(0, obj.transform.position);
        line.SetPosition(1, correctPos);

        // score deduction
        float deduction = 1;
        if (distance < 5)
        {
            deduction = distance / 5;
        }

        totalScore -= deduction;
    }
}
