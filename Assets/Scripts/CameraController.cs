using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Rig")]
    public Transform cameraTransform;

    [Header("Zoom Settings")]
    public float zoomSpeed = 5f;
    public float minZoom = -3f;
    public float maxZoom = -20f;

    [Header("Rotation Settings")]
    public float rotationSpeed = 100f;

    [Header("Focus Settings")]
    public LayerMask towerLayer;
    public float panSpeed = 5f;

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * panSpeed);

        //Rotate left and right using Q and E
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime, Space.World);

        //Zoom in and out using the Mouse Wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            cameraTransform.Translate(Vector3.forward * scroll * zoomSpeed, Space.Self);
        }

        //Click a tower to focus on it
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, towerLayer))
            {
                targetPosition = hit.transform.position;
            }
        }
    }
}
