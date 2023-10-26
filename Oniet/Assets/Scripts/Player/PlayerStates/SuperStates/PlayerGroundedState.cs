using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    #region Inputs 
    protected Vector2 input;
    private bool DashInput;
    #endregion 
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        player.DashState.ResetCanDash();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        // input fetching
        input = player.inputHandler.MovementInput;
        DashInput = player.inputHandler.DashInput;
        // transitions
        if (DashInput){
            if (player.DashState.CheckCanDash()){
                stateMachine.ChangeState(player.DashState);
            }
            else{
                player.inputHandler.UseDashInput();
            }
        }
        

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
