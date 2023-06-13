using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{

    public enum Scenes 
    { 
        MainMenu,
        LevelOne,
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapActiveScene(Scenes activeScene, bool unloadOtherScenes)
    {
        for (int i = 0; i < Enum.GetNames(typeof(Scenes)).Length; i++)
        {
            if ((int)activeScene != i && unloadOtherScenes) SceneManager.UnloadSceneAsync(i);
            else if ((int)activeScene == i) SceneManager.LoadScene((int)activeScene);
        }
    }
}
