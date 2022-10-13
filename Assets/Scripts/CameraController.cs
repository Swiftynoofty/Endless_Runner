using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float Offset = 1.0f;
    

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + Offset, transform.position.y, transform.position.z);
    }
}