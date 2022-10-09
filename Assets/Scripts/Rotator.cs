using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float xRotation;
    public float yRotation;
    public float zRotation;
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(xRotation,yRotation,zRotation)*Time.deltaTime*speed);
    }
}
