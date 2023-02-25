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
       // if (Input.GetMouseButton(1))
      // {
     //       _animator.SetBool("Attack", true);
      //  }
    }


}
