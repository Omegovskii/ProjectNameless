using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Vector3 _location;
    private Quaternion _rotation;

    public Vector3 Location => _location;
    public Quaternion Rotation => _rotation;

    public void GetTransform()
    {
        _location = transform.position;
        _rotation = transform.rotation;
    }
}
