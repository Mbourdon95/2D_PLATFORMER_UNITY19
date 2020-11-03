using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public float time;
    public Vector3 pos;
    public GameObject player;

    // On a besoin de cette variable pour avoir la ref du SmoothDamp.
    private Vector3 speed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + pos, ref speed, time);
    }
}
