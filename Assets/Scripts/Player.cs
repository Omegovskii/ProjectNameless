using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ThrowingSword _throwingSword;
    [SerializeField] private Sword _sword;
    [SerializeField] private PlayerMovement _movement;

    private Vector3 _location;
    private Quaternion _rotation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            UseAbiliti();
    }

    private void UseAbiliti()
    {
        Debug.Log("Хрен там! Не спавнится");
        _throwingSword.transform.position = _location;
        _throwingSword.transform.rotation = _rotation;
        Instantiate(_throwingSword, _location, _rotation);
        _throwingSword.UseAbiliti();
    }

    private void GetTransform()
    {
        _location = _sword.transform.position;
        _rotation = _sword.transform.rotation;
        Debug.Log("Координаты получены "+ _location.x +" "+ _location.y +" "+ _location.z +" ");
        Debug.Log("Координаты получены " + _rotation.x + " " + _rotation.y + " " + _rotation.z + " ");
    }


}
