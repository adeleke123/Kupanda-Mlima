using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float bottomLimit = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        // if player collides with rocks, game over.
        if (other.gameObject.CompareTag("Ground"))
        {

            Destroy(gameObject);

        }
    }
    }
