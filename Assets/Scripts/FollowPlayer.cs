using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float speedIncrease = 0.5f;
    
    
    

   


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + speedIncrease, transform.position.y, transform.position.z);
    }
}
