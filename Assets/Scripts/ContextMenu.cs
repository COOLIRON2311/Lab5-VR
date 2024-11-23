using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class ContextMenu : MonoBehaviour
{
    public InputActionReference inputReference;
    public GameObject menu;
    public GameObject playerHead;

    private InputAction menuAction;
    private bool visible;

    void Awake()
    {
        visible = false;
        menu.SetActive(visible);
        menuAction = inputReference.action;

        menuAction.performed += UpdateMenu;
    }

    private void UpdateMenu(InputAction.CallbackContext context)
    {
        visible = !visible;
        
        menu.SetActive(visible);

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

    void Update()
    {  
        
    }
}
