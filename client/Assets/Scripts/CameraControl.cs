using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float distance = 20.0f;

    [SerializeField]
    private float dy = 1.0f;

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
	}

    private void UpdateRotation()
    {
        x += Input.GetAxis("Mouse X") * 100.0f * 0.1f;
        y -= Input.GetAxis("Mouse Y") * 100.0f * 0.1f;

        transform.rotation = Quaternion.Euler(y, x, 0);
    }

    private void UpdatePosition()
    {
        transform.position = transform.localRotation * new Vector3(0.0f, dy, -distance) + target.position;
    }
}
