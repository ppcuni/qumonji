using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float distance = 20.0f;

    [SerializeField]
    private float dy = 0.0f;

    [SerializeField]
    private float xSpeed = 100.0f;

    [SerializeField]
    private float ySpeed = 100.0f;

    private float x = 0.0f;
    private float y = 0.0f;

    void Awake()
    {
        UpdateRotation();
	}

	void Update()
    {
        if (Input.GetMouseButton(1))
        {
            UpdateRotation();
        }

        UpdatePosition();

        distance -= Input.GetAxis("Mouse ScrollWheel") * 10;
	}

    private void UpdateRotation()
    {
        x += Input.GetAxis("Mouse X") * xSpeed * 0.1f;
        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.1f;

        transform.rotation = Quaternion.Euler(y, x, 0);
    }

    private void UpdatePosition()
    {
        transform.position = transform.localRotation * new Vector3(0.0f, dy, -distance) + target.position;
    }
}
