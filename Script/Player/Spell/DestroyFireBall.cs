using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeDestroy());
    }
    public IEnumerator TimeDestroy()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
