using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Transform _sword;
    [SerializeField] private ThrowingSword _throwingSword;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _direction = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
        _rigidbody.velocity = Vector3.ClampMagnitude(_direction, 1f) * _speed;

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

    private void GetTransform()
    {
        ThrowingSword throwingSword = Instantiate(_throwingSword, _sword.position, _sword.rotation);
        throwingSword.GetDirection(_direction);
    }

    private void OnMoved(Vector3 position)
    {
        transform.position = position;
        Debug.Log("Должен был переместиться");
    }

    private void OnEnable()
    {
        _throwingSword.Moved += OnMoved;
        Debug.Log("Должен был переместиться");
    }

    private void OnDisable()
    {
        _throwingSword.Moved -= OnMoved;
        Debug.Log("Должен был переместиться - отписался");
    }
}
