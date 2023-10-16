using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //States
    #region

    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    
    #endregion
    // unity objects
    #region 
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }

    #endregion
    // my objects
    #region
    public PlayerInputHandler inputHandler { get; private set; }
    [SerializeField]
    private PlayerData playerData;

    #endregion
    // variables
    #region 
    [SerializeField]
    private Vector2 work_space;
    #endregion
    //Unity methods
    #region 
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "Idle");
        MoveState= new PlayerMoveState(this, StateMachine, playerData, "Move");
        DashState= new PlayerDashState(this, StateMachine, playerData, "Dash");
    }

    private void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        inputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();

    }
    #endregion 
    // my methods
    #region 
    //Move Methods
    #region 
    public void SetVelocity(Vector2 velocity)
    {
        work_space = velocity;

        RB.velocity = work_space;
    }
    #endregion
    // Dash Methods
    #region 
    public void OnDash(){
        StateMachine.ChangeState(DashState);
    }
    #endregion
    #endregion

}
