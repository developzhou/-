using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character : MonoBehaviour
{
    [HideInInspector]
    public CharacterMove move;
    [HideInInspector]
    public CharacterStateChange characterState;
    public GameMode Mode = GameMode.Normal;
    public PlayerState State = PlayerState.Alive;
    private void Start()
    {
        move = GetComponent<CharacterMove>();
        characterState = GetComponent<CharacterStateChange>();
    }
    private void Update()
    {
        //1、控制角色死亡和存活时的状态
      characterState.AliveandDeadStateController(State,move.IsJump,move.MoveDir);      
    }
    private void FixedUpdate()
    {
        //1、角色的移动和跳跃的逻辑
       move. MoveMethod();
        //2、角色跳跃的逻辑
        move.JumpMethod();
        //3、当角色到达平台边缘时，默认让角色下落
       //move.EdgeFall();
        //4、角色站在平台时，允许玩家使用按键让角色穿过平台
       move.Down();
       
    }
    //当角色站在平台上时，玩家按下方向键，允许角色穿过平台
}   