using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour
{
    public ContextMenu contextMenu;
    public LevelManager levelManager;

    public void PressNewGame()
    {
        levelManager.LoadLevel(1);
    }

    public void PressSettings()
    {
        contextMenu.UpdateMenu();
    }

    public void PressExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
