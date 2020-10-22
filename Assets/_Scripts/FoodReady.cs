using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodReady : MonoBehaviour
{
    // Start is called before the first frame update

    public float waitTime = 3;
    
    [HideInInspector]
    public static bool hotdogflag= false;
    [HideInInspector]
    public static bool hamburgerflag = false;
    [HideInInspector]
    public static bool dumplingflag = false;
    //GameObject[] foods;
    public GameObject hotdog;
    float startTime;
    void Start()
    {
        //foods = GameObject.FindGameObjectsWithTag("Food") as GameObject[];
        //this.enabled = false;
        startTime = Time.time;
        Debug.Log("I have started");
        //foreach(GameObject food in foods)
        //{
        //    if(food.name=="HotDog")
        //}
    }

    public void changehotdogbool()
    {
        hotdogflag = true;
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine("waittimer");
        if (Time.time >= startTime + waitTime)
        {
            Debug.Log("Time entered");
            if(hotdog != null && hotdogflag)
            {
                Debug.Log("HD");
                hotdog.SetActive(true);
                hotdogflag = false;
                this.gameObject.SetActive(false);
                
            }
            //foreach (GameObject food in foods)
            //{
            //    Debug.Log(food.name.ToString());
            //    if (food.name == "HotDogPlate")
            //    {
            //        Debug.Log("HD");
            //        food.SetActive(true);
            //        this.gameObject.SetActive(false);
            //    }
            //}
        }
        
    }
    IEnumerator waittimer()
    {
        yield return new WaitForSeconds(10f);
    }

}
