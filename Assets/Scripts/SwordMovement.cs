using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    

    private void Start()
    {
        //StartCoroutine(GoTo());
    }

    private void Update()
    {
        
    }

    private IEnumerator GoTo()
    {
        int i = 0;
        Debug.Log(i);
        while (i++ < 100)
        {

            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, 0.1f); ;

            Debug.Log(i);
            yield return null;
        }


        yield return null;
    }
}
