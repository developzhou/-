﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Victory : MonoBehaviour
{
    public GameObject VictoryLabel;
    public GameObject QuestLabel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag=="Player")
        {
            QuestLabel.SetActive(true);
            VictoryLabel.SetActive(true);
        }
    }
}
