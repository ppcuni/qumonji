using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, float.MaxValue))
        {
            Debug.Log(hitInfo.point);
        }
    }
}
