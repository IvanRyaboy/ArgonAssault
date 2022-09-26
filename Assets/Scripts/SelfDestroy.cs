using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] float TimeToDestroy = 1f;
    void Start()
    {
        Destroy(this.gameObject, TimeToDestroy);
    }
}
