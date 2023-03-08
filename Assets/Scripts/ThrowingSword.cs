using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThrowingSword : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Rigidbody _rigidbody;

    private void Start()
    {

    }

    public void UseAbiliti()
    {
        _rigidbody.AddForce(Vector3.forward, ForceMode.Impulse);
    }
}
