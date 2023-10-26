using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MovementInput {get; private set;}
    public bool DashInput {get; private set;}
    
    public void OnMoveInput(InputAction.CallbackContext context){
        MovementInput = context.ReadValue<Vector2>().normalized;
    }

    public void OnDashInput(InputAction.CallbackContext context){
        if (context.performed){
            DashInput = true;
        }
    }
    public void UseDashInput(){
        DashInput = false;
    }
}
