using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuActions : MonoBehaviour
{
    public void PressNewGame()
    {
        print("New game");
    }

    public void PressSettings()
    {
        print("Settings");
    }

    public void PressExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
