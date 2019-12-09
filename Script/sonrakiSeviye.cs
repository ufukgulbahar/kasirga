using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class sonrakiSeviye : MonoBehaviour
{
    private int prevSceneLoad;

    private void Start()
    {
        prevSceneLoad = SceneManager.GetActiveScene().buildIndex + 1; 
    }

    public void oyunagit()
    {
        SceneManager.LoadScene(prevSceneLoad);
    }
    public void restart()
    {
        SceneManager.LoadScene(prevSceneLoad-1);
    }
}
