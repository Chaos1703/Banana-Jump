using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance; 


    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    void LoadGamePlay(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }

    public void RestartGame(){
        Invoke("LoadGamePlay" , 2f);
    }
}
