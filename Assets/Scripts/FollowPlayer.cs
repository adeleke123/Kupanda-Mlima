using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(25, 0, -20);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
<<<<<<< HEAD

=======
        transform.position = player.transform.position + offset;
>>>>>>> 31421fc3bbf41bb6fa01817d718ef893a689765f
    }
}