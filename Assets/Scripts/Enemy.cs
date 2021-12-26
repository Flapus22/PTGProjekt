using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private bool isPlayerAlive;
    private float dist;
    private bool isHit = false;
    public float cooldown = 1f;
    private float lastAttackedAt;
    public float moveSpeed;
    public float howClose;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerAlive = player.GetComponent<NewPlayerController>().isAlive;
        dist = Vector3.Distance(player.position, transform.position);
        if(dist <= howClose && isPlayerAlive)
        {
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }

        if ((lastAttackedAt += Time.deltaTime) >= cooldown)
        {
            lastAttackedAt = 0.0f;
            isHit = false;
        }

        if (dist <= 1f && !isHit && isPlayerAlive)
        {
            player.GetComponent<NewPlayerController>().GetHit(20);
            isHit = true;
        }
    }
}
