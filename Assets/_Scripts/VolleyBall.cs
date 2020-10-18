using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolleyBall : MonoBehaviour
{
    public VolleyScoreCounter counter;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerPart")
        {
            counter.AddEnemyScore();
            transform.position = spawnPoint.position;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (other.gameObject.name == "EnemyPart")
        {
            counter.AddPlayerScore();
            transform.position = spawnPoint.position;
            GetComponent<Rigidbody>().velocity = Vector3.zero;

        }
    }
}
