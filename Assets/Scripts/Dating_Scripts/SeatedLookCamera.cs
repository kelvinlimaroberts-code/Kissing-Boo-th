using UnityEngine;

public class SeatedLookCamera : MonoBehaviour
{
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float minPitch = -20f;
    [SerializeField] private float maxPitch = 25f;
    [SerializeField] private float minYaw = -60f;
    [SerializeField] private float maxYaw = 60f;

    private float yaw;
    private float pitch;

    public float CurrentPitch => pitch;

    private void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        yaw = Mathf.Clamp(yaw, minYaw, maxYaw);
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        transform.localRotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}

