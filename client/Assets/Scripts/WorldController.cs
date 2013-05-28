using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{
    private GameObject earth;

    void Awake()
    {
        earth = GameObject.Find("Earth");
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, float.MaxValue))
        {
            if (Input.GetMouseButton(0))
                earth.SendMessage("Add", hitInfo.triangleIndex);
        }
    }
}
