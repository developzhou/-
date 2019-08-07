using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetPoint : MonoBehaviour
{
    [HideInInspector]
    public static int Point;
    public Text PointLabel;
    private void Update()
    {
        PointLabel.text = Point.ToString();
    }
}
