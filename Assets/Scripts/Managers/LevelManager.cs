using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager LM;

    public enum Scenes 
    { 
        MainMenu,
        LevelOne,
    }

    private void Awake()
    {
        if(LM == null)
        {
            LM = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (LM != null && LM != this)
        {
            Destroy(this.gameObject);
        }
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
        SceneManager.LoadScene((int)activeScene);
        for (int i = 0; i < Enum.GetNames(typeof(Scenes)).Length; i++)
        {
            if ((int)activeScene != i && unloadOtherScenes) SceneManager.UnloadSceneAsync(i);
        }
    }
}
