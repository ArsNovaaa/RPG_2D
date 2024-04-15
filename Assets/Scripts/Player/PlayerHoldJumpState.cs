using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldJumpState : PlayerState
{
    private float holdTime;
    public PlayerHoldJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        holdTime = 0.15f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        holdTime -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space)&&holdTime>0)
        {
            rb.velocity = new Vector2(rb.velocity.x, player.jumpForce*0.6f);
        }
        else if (rb.velocity.y < 0)
            stateMachine.ChangeState(player.airState);
        if (Input.GetKeyDown(KeyCode.Space) && player.jumpCount > 0)
            stateMachine.ChangeState(player.jumpState);
    }
}
