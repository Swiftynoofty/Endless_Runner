using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float LazerSpeed; //adjust this in the inspector to make the scroll speed less or more
    public playerControll laserSpeed;

    void Update()
    {
        
        transform.position = new Vector3(laserSpeed.speed, 0, 0);
    }
}