using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float climbForce = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();

        
    }

    void MovePlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerRb.velocity = new Vector3(transform.position.x, climbForce, transform.position.z);
        }
    }
}
