using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    //1、总结脚本之间的通信方法
    [HideInInspector]
    public int EnemyIndex;
    private AIMove Move;
    private AIState State;
    public EnemyState Enemy = EnemyState.Walking;
    private void Start()
    {
        Move = GetComponent<AIMove>();
        State = GetComponent<AIState>();
    }
    private void Update()
    {
        if (Enemy == EnemyState.Walking)
        {
            Move.EnemyMove();
        }
        State.PlayerDeath(Enemy);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        State.Dead(ref Enemy);
    }
}
