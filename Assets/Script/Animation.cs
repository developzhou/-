using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private float TurnAngle;
    private bool Running;
    private Animator anim;
    private float Speed;
    private float CurrentState;
    private float TargetAngle;
    public float TurnSpeed=0.2f;
    public float RunSpeed = 0.2f;
    private float TurnVelocity;
    private float CurrentSpeed;
    private float RunVelocity;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        //1、角色转向
        Vector2 Turn = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 TurnDir = Turn.normalized;
        if (TurnDir != Vector2.zero)
        {
            TurnAngle = Mathf.Atan2(TurnDir.y, TurnDir.x)*Mathf.Rad2Deg;
            transform.eulerAngles = Mathf.SmoothDampAngle(transform.eulerAngles.y, TurnAngle, ref TurnVelocity, TurnSpeed)*Vector3.up;
        }
        //2、角色移动
        Running = Input.GetKey(KeyCode.LeftShift);
        Speed = (Running ? 6f : 2f)*TurnDir.magnitude;
        //控制角色前行的速率
        CurrentSpeed = Mathf.SmoothDamp(CurrentSpeed, Speed, ref RunVelocity, RunSpeed);
        CurrentState = (Running ? 1f : 0.5f) * TurnDir.magnitude;
        //使用RunSpeed配合角色前行的速率
        anim.SetFloat("StateChange", CurrentState,RunSpeed,Time.deltaTime);
        //让角色沿着自身坐标前行
        transform.Translate(Vector3.forward * CurrentSpeed * Time.deltaTime,Space.Self);
    }
}
