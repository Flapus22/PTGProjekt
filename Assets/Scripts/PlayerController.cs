using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidbody { get; set; }
    public float speed = 10;
    private bool canJump = true;
    public float jumpHigh = 2;

    //narazie nie wykorzystywane 
    float timeToJump = 3;
    float time = 0;

    Vector3 move = new Vector3();
    void Start()
    {
        //playerInput = GetComponent<PlayerInput>();
    }
    void Update()
    {
        transform.Translate(move * Time.deltaTime * speed);
    }
    private void FixedUpdate()
    {
        //Tymczasowo do zmiany postaæ bêdzie siê obracaæ potem 
        //mo¿liwe ¿e nie potrzebna zmianna sam model siê bedzie obracaæ
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 0.5f) && move.x > 0)
        {
            move.x = 0;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 0.5f) && move.x < 0)
        {
            move.x = 0;
        }
        canJump = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 0.55f);
       
    }
    private void LateUpdate()
    {
        if (move.y > 0)
        {
            move.y -= Time.deltaTime * 3;
        }
        else if (move.y < 0) move.y = 0;

    }
    void OnMove(InputValue value)
    {
        Vector2 movmentVector = value.Get<Vector2>();
        move.x = movmentVector.x;
    }
    void OnJump()
    {
        if (canJump)
        {
            Jump(jumpHigh);
            canJump = false;
        }
    }
    public void Jump(float jumpHigh)
    {
        move.y = jumpHigh;
    }
}
