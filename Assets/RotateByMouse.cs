using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateByMouse : MonoBehaviour
{
    [SerializeField] public float rotationspeed = 45f;
    private bool _rotating = false;
    private void OnMouseDown()
    {
        _rotating = true;

    }
    private void OnMouseUp()
    {
        _rotating = false; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var wheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (_rotating)
        {
            if (wheelInput > 0)

            {
                transform.eulerAngles += Vector3.forward * rotationspeed;

            }
            else if (wheelInput < 0)
            {
                transform.eulerAngles += Vector3.back * rotationspeed;
            }
        }
    }
}
