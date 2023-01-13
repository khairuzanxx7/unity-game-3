using UnityEngine;

public class AdvancedCameraController : MonoBehaviour
{
    public Transform target; // The object the camera should follow
    public float smoothSpeed = 0.125f; // The speed at which the camera should follow the target
    public Vector3 offset; // The offset from the target position that the camera should have
    public float zoomSpeed = 4f; // The speed at which the camera should zoom in and out
    public float minZoom = 10f; // The minimum distance the camera should be from the target
    public float maxZoom = 20f; // The maximum distance the camera should be from the target
    public float yawSpeed = 100f; // The speed at which the camera should rotate around the target
    public float pitchSpeed = 40f; // The speed at which the camera should pitch up and down

    private float currentZoom = 10f; // The current distance the camera is from the target
    private float currentYaw = 0f; // The current rotation of the camera around the target
    private float currentPitch = 20f; // The current pitch of the camera

    void LateUpdate()
    {
        // Calculate the desired position of the camera
        Vector3 desiredPosition = target.position - offset * currentZoom;
        desiredPosition.y += currentPitch;

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Make the camera look at the target
        transform.LookAt(target);

        // Rotate the camera around the target based on user input
        currentYaw += Input.GetAxis("Mouse X") * yawSpeed * Time.deltaTime;
        currentPitch -= Input.GetAxis("Mouse Y") * pitchSpeed * Time.deltaTime;
        currentPitch = Mathf.Clamp(currentPitch, -80f, 80f);
        transform.eulerAngles = new Vector3(currentPitch, currentYaw, 0f);

        // Zoom in and out based on user input
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }
}
