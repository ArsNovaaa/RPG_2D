using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        AudioManager.instance.PlaySFX(14, null);
    }

    public override void Exit()
    {
        base.Exit();

        AudioManager.instance.StopSFX(14);
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);


        if (xInput == 0 || player.IsWallDetected())
            stateMachine.ChangeState(player.idleState);
        //TODO:开启菜单脚步声不停
        if (Input.GetKeyDown(KeyCode.C)|| Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.O))
            AudioManager.instance.StopSFX(14);
    }
}
