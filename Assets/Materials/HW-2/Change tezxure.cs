using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;       // Object to orbit around
    public float distance = 5f;    // Distance from the target
    public float speed = 30f;      // Degrees per second

    private float angle = 0f;

    void Update()
    {
        angle += speed * Time.deltaTime;
        float radians = angle * Mathf.Deg2Rad;

        // Calculate new camera position
        Vector3 offset = new Vector3(
            Mathf.Sin(radians) * distance,
            0f,
            Mathf.Cos(radians) * distance
        );

        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}