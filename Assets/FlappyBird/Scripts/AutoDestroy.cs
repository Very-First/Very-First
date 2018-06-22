using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float WaitTime = 20f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(WaitForDie(WaitTime));
    }

    IEnumerator WaitForDie(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.Destroy(gameObject);
    }
}
