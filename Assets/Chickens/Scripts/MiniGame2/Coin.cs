using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RandomFlipping();
    }

    void RandomFlipping()
    {
        Vector3 euls = transform.eulerAngles;
        euls.x = Random.Range(0.0f,360.0f);
        transform.eulerAngles = euls;
    }
}
