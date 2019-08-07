using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdetection : MonoBehaviour
{
    public float JumpSpeed = 5;
    private void OnTriggerExit2D(Collider2D collision)
    {
        #region 暂定修改的逻辑
        /* if (collision.GetComponent<Character>().State == PlayerState.Alive)
         {
             collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, JumpSpeed);
             collision.GetComponent<Character>().State = PlayerState.Death;
         }*/
        #endregion
        if (collision.tag=="Player")
        {
            collision.transform.GetComponent<Character>().State = PlayerState.Death;
        }
    }
}
