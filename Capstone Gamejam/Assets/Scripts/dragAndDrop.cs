using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class dragAndDrop : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 mousePos;

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

        pos.x = Mathf.Round(pos.x);
        pos.z = Mathf.Round(pos.z);

       transform.position = pos;
    }

}
