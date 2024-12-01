using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class ContextMenuActions : MonoBehaviour
{
    #region Smooth Motion
    /// <summary>
    /// Teleportation
    /// </summary>
    public ActionBasedControllerManager controllerManager;
    public Text smoothMotionText;
    #endregion

    #region Movement Speed
    /// <summary>
    /// Movement speed
    /// </summary>
    public DynamicMoveProvider movementProvider;
    public Text movementSpeedText;
    public float movementSpeedStep;
    #endregion


    public void PressSmoothMotion()
    {
        bool value = controllerManager.smoothMotionEnabled;
        value = !value;
        controllerManager.smoothMotionEnabled = value;
        smoothMotionText.text = value ? "Enabled" : "Disabled";
    }


    public void PressMovementSpeedMinus()
    {
        float value = movementProvider.moveSpeed - movementSpeedStep;
        if (value < 0)
            return;
        movementProvider.moveSpeed = value;
        movementSpeedText.text = value.ToString();
    }

    public void PressMovementSpeedPlus()
    {
        float value = movementProvider.moveSpeed + movementSpeedStep;
        movementProvider.moveSpeed = value;
        movementSpeedText.text = value.ToString();
    }

    public void PressExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
