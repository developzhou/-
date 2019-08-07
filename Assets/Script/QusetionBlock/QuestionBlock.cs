using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    private Coin coin;
    private Block block;
    private Vector2 StartPos;
    private bool CanBounce;
    private void Start()
    {
        coin = GetComponent<Coin>();
        block = GetComponent<Block>();
        StartPos = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            CanBounce = true;
        }
    }
    //砖块的位移动画
    private void Update()
    {
        if (CanBounce)
        {
            CanBounce = false;
            GameObject CoinObj= coin.SpawnCoin(StartPos);
            StartCoroutine(coin.CoinBounce(CoinObj, StartPos));
            StartCoroutine(block.BlockBounce(StartPos));
        }
    }
}
//1、物体在没有设置父级关系时，如果使用transform.localPosition，表示的坐标任然是世界坐标transform.Position的位置
//2、选择正确的坐标系非常重要
//3、两物体的相对位移，必须要有唯一的基准点
//4、在协程方法中，只可以使用直接赋值的方法设置物体的位置，例如，transform.position=new Vector3(x,y,z)。
//5、TIPS：开发者可以在协程中，使用Time.deltatime的方法控制赋值轴向的速率，例如，transform.position=new Vector3(x,y*Time.deltatime*speed)

//问题1：两物体的位置不在统一坐标上


//排除干扰1：当物体没有父物体时拥有了子物体，即使输出局部坐标transform.localposition，结果还是和transform.position一样