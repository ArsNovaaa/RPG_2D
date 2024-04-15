using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
    private float lastCommandTime; // 记录上次执行命令的时间
    private bool isCommandDelayed; // 命令是否被延迟
    public PlayerWallJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = 1f;
        player.SetVelocity(5 * -player.facingDir, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(player.airState);

        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
        /*if (!player.IsWallDetected())
            stateMachine.ChangeState(player.airState);*/
        if (!player.IsWallDetected())
        {
            if (!isCommandDelayed)
            {
                lastCommandTime = Time.time; // 更新上次执行命令的时间
                isCommandDelayed = true; // 将命令标记为已延迟
            }
            else if (Time.time - lastCommandTime > 0.2f) // 判断时间是否到达延迟时间
            {
                stateMachine.ChangeState(player.airState); // 执行命令
                isCommandDelayed = false; // 重置标记
            }
        }

    }

}
