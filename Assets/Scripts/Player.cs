using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ThrowingSword _throwingSword;
    [SerializeField] private Transform _sword;
    [SerializeField] private PlayerMovement _player;

    private Animator _animator;
    private Vector3 _position;
    private Quaternion _rotation;

    public Vector3 Position => _position;
    public Quaternion Rotation => _rotation;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool("Attack", true);
        }

        if (Input.GetKeyDown(KeyCode.N))
            _animator.SetBool("Attack", false);
    }

    private void GetTransform()
    {
        _position = _sword.position;
        _rotation = _sword.rotation;
        ThrowingSword sword = Instantiate(_throwingSword, _position, _rotation);
        sword.UseAbiliti();
    }


}
