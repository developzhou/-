﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QusetionScript : MonoBehaviour
{
    private List<int> p = new List<int>();
    private void Start()
    {
        int a=p[0];
    }
    //总结今天使用的在同一个场景中，划分游戏各部分内容的方法
    //1、在什么情况下才应该使用断点
    //2、刚体组件只可以在Kinematic的模式下，才可以使用赋值的方式改变物体的坐标位置
    //3、枚举是值类型，如果需要通过传参的形式改变枚举的类型，需要使用ref作为参考参数传入
    //4、判断什么样的功能适合在脚本中，集中遍历数组中所有物体来执行，什么样的功能则是单独的物体各自的脚本中执行
    //5、判断什么性质的变量适合在Awake中赋值，什么样的变量适合在Start赋值
    //6、如何从静态或动态数组中，选择合适的数组来获取多个物体？
    //7、当使用数组中的某一对象执行功能后，如果需要移除物体，则需要什么样的判断条件？
    //总结函数之间相互通信协调功能的行为逻辑，目前已知掌握的通信方法有两种
    //8、给脚本添加状态枚举，判断脚本当前枚举值的类型实现方法之间的通信
    //9、使用Unity中提供的接口，通过简单的条件判断来实现通信
    //10、在使用刚体的Velocity或AddForce添加力时，有什么限制，目前已知的限制是Velocity和AddForce在只执行一次的接口或判断语句中，对物体添加力会没有任何的效果
    //11、条件判断的先后顺序，例如，需要先满足条件1后才能执行功能1，执行后续功能需要满足条件2，思考如何分清楚各条件之间的先后顺序
    //12、总结bool变量控制条件语句的数量，是否应该每个条件判断语句都是用单独的bool变量进行判断
    //13、物体组件属性的变换应该放在什么时机或条件中进行
    //14、什么样的情况下适合使用协程，使用协程的时候应该注意什么
    //15、总结射线检查点的摆放方法，放在什么位置才能让射线有效的击中地面
    //16、总结使用空壳套其他函数的方法。
    //17、执行代码时候逻辑判断的先后顺序,判断是先完成状态变更的逻辑判断，还是先完成执行方法是的逻辑判断
}
