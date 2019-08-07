using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float MaxUpHeight = 2f;
    public float BlockSpeed=4f;
    private bool IsCanBounce=true;
    public int BounceTime;
    public Transform CheckPos;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsCanBounce&&BounceTime>0)
        {
            if (Physics2D.Linecast(transform.position,CheckPos.position,1<<LayerMask.NameToLayer("Player")))
            {
                VoiceManger.PlayeEffect = true;
                GetPoint.Point++;
                BounceTime -= 1;
                StartCoroutine(BlockBounce(transform.position));
            }          
        }
    }
    public IEnumerator BlockBounce(Vector2 StartPos)
    {
        while (true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * BlockSpeed);
            if (transform.position.y >= StartPos.y + MaxUpHeight)
            {
                break;
            }
            yield return null;
        }
        while (true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * BlockSpeed);
            if (transform.position.y <= StartPos.y)
            {
                transform.position = StartPos;
                break;
            }
            yield return null;
        }
    }
}
