using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Moving variables")]
    [Tooltip("How fast player ship can moving")]
    [SerializeField] float controlSpeed;
    [Tooltip("How far player ship can moving horizontally")]
    [SerializeField] float xrange = 5f;
    [Tooltip("How far player ship can moving virtically")]
    [SerializeField] float yrange = 5f;

    [Tooltip("Array to work with lasers")]
    [SerializeField] GameObject[] lasers;

    [Header("Screen position based tuning")]
    [Tooltip("")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;
    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;

    float yThrow, xThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    public void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    public void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xoffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xoffset;
        float clampXPos = Mathf.Clamp(rawXPos, -xrange, xrange);

        float yoffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yoffset;
        float clampYPos = Mathf.Clamp(rawYPos, -yrange, yrange);

        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetActiveLasers(true);
        }
        else
        {
            SetActiveLasers(false);
        }
    }

    private void SetActiveLasers(bool active)
    {
        foreach(GameObject laser in lasers)
        {
            var emissionController = laser.GetComponent<ParticleSystem>().emission;
            emissionController.enabled = active;
        }
    }
}


