using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : Enemydamage
{
    [Header("SpikeHead attributes")]
     [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3[] directions = new Vector3[4];
    private float checkTimer;
    private Vector3 destination;
    private bool attacking;

    

    private void OnEnable()
    {
        Stop();
    }

    private void Update()
    {
        //move spikehead if only attacking
        if(attacking)
        transform.Translate(destination * Time.deltaTime * speed);

        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                checkForPlayer();
        }
    }
    private void checkForPlayer()
    {
        CalculateDirection();

        //check if spikehead sees the player
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

            if (hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }
    private void CalculateDirection()
    {
        directions[0] = transform.right * range;//right
        directions[1] = -transform.right * range;//right
        directions[2] = transform.up * range;//up
        directions[2] = -transform.up * range;//down
    }
    private void Stop()
    {
        destination = transform.position;
        attacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Stop();
    }
}