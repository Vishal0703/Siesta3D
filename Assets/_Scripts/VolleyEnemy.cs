using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolleyEnemy : MonoBehaviour
{
    public bool isGrounded;
    public float speed, jumpForce;
    public Transform ball, groundCheck;
    public float ballOffset;
public float destinationPoint;

public LayerMask whatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        destinationPoint = Mathf.Clamp(ball.position.z + ballOffset, 2.5f, 7f);
        if (transform.position.z <= destinationPoint + 0.1f && transform.position.z >= destinationPoint - 0.1f && transform.position.y < ball.position.y)
        {
            isGrounded = Physics.Raycast(transform.position, groundCheck.position-transform.position, (float)(1.0), whatIsGround);
            if (isGrounded)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0,GetComponent<Rigidbody>().velocity.z);
                GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
            }
        }
        else
        {
            var step = speed * Time.deltaTime;
            if (destinationPoint - transform.position.z < 0)
            {
                transform.Translate(0, 0, -step);
            }
            else if (destinationPoint - transform.position.z > 0)
            {
                transform.Translate(0, 0, step);
            }
        }
    }
}
