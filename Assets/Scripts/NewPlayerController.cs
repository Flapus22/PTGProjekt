using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerController : MonoBehaviour
{
    //public Rigidbody rigidbody { get; set; }
    public float speed = 10;
    public float dashDistance = 10;

    public bool canDash = true;
    private bool ifAim = true;

    public float jumpHigh = 1;
    public float moveDown = 0;

    Vector3 move = new Vector3();
    float dash;
    Vector3 mousePosition = new Vector3();
    public SphereCollider spher;
    public GameObject throwPrefab;

    public CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        var tempMove = Move();
        characterController.Move(tempMove * Time.deltaTime);
    }

    private void FixedUpdate()
    {

    }

    private void LateUpdate()
    {
        if (!characterController.isGrounded)
        {
            if (move.y > -8)
            {
                move.y -= Time.deltaTime * 3;
            }
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 movmentVector = value.Get<Vector2>();
        move.x = movmentVector.x;
    }

    void OnJump()
    {
        if (characterController.isGrounded)
        {
            Jump(jumpHigh);
        }
    }

    void OnDash(InputValue value)
    {
        if (canDash)
        {
            if (move.x != 0)
            {
                dash = dashDistance * value.Get<float>();
                canDash = false;
                StartCoroutine(Dash());
            }
        }
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
        Instantiate(throwPrefab, temp, Quaternion.identity);
    }

    Vector3 Move()
    {
        var result = move * speed;
        result.x += move.x > 0 ? dash : -dash;
        return result;
    }

    public void Jump(float jumpHigh)
    {
        move.y = jumpHigh;
    }

    public IEnumerator Dash()
    {
        yield return new WaitForSeconds(0.2f);
        dash = 0;
        yield return new WaitForSeconds(3);
        canDash = true;
    }
    
}
