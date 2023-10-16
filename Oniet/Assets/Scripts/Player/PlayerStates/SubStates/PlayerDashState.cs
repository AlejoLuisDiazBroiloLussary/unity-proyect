using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerDashingState
{
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("i entered dash");
        Debug.Log(player.RB.velocity);
        if(player.RB.velocity.x == 0){
            
            Debug.Log("i shouldn't dash");
        }
        player.StateMachine.ChangeState(player.IdleState);

    }

    public override void Exit()
    {
        Debug.Log("i exited dash");
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}