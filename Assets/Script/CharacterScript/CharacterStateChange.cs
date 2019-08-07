using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateChange : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer Sprite;
    private Vector2 DeadPos = new Vector2(0, 0);
    public float DeadDelay;
    public float DeadHeight;
    public float DeadSpeed;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
    }
    public void StateChange(bool IsCanJump,float MoveDir)
    {
        //3、地面状态切换
        if (IsCanJump)
        {
            if (MoveDir != 0)
            {
                anim.SetFloat("State", 0.5f);
            }
            else
            {
                anim.SetFloat("State", 0f);
            }
        }
        //4、控制的状态切换
        else if (!IsCanJump)
        {
            anim.SetFloat("State", 1f);
        }
        //5、根据玩家前行的方向，控制角色的面朝向
        if (MoveDir > 0)
        {
            Sprite.flipX = false;
        }
        else if (MoveDir < 0)
        {
            Sprite.flipX = true;
        }
    }
    public void AliveandDeadStateController(PlayerState State,bool IsJump,float MoveDir)
    {
        if (State == PlayerState.Alive)
        {
            StateChange(IsJump,MoveDir);
        }
        else if (State == PlayerState.Dead || State == PlayerState.Death)
        {
            anim.SetFloat("State", 1.5f);
        }
    }
    
}
