﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    private Vector3 moveDirection;
    public int minSwipeRecognition = 500;
    private Vector2 swipePositionLastFrame;
    private Vector2 swipePositionCurrentFrame;
    private Vector2 currentSwipe;
    private Vector3 nextCollisionPosition;
    private bool isMoving;

    private float defaultSpeed;
    public float speed = 7;
    public bool hasPowerup;
    public float slowSpeed = 5.0f;
    public float fastSpeed = 10.0f;
    public GameObject powerupIndicator;



    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = speed;
    }

    // Update is called once per frame
    private void Update()
    {

        MovePlayer();
       






    }



    void MovePlayer()
    {

        if (isMoving)
        {

            playerRb.velocity = moveDirection * speed;




        }
        // Swiping 
        if (Input.GetMouseButton(0))
        {


            swipePositionCurrentFrame = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            if (swipePositionLastFrame != Vector2.zero)
            {
                currentSwipe = swipePositionCurrentFrame - swipePositionLastFrame;

                if (currentSwipe.sqrMagnitude < minSwipeRecognition)

                    return;


                currentSwipe.Normalize();



                if (currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    // Go left/right

                    SetDestination(currentSwipe.x > 0 ? Vector3.right : Vector3.left);

                }
            }

            swipePositionLastFrame = swipePositionCurrentFrame;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
            swipePositionLastFrame = Vector2.zero;
            currentSwipe = Vector2.zero;

        }

    }

    private void SetDestination(Vector3 direction)
    {
        moveDirection = direction;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 100f))

        {
            nextCollisionPosition = hit.point;
        }

        isMoving = true;

    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
        speed = defaultSpeed;

    }
    IEnumerator ThornCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        speed = defaultSpeed;
    }
    private void OnCollisionEnter(Collision other)
    {
        // if player collides with rocks, game over.
        if (other.gameObject.CompareTag("Rock"))
        {
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }

        // if player collides with thorns, slow speed
        else if (other.gameObject.CompareTag("Thorn"))
        {
            speed = slowSpeed;
            Destroy(other.gameObject);
            StartCoroutine(ThornCountdownRoutine());
        }
        //if player collides with powerup, increase speed
        else if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
            speed = fastSpeed;

           

        }

       
        




    }
}