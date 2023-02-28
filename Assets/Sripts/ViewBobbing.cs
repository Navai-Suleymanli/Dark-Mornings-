using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PositionFollower))]
public class ViewBobbing : MonoBehaviour
{
    public float effectIntensity;
    public float effectIntensityX;
    public float effectSpeed;


    private PositionFollower followerinstance;
    private Vector3 originalOffset;
    private float sinTime;


    void Start()
    {
        followerinstance = GetComponent<PositionFollower>();
        originalOffset = followerinstance.offset;
    }

    void Update()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));
        if (inputVector.magnitude > 0f)
        {
            sinTime += Time.deltaTime * effectSpeed;
        }
        else
        {
            sinTime = 0f;
        }

        float sinamounY = -Mathf.Abs(effectIntensity * Mathf.Sin(sinTime));
        Vector3 sinAmountX = followerinstance.transform.right * effectIntensity * Mathf.Cos(sinTime) * effectIntensityX;

        followerinstance.offset = new Vector3()
        {
            x = originalOffset.x,
            y = originalOffset.y + sinamounY,
            z = originalOffset.z
        };
        followerinstance.offset += sinAmountX;

    }
}
