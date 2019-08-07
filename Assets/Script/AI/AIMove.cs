using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AIMove : MonoBehaviour
{
  
    public Transform CheckPointHeadForward;
    private bool IsEge;
    private bool HitWall;
    private bool HitPlayer;
    private int MoveDir = -1;
    public float MoveSpeed = 2f;
    public LayerMask mask;
    public void EnemyMove()
    {
        #region 当脚底落空转向的判断暂时被取消掉了
        //1、检测敌人是否走到平台的边缘
        /* if (!Physics2D.Linecast(transform.position, CheckPointfoot.position, mask.value))
         {
             IsEge = true;
         }
         else
         {
             IsEge = false;
         }*/
        #endregion
        //2、检测AI是否撞墙了
        if (Physics2D.Linecast(transform.position, CheckPointHeadForward.position, mask.value))
        {
            HitWall = true;
        }
        else
        {
            HitWall = false;
        }
        //3、当走到了平台的边缘或撞到墙了，控制角色转向并按照反方向行走
        if ( HitWall)
        {
            MoveDir = -MoveDir;
            transform.eulerAngles += new Vector3(0, -MoveDir * 180, 0);
        }
        //4、控制角色的行走
        transform.Translate(new Vector2(MoveDir, 0) * MoveSpeed * Time.deltaTime, Space.World);
    }
}
