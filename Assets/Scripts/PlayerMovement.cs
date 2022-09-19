using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed;
    [SerializeField] float xrange = 5f;
    [SerializeField] float yrange = 5f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;

    float yThrow, xThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
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
}


