using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private int _forceJump;
    [SerializeField] private Transform _target;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private Coroutine _activeCoroutine;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _direction = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
        _rigidbody.velocity =Vector3.ClampMagnitude(_direction, 1f) * _speed;       

        float angleRotation = 1f;

        if (Vector3.Angle(Vector3.forward, _direction) > angleRotation || Vector3.Angle(Vector3.forward, _direction) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _direction, _speed, 0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        if (_direction.x != 0 || _direction.z != 0)
            _animator.SetBool("Walk", true);
        else
            _animator.SetBool("Walk", false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            UseAbiliti();
    }

    private void UseAbiliti()
    {
        StartCoroutine(TakeJump());
    }

    private IEnumerator TakeJump()
    {
        Vector3 target = _target.position;

        _animator.SetBool("Attack",true);

        while (transform.position.x != target.x && transform.position.z != target.z)
        {
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x,transform.position.y,transform.position.z), 
                                                       new Vector3(target.x, transform.position.y, target.z),15 * Time.deltaTime);
            yield return null;
        }

        _animator.SetBool("Attack", false);

        yield return null;
    }
}
