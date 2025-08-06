using UnityEngine;

public class CardLookAtCursor : MonoBehaviour
{
    public float rotationAmount = 10f;      // How much the card tilts
    public float rotationSpeed = 10f;       // How fast the card rotates
    public float deadzone = 0.1f;           // How far from center to start rotating

    private Quaternion originalRotation;
    private Camera mainCamera;
    private bool isMouseOver = false;
    private Quaternion targetRotation;

    void Start()
    {
        mainCamera = Camera.main;
        originalRotation = transform.rotation;
        targetRotation = originalRotation;
    }

    void OnMouseEnter() => isMouseOver = true;
    void OnMouseExit()
    {
        isMouseOver = false;
        targetRotation = originalRotation;
    }

    void Update()
    {
        if (isMouseOver && mainCamera != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f) && hit.transform == transform)
            {
                Vector3 localPoint = transform.InverseTransformPoint(hit.point);
                Vector2 local2D = new Vector2(localPoint.x, localPoint.y);

                if (local2D.magnitude > deadzone)
                {
                    float rotX = Mathf.Clamp(local2D.y, -1f, 1f) * rotationAmount;
                    float rotY = Mathf.Clamp(-local2D.x, -1f, 1f) * rotationAmount;
                    targetRotation = originalRotation * Quaternion.Euler(rotX, rotY, 0f);
                }
                else
                {
                    targetRotation = originalRotation;
                }
            }
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
