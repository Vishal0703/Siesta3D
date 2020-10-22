using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public float speed, jumpForce;
    public Transform ball, groundCheck;
    public float ballOffset;
    public AudioClip jumpSFX;
    public float pushMag = 100f;
    public Transform midobj;
    

    public LayerMask whatIsGround;

    bool isGrounded = true;
    float _vz, _vy;
    Rigidbody _rigidbody;
    //AudioSource _audio;
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

    private void Update()
    {
        //ball.position;\
        //if (ball.position.z > midobj.position.z)
        //{
            //isGrounded = Physics.Raycast(transform.position, groundCheck.position - transform.position, (float)(2.0), whatIsGround);
            //if (ball.position.y >= transform.position.y && isGrounded && Vector3.Distance(ball.position, transform.position) <= ballOffset)
            //    DoJump();
            if ((Vector3.Distance(ball.position, transform.position) <= ballOffset) && (ball.position.z > midobj.position.z))
            {
                Vector3 dir = (ball.position-transform.position).normalized;
                transform.Translate(0, dir.y*speed*Time.deltaTime, dir.z*speed*Time.deltaTime);
            }
            else if(((Vector3.Distance(ball.position, transform.position) > ballOffset) | (ball.position.z < midobj.position.z))&&(groundCheck.position.y>=0.1))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
        //}
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Ball" && other.gameObject.transform.position.z > midobj.position.z)
    //    {
    //        isGrounded = Physics.Raycast(transform.position, groundCheck.position - transform.position, (float)(2.0), whatIsGround);
    //        if (ball.position.y <= (transform.position.y + ballOffset) && isGrounded)
    //            DoJump();
    //    }
    //}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 temp = collision.gameObject.GetComponent<Transform>().position - transform.position;
            temp = temp.normalized;
            //Debug.Log($"Direction of force {temp.y} , {temp.z}");
            rb.AddForce(new Vector3(0, temp.y * pushMag, temp.z * pushMag));
            //if(temp.z >= 0)
            //    rb.AddForce(new Vector3(0, pushMag, pushMag));
            //else
            //    rb.AddForce(new Vector3(0, pushMag, -pushMag));


        }
    }

    //void Update()
    //{
    //    _vy = _rigidbody.velocity.y;

    //    _destinationPoint = Mathf.Clamp(ball.position.z + ballOffset, 2.5f, 7f);
    //    if (transform.position.z <= _destinationPoint + 0.1f && transform.position.z >= _destinationPoint - 0.1f && transform.position.y < ball.position.y)
    //    {
    //        isGrounded = Physics.Raycast(transform.position, groundCheck.position - transform.position, (float)(2.0), whatIsGround);
    //        if (isGrounded)
    //            DoJump();
    //    }
    //    else
    //    {
    //        var step = speed * Time.deltaTime;
    //        if (_destinationPoint - transform.position.z < 0)
    //        {
    //            transform.Translate(0, 0, -step);
    //        }
    //        else if (_destinationPoint - transform.position.z > 0)
    //        {
    //            transform.Translate(0, 0, step);
    //        }
    //    }
    //}


    void DoJump()
    {
        // reset current vertical motion to 0 prior to jump
        _vy = 0f;
        // add a force in the up direction
        _rigidbody.AddForce(new Vector3(0, jumpForce, 0));
        isGrounded = false;
        // play the jump sound
        //PlaySound(jumpSFX);
    }

    //void PlaySound(AudioClip clip)
    //{
    //    _audio.PlayOneShot(clip);
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ballOffset);
    }
}
