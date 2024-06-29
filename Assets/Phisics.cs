using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class Phisics : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] public float speed = 1f;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void StarMovement()
    {
        _rigidbody2D.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
    }
    public void StopMovement()
    {
        _rigidbody2D.velocity = Vector2.zero;  
        UnityEngine.Application.Quit();

    }
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
