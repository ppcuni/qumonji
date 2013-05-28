using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{
    private GameObject earth;

    private EditMode editMode = EditMode.UP1;

    public enum EditMode
    {
        UP1,
        UP2,
        DOWN1,
        DOWN2,
    }

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
            {
                switch (editMode)
                {
                    case EditMode.UP1:
                        earth.SendMessage("UP1", hitInfo.triangleIndex);
                        break;
                    case EditMode.UP2:
                        earth.SendMessage("UP2", hitInfo.triangleIndex);
                        break;
                    case EditMode.DOWN1:
                        earth.SendMessage("DOWN1", hitInfo.triangleIndex);
                        break;
                    case EditMode.DOWN2:
                        earth.SendMessage("DOWN2", hitInfo.triangleIndex);
                        break;
                }
            }
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 80, 30), "UP1"))
            editMode = EditMode.UP1;

        if (GUI.Button(new Rect(100, 10, 80, 30), "UP2"))
            editMode = EditMode.UP2;

        if (GUI.Button(new Rect(190, 10, 80, 30), "DOWN1"))
            editMode = EditMode.DOWN1;

        if (GUI.Button(new Rect(280, 10, 80, 30), "DOWN2"))
            editMode = EditMode.DOWN2;
    }
}
