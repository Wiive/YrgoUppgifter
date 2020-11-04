using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;


    void Start()
    {
        if (instance == null)
        {
            instance = this; //Save our object so we can use it easily
        }
        else
        { 
            Destroy(this);   //If we already have an instance, avoid creating another.
        }
        
        DontDestroyOnLoad(instance);
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
  
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void  LoadNextScene()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        nextIndex = nextIndex % SceneManager.sceneCount;
        SceneManager.LoadScene(nextIndex);
    }

    public void LoadPreviousScene()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex -1 + SceneManager.sceneCount;
        nextIndex = nextIndex % SceneManager.sceneCount;
        SceneManager.LoadScene(nextIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) //Next scene
        {
            LoadNextScene();
        }
        if (Input.GetKeyDown(KeyCode.B)) //Back scene
        {
            LoadPreviousScene();
        }
    }
}
