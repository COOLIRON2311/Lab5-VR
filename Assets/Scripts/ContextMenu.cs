using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class ContextMenu : MonoBehaviour
{
    private bool visible;
    static bool? smoothMotion;
    static float? movementSpeed;
    
    public GameObject playerHead;
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

    private void Awake()
    {
        visible = false;
        gameObject.SetActive(visible);
        smoothMotion ??= controllerManager.smoothMotionEnabled;
        controllerManager.smoothMotionEnabled = smoothMotion.Value;
        smoothMotionText.text = smoothMotion.Value ? "Enabled" : "Disabled";
        
        movementSpeed ??= movementProvider.moveSpeed;
        movementSpeedText.text = movementSpeed.Value.ToString();
        movementProvider.moveSpeed = movementSpeed.Value;
    }

    public void UpdateMenu()
    {
        visible = !visible;
        gameObject.SetActive(visible);

        // Position
        var forward = playerHead.transform.forward;
        forward.y = 0;
        forward = forward.normalized;
        gameObject.transform.position = playerHead.transform.position + forward;

        // Rotation
        var rotation_y = playerHead.transform.rotation.eulerAngles.y;
        var angles  = gameObject.transform.eulerAngles;
        angles.y = rotation_y;
        gameObject.transform.eulerAngles = angles;
    }

    public void PressSmoothMotion()
    {
        smoothMotion = !smoothMotion;
        controllerManager.smoothMotionEnabled = smoothMotion.Value;
        smoothMotionText.text = smoothMotion.Value ? "Enabled" : "Disabled";
    }


    public void PressMovementSpeedMinus()
    {
        float value = movementSpeed.Value - movementSpeedStep;
        if (value < 0)
            return;
        movementSpeed = value;
        movementProvider.moveSpeed = value;
        movementSpeedText.text = value.ToString();
    }

    public void PressMovementSpeedPlus()
    {
        float value = movementSpeed.Value + movementSpeedStep;
        movementSpeed = value;
        movementProvider.moveSpeed = value;
        movementSpeedText.text = value.ToString();
    }

    public void PressToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PressCloseMenu()
    {
        UpdateMenu();
    }
}
