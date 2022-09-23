using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandeler : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(this.name + " game object collided with " + other.gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} triggered with {other.gameObject.name}");
    }
}
