using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCustomizationController : MonoBehaviour
{
    [SerializeField] private float movSpeed;
    [SerializeField] private float rotSpeed;
    [SerializeField] private Transform[] camPositions;

    private Transform currentView;

    private void Start()
    {
        currentView = camPositions[0];
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * movSpeed);

        Vector3 desiredAngle = new Vector3(
            Mathf.Lerp(transform.localEulerAngles.x, currentView.localEulerAngles.x, Time.deltaTime * rotSpeed),
            Mathf.Lerp(transform.localEulerAngles.y, currentView.localEulerAngles.y, Time.deltaTime * rotSpeed),
            Mathf.Lerp(transform.localEulerAngles.z, currentView.localEulerAngles.z, Time.deltaTime * rotSpeed)
            );

        transform.localEulerAngles = desiredAngle;
    }
    public void ChangeCamPosition(int index)
    {
        currentView = camPositions[index];
    }
}
