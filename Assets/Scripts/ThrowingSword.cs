using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ThrowingSword : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private Vector3 _direction;
    private float _timeElapsed = 0;

    public event UnityAction <Vector3> Moved;

    private void Start()
    {
        _rigidbody.velocity = _direction * 25;
    }

    private void Update()
    {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > 0.3f)
        {
            _rigidbody.velocity = Vector3.zero;
            Moved?.Invoke(transform.position);
        }
    }
    
    public void GetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public Vector3 SentPosition(Vector3 position)
    {
        return position;
    }


}
