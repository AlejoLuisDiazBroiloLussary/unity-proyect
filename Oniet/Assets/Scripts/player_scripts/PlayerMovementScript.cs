using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private float player_stats_speed = 0.5f;
    private PlayerInput player_input;
    private Rigidbody2D player_rb;
    private Vector2 direction_raw;

    private enum MovementState{
        Walking,
        Dashing,
        Attacking,
        Rooted,
        Interacting,
    }

    private void Awake() {
        player_rb = GetComponent<Rigidbody2D>();
        player_input = GetComponent<PlayerInput>();
    }    

    private void Update() {
        direction_raw = player_input.actions["default_movement"].ReadValue<Vector2>().normalized;  
    }

    private void FixedUpdate() {
        player_rb.velocity = direction_raw * player_stats_speed;
        Debug.Log(direction_raw);
    }

}
