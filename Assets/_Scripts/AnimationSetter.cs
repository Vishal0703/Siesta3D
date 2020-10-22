using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSetter : MonoBehaviour
{
    // Start is called before the first frame update
    Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        if (_animator == null) // if Animator is missing
            Debug.LogError("Animator component missing from this gameobject");

        _animator.SetBool("Sleep", true);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
