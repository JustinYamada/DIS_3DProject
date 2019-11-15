﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamadaCameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
