using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [HideInInspector]
    public float MoveDir;
    private bool AbovePlatform;
    private bool IsFalled;
    private RaycastHit2D LeftFoot;
    private RaycastHit2D RightFoot;
    public bool IsJump;
    [HideInInspector]
    public Rigidbody2D rig;
    public Transform JPCheckPoint;
    public Transform JPCheckPointL;
    public Transform JPCheckPointR;
    public float Movespeed = 2f;
    public float JumpSpeed = 4f;
    public LayerMask mask;
    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    public void MoveMethod()
    {
        //1、移动的逻辑
        MoveDir = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(MoveDir, 0) * Movespeed * Time.deltaTime);
        //2、跳跃逻辑
       
    }
    public void Down()
    {
       
        if (Physics2D.Linecast(transform.position, JPCheckPointL.position, 1 << LayerMask.NameToLayer("Platform")) ||
            Physics2D.Linecast(transform.position, JPCheckPointR.position, 1 << LayerMask.NameToLayer("Platform")))
        {
            if(Input.GetKeyDown(KeyCode.S))
                gameObject.layer = LayerMask.NameToLayer("OnewayPlatform");
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }
    public void EdgeFall()
    {
        //角色到达平台边缘后，无法下落的BUG
        LeftFoot = Physics2D.Linecast(transform.position, JPCheckPointL.position, 1 << LayerMask.NameToLayer("Ground"));
        RightFoot = Physics2D.Linecast(transform.position, JPCheckPointR.position, 1 << LayerMask.NameToLayer("Ground"));
        if (LeftFoot.transform.tag == "Platform" && RightFoot.transform.tag == "Platform")
        {
            AbovePlatform = true;
        }
        if (AbovePlatform)
        {
            if (Physics2D.Linecast(transform.position, JPCheckPointL.position, 1 << LayerMask.NameToLayer("Ground")))
            {
                IsFalled = false;
            }
            else
            {
                IsFalled = true;
            }
        }
        if (IsFalled)
        {
            Debug.Log("角色的双脚已离开了地面");
        }
    }
    public void JumpMethod()
    {
      IsJump = Physics2D.Linecast(transform.position, JPCheckPoint.position,mask.value) ||
      Physics2D.Linecast(transform.position, JPCheckPointL.position, mask.value) ||
      Physics2D.Linecast(transform.position, JPCheckPointR.position, mask.value);
        if (Input.GetKeyDown(KeyCode.Space) && IsJump)
        {
            rig.velocity = new Vector2(0, JumpSpeed);
        }

    }
}