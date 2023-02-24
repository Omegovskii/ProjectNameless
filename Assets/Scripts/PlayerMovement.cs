using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;

    private CharacterController _controller;
    private Animator _animator;
    private Vector3 _direction;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        _direction = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
        _controller.Move(_direction * _speed * Time.deltaTime);

        if (Vector3.Angle(Vector3.forward, _direction) > 1f || Vector3.Angle(Vector3.forward, _direction) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _direction, _speed, 0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        if (_direction.x != 0 || _direction.z != 0)
            _animator.SetBool("Walk", true);
        else
            _animator.SetBool("Walk", false);
    }
}
