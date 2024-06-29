using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DragByMouse : MonoBehaviour
{ private bool _dragging = false;
    private Vector3 _offset;
    private void OnMouseDown()
    { _offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
      
        _dragging = true;
    }
    private void OnMouseUp()
    {
        _dragging = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;
            
        }  
    }
}
