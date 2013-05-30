using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float force = 5.0f;

    public bool Jump { get; private set; }

    void Awake()
    {
        Jump = true;
    }

	void Update()
    {
        if (Jump) return;

        if (Input.GetKeyDown(KeyCode.A))
        {
            AddForce(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            AddForce(Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AddForce(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AddForce(Vector3.back);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump = true;
            AddForce(Vector3.up);
        }
	}

    private void AddForce(Vector3 vector)
    {
        transform.rigidbody.AddForce(vector * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Jump = false;
    }
}
