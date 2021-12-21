using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //public Rigidbody rigidbody { get; set; }
    public float speed = 10;
    public float dashDistance = 20;

    private bool canJump = true;
    private bool canRight = true;
    private bool canLeft = true;

    public float jumpHigh = 2;

    //narazie nie wykorzystywane 
    float timeToJump = 3;
    float time = 0;

    float distanceObjectRight;
    float distanceObjectLeft;

    Vector3 move = new Vector3();
    float dash;

    void Start()
    {
        //playerInput = GetComponent<PlayerInput>();
    }
    void Update()
    {
        var tempMove = Move();
        transform.Translate(tempMove * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        //Tymczasowo do zmiany postaæ bêdzie siê obracaæ potem 
        //mo¿liwe ¿e nie potrzebna zmianna sam model siê bedzie obracaæ
        RaycastHit hit;

        canRight = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 0.5f);
        canLeft = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 0.5f);
        //Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 5f);
        //distanceObjectRight = hit.distance;
        //Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 5f);
        //distanceObjectLeft = hit.distance;

        //if () && move.x > 0)
        //{
        //    move.x = 0;
        //}
        //else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 0.5f) && move.x < 0)
        //{
        //    move.x = 0;
        //}
        canJump = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 0.55f);

        //Debug.Log("Lewo" + distanceObjectLeft);
        //Debug.Log("Prawo" + distanceObjectRight);

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
        //Debug.Log("Dzia³a");
    }
    void OnJump()
    {
        if (canJump)
        {
            Jump(jumpHigh);
        }
    }

    void OnDash(InputValue value)
    {
        dash = dashDistance * value.Get<float>();
        if (move.x < 0) dash *= -1 ;
        //Debug.Log(dash);
    }


    Vector3 Move()
    {
        var result = new Vector3();
        result = move * speed;
        result.x += dash;
        if (canLeft && move.x < 0) result.x = 0;
        if (canRight && move.x > 0) result.x = 0;
        return result;
    }
    public void Jump(float jumpHigh)
    {
        move.y = jumpHigh;
    }
}
