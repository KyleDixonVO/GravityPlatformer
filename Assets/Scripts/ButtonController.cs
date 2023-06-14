using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    public static ButtonController currentButton;
    public UIManager.Canvases canvasToSwapTo;
    public bool unloadOtherCanvases;
    public LevelManager.Scenes sceneToSwapTo;
    public bool unloadOtherScenes;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendSwapCallToUI()
    {
        Debug.Log("Clicked button" + currentButton.name);
        currentButton = this;
        UIManager.UI.SwapActiveCanvas(canvasToSwapTo, unloadOtherCanvases);
        
    }

    public void SendSwapCallToLevel()
    {
        Debug.Log("Clicked button " + currentButton.name);
        currentButton = this;
        LevelManager.LM.SwapActiveScene(sceneToSwapTo, unloadOtherScenes);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }


}
