using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    // Start is called before the first frame update
   public void loadVolley()
    {
        SceneManager.LoadScene("LevelVolley");
    }

    public void loadSeista()
    {
        SceneManager.LoadScene("LevelSeista");
    }

    public void goBack()
    {
        SceneManager.LoadScene("LevelBegin");
    }
    //public void loadCook()
    //{
    //    SceneManager.LoadScene("LevelCook");
    //}
}
