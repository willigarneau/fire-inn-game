using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    private Animator _animator;
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();

        InvokeRepeating("WalkAnimation", 3f, 20f);  //1s delay, repeat every 1s
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WalkAnimation()
    {
        Debug.Log("stand");
        _animator.SetBool("stand", true);

        // walk a lil bit
        _animator.SetBool("walk", true);

        _animator.SetBool("walk", false);

        _animator.SetBool("stand", false);
    }
}
