using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_With_Delay : MonoBehaviour
{
    public float delay; // set this to 1.5

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delay);
    }
}
