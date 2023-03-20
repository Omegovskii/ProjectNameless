using System.Collections;
using UnityEngine;
using UnityEngine.Events;

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
    ThrowingSword throwingSword;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();

        throwingSword = Instantiate(_throwingSword, _sword.position, _sword.rotation);
        throwingSword.gameObject.SetActive(false);
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
        //ThrowingSword throwingSword = Instantiate(_throwingSword, _sword.position, _sword.rotation);
        throwingSword.transform.position = _sword.position;
        throwingSword.transform.rotation = _sword.rotation;
        throwingSword.gameObject.SetActive(true);
        throwingSword.GetDirection(_direction);
        throwingSword.Moved += OnMoved;
    }

    private void OnMoved(Vector3 position)
    {
        Debug.Log("Должен был переместиться on Moved");
        gameObject.transform.position = position;
        
    }

    private void OnEnable()
    {
        Debug.Log("Должен был переместиться on Eneble");
    }

    private void OnDisable()
    {
        throwingSword.Moved -= OnMoved;
        Debug.Log("Должен был переместиться - отписался");
    }
}
