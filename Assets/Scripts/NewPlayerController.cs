using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerController : MonoBehaviour
{
    //public Rigidbody rigidbody { get; set; }
    public HealthBar healthBar;
    public float speed = 10;
    public float dashDistance = 10;

    public bool canDash = true;
    private bool ifAim = true;
    private Stats playerStats;
    public bool isAlive;

    public float jumpHigh = 1;
    public float moveDown = 0;

    Vector3 move = new Vector3();
    float dash;
    Vector3 mousePosition = new Vector3();
    public SphereCollider spher;
    public GameObject throwPrefab;
    public int point = 0;

    public CharacterController characterController;

    void Start()
    {
        playerStats = GetComponent<Stats>();
        characterController = GetComponent<CharacterController>();
        healthBar.SetMaxHealth((int)playerStats.MaxHealth);
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
    public void Die()
    {
        isAlive = false;
        GetComponent<PlayerInput>().enabled = false;
    }

    public void GetHit(float dmg)
    {
        playerStats.Health -= dmg;
        healthBar.SetHealth((int)playerStats.Health);
        Debug.Log("Hit");
        if (playerStats.Health <= 0)
        {
            Die();
        }
    }
    public void GetHit()
    {
        playerStats.Health = 0;
        healthBar.SetHealth((int)playerStats.Health);
        Debug.Log("Hit");
        if(playerStats.Health <= 0)
        {
            Die();
        }
    }

    void OnFire()
    {
        
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

    public void GetPoint()
    {
        point++;
    }
    
}
