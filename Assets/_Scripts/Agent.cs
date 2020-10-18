using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // include so we can load new scenes
using UnityStandardAssets.CrossPlatformInput;

public class Agent : MonoBehaviour
{
    // Start is called before the first frame update

    [Range(0.0f, 10.0f)] // create a slider in the editor and set limits on moveSpeed
    public float moveSpeed = 3f;

    public float pushMag = 100f;

    public float jumpForce = 600f;
    public AudioClip jumpSFX;
    public AudioClip hitSFX;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    Transform _transform;
    Rigidbody _rigidbody;
    Animator _animator;
    AudioSource _audio;

    float _vz, _vy;
    bool isRunning = false;
    bool isGrounded = false;
    void Awake()
    {
        _transform = GetComponent<Transform>();

        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null) // if Rigidbody is missing
            Debug.LogError("Rigidbody component missing from this gameobject");

        _animator = GetComponent<Animator>();
        if (_animator == null) // if Animator is missing
            Debug.LogError("Animator component missing from this gameobject");

        _audio = GetComponent<AudioSource>();
        if (_audio == null)
        { // if AudioSource is missing
            Debug.LogWarning("AudioSource component missing from this gameobject. Adding one.");
            // let's just add the AudioSource component dynamically
            _audio = gameObject.AddComponent<AudioSource>();
        }

    }

    // Update is called once per frame
    void Update()
    {

        //_vz = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        //// Determine if running based on the horizontal movement
        //if (_vz != 0)
        //{
        //    isRunning = true;
        //}
        //else
        //{
        //    isRunning = false;
        //}
        //_vy = _rigidbody.velocity.y;

        //// Check to see if character is grounded by raycasting from the middle of the player
        //// down to the groundCheck position and see if collected with gameobjects on the
        //// whatIsGround layer
        //isGrounded = Physics.Raycast(_transform.position, groundCheck.position - _transform.position, (float)(1.0), whatIsGround);

        //// Set the grounded animation states
        ////_animator.SetBool("Grounded", isGrounded);

        //if (isGrounded && CrossPlatformInputManager.GetButtonDown("Jump")) // If grounded AND jump button pressed, then allow the player to jump
        //{
        //    DoJump();
        //    isGrounded = false;
        //}

        //if (CrossPlatformInputManager.GetButtonUp("Jump") && _vy > 0f)
        //{
        //    _vy = 0f;
        //}

        //// Change the actual velocity on the rigidbody
        //_rigidbody.velocity = new Vector3(0, _vy, _vz * moveSpeed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 temp = collision.gameObject.GetComponent<Transform>().position - _transform.position;
            temp = temp.normalized;
            //rb.AddForce(new Vector3(0, temp.y*pushMag, temp.z*pushMag));
            if (temp.z >= 0)
                rb.AddForce(new Vector3(0, pushMag, pushMag));
            else
                rb.AddForce(new Vector3(0, pushMag, -pushMag));


        }
    }

    void DoJump()
    {
        // reset current vertical motion to 0 prior to jump
        _vy = 0f;
        // add a force in the up direction
        _rigidbody.AddForce(new Vector3(0, jumpForce, 0));
        // play the jump sound
        PlaySound(jumpSFX);
    }

    void PlaySound(AudioClip clip)
    {
        _audio.PlayOneShot(clip);
    }
}
