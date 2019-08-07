using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//判断什么功能适合集中在一起使用循环执行，什么功能适合分别单独执行？
public class PlayerAndEnemyDeadMgr : MonoBehaviour
{
    public GameObject character;
    public List<AI> Ais = new List<AI>();
    private Vector2 DeadPos;
    private float DeadPostion;
    private CharacterMove CharacterMoveScript;
    private Character CharacterScript;
    public float DeadDelay;
    public float DeadHeight;
    public float DeadSpeed;
    public CameraFollow follow;
    //5、Awake和Start赋值的先后逻辑
    private void Awake()
    {
        GameObject[] Array= GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject temp in Array)
        {
            //
            Ais.Add(temp.GetComponent<AI>());
        }
    }
    private void Start()
    {
        CharacterScript = character.GetComponent<Character>();
        CharacterMoveScript = character.GetComponent<CharacterMove>();
    }
    private void Update()
    {
        //1、角色的死亡逻辑
        if (CharacterScript.State == PlayerState.Death)
        {
            //EnemyController();
            PlayerDead(ref CharacterScript.State,CharacterMoveScript.rig);
        }
    }
    private void LateUpdate()
    {
        /*if (CharacterScript.Mode == GameMode.Lose)
        {
            VocieMangerDead.DeadEffect();
        }*/
        StopCameraFollow(ref CharacterScript.State);
    }
    //实现角色死亡下落过程中，不再和任何的障碍物碰撞
    public void PlayerDead(ref PlayerState State,Rigidbody2D rig)
    {        
        State = PlayerState.Dead;
        rig.isKinematic = true;
        character.GetComponent<Collider2D>().isTrigger = true;
        StartCoroutine(DeadEffect(DeadDelay,rig));
    }
    //角色死亡的位移特效
    private IEnumerator DeadEffect(float DeadDelay,Rigidbody2D rig)
    {
        DeadPos = character.transform.position;
        while (true)
        {
            character.transform.position = new Vector2(DeadPos.x, character.transform.position.y + Time.deltaTime * DeadSpeed);
            if (character.transform.position.y >= DeadPos.y + DeadHeight)
            {
                rig.isKinematic = false;
                break;
            }
            yield return null;
        }
    }
    public void StopCameraFollow(ref PlayerState State)
    {
        if (State == PlayerState.Dead)
        {
            follow.enabled = false;
        }
    }
    #region 等待逻辑判断完善后，再加上去
    private void EnemyController()
    {
        foreach (AI temp in Ais)
        {
            temp.enabled = false;
        }
    }
    #endregion
}
