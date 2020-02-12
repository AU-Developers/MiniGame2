﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimerToDisable());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimerToDisable()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
