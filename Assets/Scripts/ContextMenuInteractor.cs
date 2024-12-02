using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ContextMenuInteractor : MonoBehaviour
{
    public InputActionReference inputReference;
    public ContextMenu menu;
    

    private InputAction menuAction;

    void Awake()
    {
        menuAction = inputReference.action;
        menuAction.performed += UpdateMenu;
    }

    private void UpdateMenu(InputAction.CallbackContext context)
    {
        menu.UpdateMenu();
    }

    private void OnDestroy()
    {
        menuAction.performed -= UpdateMenu;
    }
}
