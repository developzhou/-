using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    //1、敌人的脚部检查点被取消
    //2、敌人的前部攻击点被取消
    public Transform CheckPointHeadUp;
    public Transform CheckPointHeadLeft;
    public Transform CheckPointHeadRight;
    public Transform HitPlayerForward;
    public Transform HitPlayerBack;
    private Animator anim;
    private RaycastHit2D Hit2D;
    public LayerMask mask;
    private bool EnemyHit;
    private bool EnemyHitable;//判断角色是否可以再次的被弹起
    private bool Detection = true;
    [HideInInspector]
    public float TimeCount;
    public float TimeDelay;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
   
    //因为EnemyHit一直是false所以无法进入判断，总结在做条件判断前选择条件变量的方法
    private void OnCollisionEnter2D(Collision2D collision)
    {
        #region 标准版敌人死亡逻辑
        /* if (collision.transform.tag == "Player"&&EnemyHitable)
         {
                 collision.rigidbody.isKinematic = true;
                 StartCoroutine(PlayerUpHeight(collision.transform,collision.rigidbody));
                 PlayerHit();
         }*/
        #endregion
        #region 简化版死亡逻辑
        if (collision.transform.tag == "Player")
        {
          
        }
        #endregion
    }
    //判断敌人是否被主角踩到
    public void PlayerHit(ref EnemyState State)
    {       
          State = EnemyState.Death;
          GetComponent<Collider2D>().isTrigger = true;
          DeadEffect();
    }
    //1、控制动画播放延迟的先后顺序
    public void DeadEffect()
    {
        anim.SetBool("Death", true);
        StartCoroutine(DeadDelay(TimeDelay));
    }
    //当敌人撞到了角色后，让角色死亡
    public void PlayerDeath(EnemyState State)
    {
        if (State == EnemyState.Walking)
        {
            if (Physics2D.Linecast(transform.position, HitPlayerForward.position, mask.value))
            {
                Hit2D = Physics2D.Linecast(transform.position, HitPlayerForward.position, mask.value);
                Hit2D.transform.GetComponent<Character>().State = PlayerState.Death;
                //Hit2D.transform.GetComponent<Character>().Mode = GameMode.Lose;
            }
            else if (Physics2D.Linecast(transform.position, HitPlayerBack.position, mask.value))
            {
                Hit2D = Physics2D.Linecast(transform.position, HitPlayerBack.position, mask.value);
                Hit2D.transform.GetComponent<Character>().State = PlayerState.Death;
               // Hit2D.transform.GetComponent<Character>().Mode = GameMode.Lose;
            }  
        }
    }
    //敌人的死亡特效
    private IEnumerator DeadDelay(float Delay)
    {
        yield return new WaitForSeconds(Delay);
        Destroy(gameObject);
    }
    public void Dead(ref EnemyState State)
    {
        EnemyHitable = Physics2D.Linecast(transform.position, CheckPointHeadLeft.position, 1 << LayerMask.NameToLayer("Player")) ||
              Physics2D.Linecast(transform.position, CheckPointHeadRight.position, 1 << LayerMask.NameToLayer("Player")) ||
              Physics2D.Linecast(transform.position, CheckPointHeadUp.position, 1 << LayerMask.NameToLayer("Player"));
        if (EnemyHitable)
        {
            PlayerHit(ref State);
        }
    }
    //角色踩到敌人时的一段起跳特效
    #region 因为现在的逻辑判断不是很完善，此功能有待实现
    private IEnumerator PlayerUpHeight(Transform Player, Rigidbody2D rig)
    {
        Vector2 Pos = Player.position;
        while (true)
        {
            Player.position = new Vector2(Pos.x, Pos.y + Time.deltaTime * 1);
            if (Player.position.y >= Pos.y + 0.5f)
            {
                rig.isKinematic = false;
                break;
            }
            yield return null;
        }
    }
    #endregion
}
