using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{
    private Mesh mesh;
    private MeshFilter meshFilter;

    private Vector3[] vertices;
    private int[] triangles;
    private Vector2[] uvs;

	void Start()
    {
        mesh = new Mesh();
        meshFilter = GetComponent<MeshFilter>();
	}

	void Update()
    {
        mesh.Clear();

        vertices = new Vector3[3];
        vertices[0] = Vector3.zero;
        vertices[1] = new Vector3(0, 0, 1);
        vertices[2] = new Vector3(1, 0, 0);

        triangles = new int[3];
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        uvs = new Vector2[3];
        uvs[0] = Vector2.zero;
        uvs[1] = Vector2.right;
        uvs[2] = Vector2.up;

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        meshFilter.sharedMesh = mesh;
        meshFilter.sharedMesh.name = "Earth";
	}
}
