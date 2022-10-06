using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float scroll = 10f;

    void Update()
    {
        rigidbody.velocity = new Vector2(scroll, 0f);
    }
}