using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerJumpState : PlayerState
{
    private float jumpTime;
    private float holdTime;
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        jumpTime = 0.2f;
        holdTime = 0.35f;
        rb.velocity = new Vector2(0,0);
        rb.velocity = new Vector2(rb.velocity.x, player.jumpForce);
        player.jumpCount--;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        jumpTime -= Time.deltaTime;
        holdTime -= Time.deltaTime;
        player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);

        if (Input.GetKey(KeyCode.Space) &&jumpTime<0&& holdTime > 0 && player.jumpCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, player.jumpForce * 0.65f);
        }
        /*if (Input.GetKey(KeyCode.Space)&&jumpTime<0&&player.jumpCount>0)
        {
            stateMachine.ChangeState(player.holdJump);
        }*/
        else if (rb.velocity.y < 0)
            stateMachine.ChangeState(player.airState);
    }
}
