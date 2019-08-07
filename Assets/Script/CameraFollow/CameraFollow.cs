using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float Speed;
    public Transform Player;
    public Vector2 Offset = new Vector2(0, 0);
    public float TimeOffset=2f;
    private void Update()
    {
        Vector3 StartPos = transform.position;
        Vector3 EndPos = new Vector3(Player.position.x + Offset.x, Player.position.y + Offset.y, -10);
        transform.position = Vector3.Lerp(StartPos, EndPos, TimeOffset*Time.deltaTime*Speed);
    }

}
