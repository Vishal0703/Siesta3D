using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public float speed, jumpForce;
    public Transform ball, groundCheck;
    public float ballOffset;
    public AudioClip jumpSFX;
    

    public LayerMask whatIsGround;

    bool isGrounded;
    float _vz, _vy;
    Rigidbody _rigidbody;
    //AudioSource _audio;
    float _destinationPoint;

    // Start is called before the first frame update
    void Start()
    {
        //_audio = GetComponent<AudioSource>();
        //if (_audio == null)
        //{ // if AudioSource is missing
        //    Debug.LogWarning("AudioSource component missing from this gameobject. Adding one.");
        //    // let's just add the AudioSource component dynamically
        //    _audio = gameObject.AddComponent<AudioSource>();
        //}

        _rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        _vy = _rigidbody.velocity.y;

        _destinationPoint = Mathf.Clamp(ball.position.z + ballOffset, 2.5f, 7f);
        if (transform.position.z <= _destinationPoint + 0.1f && transform.position.z >= _destinationPoint - 0.1f && transform.position.y < ball.position.y)
        {
            isGrounded = Physics.Raycast(transform.position, groundCheck.position - transform.position, (float)(1.0), whatIsGround);
            if (isGrounded)
                DoJump();
        }
        else
        {
            var step = speed * Time.deltaTime;
            if (_destinationPoint - transform.position.z < 0)
            {
                transform.Translate(0, 0, -step);
            }
            else if (_destinationPoint - transform.position.z > 0)
            {
                transform.Translate(0, 0, step);
            }
        }
    }


    void DoJump()
    {
        // reset current vertical motion to 0 prior to jump
        _vy = 0f;
        // add a force in the up direction
        _rigidbody.AddForce(new Vector3(0, jumpForce, 0));
        // play the jump sound
        //PlaySound(jumpSFX);
    }

    void PlaySound(AudioClip clip)
    {
        //_audio.PlayOneShot(clip);
    }
}
