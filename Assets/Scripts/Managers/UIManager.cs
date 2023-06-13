using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public enum Canvases 
    { 
        MainMenu,
        Gameplay,
        Pause,
        Settings,
        NextLevel,
        GameOver
    }

    public Canvas[] canvasComponents;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapActiveCanvas(Canvases canvas, bool disableOtherCanvases)
    {
        for (int i = 0; i < canvasComponents.Length; i++)
        {
            if ((int)canvas != i && disableOtherCanvases) canvasComponents[i].gameObject.SetActive(false);
            else if ((int)canvas == i) canvasComponents[i].gameObject.SetActive(true);
        }
    }
}
