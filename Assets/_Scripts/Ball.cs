using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip hitSFX, thudSFX;
    public Transform midobj;
    //public VolleyScoreCounter counter;
    public Transform ballspawnPoint;
    public Transform playerspawnPoint;
    public Transform enemyspawnPoint;

    VolleyScoreCounter counter;
    AudioSource _audio;
    GameObject _player;
    GameObject _enemy;
    void Start()
    {
        counter = GetComponent<VolleyScoreCounter>();
        _audio = GetComponent<AudioSource>();
        if (_audio == null)
        { // if AudioSource is missing
            Debug.LogWarning("AudioSource component missing from this gameobject. Adding one.");
            // let's just add the AudioSource component dynamically
            _audio = gameObject.AddComponent<AudioSource>();
        }

        _player = GameObject.FindGameObjectWithTag("Player");
        _enemy = GameObject.FindGameObjectWithTag("Enemy");



    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") | collision.gameObject.CompareTag("Enemy"))
            _audio.PlayOneShot(hitSFX);
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("here");
            _audio.PlayOneShot(thudSFX);
            if (transform.position.z > midobj.position.z)
            {
                Debug.Log("here2");

                counter.AddPlayerScore();
                transform.position = ballspawnPoint.position;
                _player.transform.position = playerspawnPoint.position;
                _enemy.transform.position = enemyspawnPoint.position;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            else
            {
                Debug.Log("here3");

                counter.AddEnemyScore();
                //Time.timeScale = 0.3f;
                //StartCoroutine("Waiter");
                transform.position = ballspawnPoint.position;
                _player.transform.position = playerspawnPoint.position;
                _enemy.transform.position = enemyspawnPoint.position;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
               // Time.timeScale = 1f;

            }
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(10f);
    }
}
