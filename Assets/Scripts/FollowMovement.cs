using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    private Quaternion initialRotation;
    private Vector3 initialOffset;

    void Start()
    {
        initialRotation = Quaternion.Inverse(target.rotation) * transform.rotation;
        initialOffset = transform.position - target.position;
    }

    void Update()
    {
        Quaternion targetRotation = target.rotation * initialRotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, FollowSpeed * Time.deltaTime);

        Vector3 targetPosition = target.position + initialOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, FollowSpeed * Time.deltaTime);
    }
}
