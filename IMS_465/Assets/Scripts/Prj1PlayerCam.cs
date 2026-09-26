using UnityEngine;

public class Prj1PlayerCam : MonoBehaviour
{
    public GameObject playerObject;
    public Transform camTransform;

    public float mouseSensitivity = 2f;
    private float cameraVer = 0f;
    public float smoothSpeed = 100f;
    public Vector3 camOffset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPosition = playerObject.transform.position;
        Vector3 camPositionSmooth = Vector3.Lerp(transform.position, camPosition, smoothSpeed * Time.deltaTime);
        transform.position = camPositionSmooth;
    }

    private void LateUpdate()
    {
        CameraDirection();
    }
    void CameraDirection()
    {
        float cameraHor = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, cameraHor, 0);
        playerObject.transform.rotation = transform.rotation;

        cameraVer -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        cameraVer = Mathf.Clamp(cameraVer, 25, 45f);

        camTransform.localRotation = Quaternion.Euler(cameraVer, 0, 0);
    }
}
