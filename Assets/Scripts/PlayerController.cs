using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidbody { get; set; }
    public float speed = 10;
    CharacterController controller;
    void Start()
    {
        //rigidbody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();

    }
    void Update()
    {
        var horizontalAxis = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var jump = 0f;
        //var verticalAxis = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = 10f;
            rigidbody.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
        }
        Vector3 position = new Vector3(transform.position.x + horizontalAxis, transform.position.y, transform.position.z);

        //rigidbody.MovePosition(position);

        controller.Move(position);
        
        
    }
}
