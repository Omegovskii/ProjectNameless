using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThrowingSword : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Transform _target;

    private Vector3 _direction;

    private void Start()
    {
        _direction = new Vector3(transform.position.x - 20, 0, 0);
        _rigidbody.velocity = _direction;
    }

    private void Update()
    {
        
    }

    public void UseAbiliti()
    {
        
    }
}
