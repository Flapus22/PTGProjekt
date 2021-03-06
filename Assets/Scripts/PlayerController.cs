using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //public Rigidbody rigidbody { get; set; }
    public float speed = 10;
    public float dashDistance = 10;

    public bool canJump = true;
    private bool canRight = true;
    private bool canLeft = true;
    private bool ifAim = true;

    public float jumpHigh = 2;

    Vector3 move = new Vector3();
    float dash;
    Vector3 mousePosition = new Vector3();
    public SphereCollider spher;
    public GameObject throwPrefab;

    //narazie nie wykorzystywane 
    float distanceObjectRight;
    float distanceObjectLeft;

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
        //Tymczasowo do zmiany posta? b?dzie si? obraca? potem 
        //mo?liwe ?e nie potrzebna zmianna sam model si? bedzie obraca?
        RaycastHit hit;

        canRight = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 0.5f);
        canLeft = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 0.5f);
        //canJump = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 0.60f);

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
    }

    void OnMousePosition(InputValue value)
    {
        mousePosition.x = value.Get<Vector2>().x;
        mousePosition.y = value.Get<Vector2>().y;
    }

    void OnAim(InputValue value)
    {
        var temp = transform.position + spher.bounds.size;
        temp.z = 0;
        Instantiate(throwPrefab,temp,Quaternion.identity);
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
