using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _animator;


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
}
