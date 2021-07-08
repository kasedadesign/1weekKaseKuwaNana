using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YureiSc : MonoBehaviour
{
    [SerializeField]
    private GameObject item4;

    private void Awake()
    {
        item4.SetActive(true);
    }
}
