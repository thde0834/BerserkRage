using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, Controls.IGameplayActions
{
    [SerializeField] private Vector2Variable AimVector;

    private Controls.GameplayActions gameplayActions;

    private void Awake()
    {
        Controls controls = new Controls();
        gameplayActions = controls.Gameplay;
        gameplayActions.SetCallbacks(this);
    }

    private void OnEnable() => gameplayActions.Enable();
    private void OnDisable() => gameplayActions.Disable();

    public void OnAim(InputAction.CallbackContext context) => AimVector.SetValue(context.ReadValue<Vector2>());
}
