using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class dragAndDrop : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 mousePos;
    Vector3 resetter = Vector3.up;
    float rotatorFX = 90f;

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
       transform.position = pos;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            transform.Rotate(0f, rotatorFX, 0f);
        }
    }
}
