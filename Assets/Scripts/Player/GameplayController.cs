using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayController : MonoBehaviour, Controls.IGameplayActions
{
    private Controls.GameplayActions gameplayActions;

    public static event Action<Vector2> OnAimChanged;

    private void Awake()
    {
        Controls controls = new Controls();
        gameplayActions = controls.Gameplay;
        gameplayActions.SetCallbacks(this);
    }

    private void Start() => OnAimChanged?.Invoke(Vector2.right);

    private void OnEnable() => gameplayActions.Enable();
    private void OnDisable() => gameplayActions.Disable();

    public void OnAim(InputAction.CallbackContext context) => OnAimChanged?.Invoke(context.ReadValue<Vector2>());
}
