using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour
{
    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100));

        GUI.Box(new Rect(0, 0, 100, 100), "qumonji");

        if (GUI.Button (new Rect (10,40,80,30), "start"))
        {
            Application.LoadLevel("World");
        }

        GUI.EndGroup();
    }
}
