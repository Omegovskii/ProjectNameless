using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThrowingSword : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _target;

    private void Start()
    {
        UseAbiliti();
    }

    private void Update()
    {
        
    }

    public void UseAbiliti()
    {
        _rigidbody.AddForce(_target.transform.forward * 1000f);

        //StartCoroutine(GoTo());
    }

    private IEnumerator GoTo()
    {
        int i = 0;
        Debug.Log(i);

        while (i++ < 100)
        {
            Vector3.MoveTowards(transform.position, _target.position, 0.1f);
            yield return null;
        }

        yield return null;
    }
}
