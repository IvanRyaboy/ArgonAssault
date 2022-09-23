using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandeler : MonoBehaviour
{
    bool isTransition = false;
    [SerializeField] float TimeToDestroy = 0.5f;
    [SerializeField] ParticleSystem explosion;

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(this.name + " game object collided with " + other.gameObject.name);
        ReloadLevelAfterTime();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} triggered with {other.gameObject.name}");
        ReloadLevelAfterTime();
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ReloadLevelAfterTime()
    {
        if (isTransition == false)
        {
            explosion.Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            isTransition = true;
        }
        GetComponent<PlayerMovement>().enabled = false;
        Invoke("ReloadLevel", TimeToDestroy);
    }
}
