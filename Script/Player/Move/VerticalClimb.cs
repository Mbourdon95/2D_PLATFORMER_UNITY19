using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalClimb : MonoBehaviour
{
    public PlatformEffector2D platform;
    public float wait;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            wait = 0.5f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (wait <= 0)
            {
                platform.rotationalOffset = 180;
                wait = 0.5f;
            }
            else
            {
                wait -= Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            platform.rotationalOffset = 0;
        }
    }
}
