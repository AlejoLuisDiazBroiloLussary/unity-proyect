using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{   
    //flags
    public bool can_dash {get; private set;}
    private float last_time_dash;
    // variables
    private Vector2 dash_direction;
    //
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        can_dash = false;
        player.inputHandler.UseDashInput();

        dash_direction = player.RB.velocity.normalized;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.SetVelocity(playerData.dash_velocity * dash_direction);
        if (Time.time >= startTime + playerData.dash_time){
                player.RB.drag = 0f;
                isAbilityDone = true;
                last_time_dash = Time.time;
            }
    }

    public bool CheckCanDash() => can_dash && Time.time >= playerData.dash_cooldown + last_time_dash;
    public void ResetCanDash() => can_dash = true;
}
