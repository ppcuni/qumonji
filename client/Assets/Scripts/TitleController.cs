using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour
{
	void Start()
    {
	
	}

	void Update()
    {
	
	}

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 60), "gumonji");

        if (GUI.Button(new Rect(20, 40, 80, 20), "Start"))
        {
            Application.LoadLevel("World");
        }
    }
}
