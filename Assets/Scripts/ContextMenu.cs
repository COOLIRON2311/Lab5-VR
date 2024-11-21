using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class ContextMenu : MonoBehaviour
{
    /// <summary>
    /// Teleportation
    /// </summary>
    public ActionBasedControllerManager controllerManager;
    /// <summary>
    /// Movement speed
    /// </summary>
    public DynamicMoveProvider moveProvider;
    public InputActionReference inputReference;
    public GameObject menu;
    public GameObject playerHead;

    private InputAction grabAction;

    void Awake()
    {
        menu.SetActive(false);
        grabAction = inputReference.action;
    }

    void Update()
    {
        float value = grabAction.ReadValue<float>();
        if (value == 0)
            return;
        
        menu.SetActive(true);

        // Position
        var forward = playerHead.transform.forward;
        forward.y = 0;
        forward = forward.normalized;
        menu.transform.position = playerHead.transform.position + forward;

        // Rotation
        var rotation_y = playerHead.transform.rotation.eulerAngles.y;
        var angles  = menu.transform.eulerAngles;
        angles.y = rotation_y;
        menu.transform.eulerAngles = angles;

    }
}
