using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController; //animacja

    private Transform player;
    private bool isPlayerAlive;
    private float dist;
    private bool isHit = false;
    private float lastAttackedAt;
    private float waitTime;
    private int randomSpot;

    public float cooldown = 1f;
    public float moveSpeed;
    public float howClose;
    public float startWaitTime;

    public Transform[] moveSpots;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }


    void Update()
    {
        isPlayerAlive = player.GetComponent<NewPlayerController>().isAlive;
        dist = Vector3.Distance(player.position, transform.position);
        Debug.Log(dist);
        //if (!(dist <= 1f))
        //{
        //    Patrol();
        //}
        if (dist <= howClose && isPlayerAlive)
        {
            transform.LookAt(player.position);
            GetComponent<CharacterController>().Move(transform.forward * moveSpeed * Time.deltaTime);
        }

        if (dist <= 2.3f && !isHit && isPlayerAlive)
        {
            isHit = true;
            player.GetComponent<NewPlayerController>().GetHit();
        }

        if ((lastAttackedAt += Time.deltaTime) >= cooldown)
        {
            lastAttackedAt = 0.0f;
            isHit = false;
        }
    }

    //void Patrol()
    //{
    //    transform.LookAt(moveSpots[randomSpot].transform);
    //    transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, moveSpeed * Time.deltaTime);
    //    if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
    //    {
    //        if(waitTime <= 0)
    //        {
    //            randomSpot = Random.Range(0, moveSpots.Length);
    //            waitTime = startWaitTime;
    //        }
    //        else
    //        {
    //            waitTime -= Time.deltaTime;
    //        }
    //    }
    //}
}
