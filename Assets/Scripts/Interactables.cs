using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public GameObject VPlatform;

    public void Start()
    {
        VPlatform.SetActive(false);
    }

    public void OpenBarrier()
    {
        Destroy(GameObject.FindWithTag("Barrier"));
    }

    public void ObjectCreate()
    {
        VPlatform.SetActive(true);
        Debug.Log("Hello");
    }
}
