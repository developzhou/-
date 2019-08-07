using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class test : MonoBehaviour
{
    private Vector2 input;
    private Vector2 InputDir;
    private Animator anim;
    public float WalkSpeed = 2f;
    public float RunSpeed = 6f;
    public float TurnSpeed=0.2f;
    public float RunSmoothSpeed;  
    float TurnVelocity;
    float RunVelocity;
    private float CurrentSpeed;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));//1、根据输入方向，控制角色的朝向
        InputDir = input.normalized;
        if (InputDir != Vector2.zero)//2、当不输入任何方向时，让角色默认保持当前的状态
        {
            float targetRotation=  Mathf.Atan2(InputDir.y, InputDir.x) * Mathf.Rad2Deg;//3、求出向量的夹角，并设置为角色的旋转角度
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref TurnVelocity, TurnSpeed);//4、让角色旋转动作更加自然，对旋转值进行插值计算
            //Mathf.SmoothDampAngle设置一个阻力值，平滑的返回一个数值，常用于设置角色动作更加自然。
            //进行赋值时容易出现覆盖的现象，所以需要注意if语句的使用
        }
        bool Runing = Input.GetKey(KeyCode.LeftShift);
        float speed = (Runing ? RunSpeed : WalkSpeed)*InputDir.magnitude;//5、判断角色是否奔跑，InputDir.magnitude用于控制角色是否移动，如果不做方向输入，角色将不做移动
        CurrentSpeed = Mathf.SmoothDamp(CurrentSpeed, speed, ref RunVelocity, RunSmoothSpeed);
        // Mathf.SmoothDamp设置阻力值，用于平滑数值的返回
        transform.Translate(Vector3.forward * CurrentSpeed * Time.deltaTime,Space.Self);
        float animationSpeed = (Runing ? 1f : 0.5f) * InputDir.magnitude;//6、设置角色对应速度下的状态，当角色不做任何方向的输入时，角色将进入idle状态
        anim.SetFloat("StateChange", animationSpeed,RunSmoothSpeed,Time.deltaTime);
        //设置动画的阻力值，让角色动作更加自然
        //如果一个数值，决定了另外两个数值的去向，则分别对这两个数值使用乘法
    }
}
