using UnityEngine;
using System.Collections;

public class EarthMeshBuilder : EarthMesh
{
    private Vector2[] uvs;

    void Awake()
    {
        base.Awake();

        int vertexCount = gridRow * gridColumn;
        int triangleCount = (gridRow - 1) * (gridColumn - 1) * 2 * 3;

        vertices = new Vector3[vertexCount];
        uvs = new Vector2[vertexCount];
        normals = new Vector3[vertexCount];
        indices = new int[triangleCount];

        for (int i = 0; i < vertexCount; i++)
        {
            vertices[i] = new Vector3(((gridColumn - 1) * sideLength / 2) - i % gridColumn * sideLength, 0, ((gridRow - 1) * sideLength / 2) - i / gridColumn * sideLength);
            vertices[i] += centerOffset;
            uvs[i] = new Vector2(i % gridColumn, i / gridColumn);
            normals[i] = new Vector3(0, 1, 0);
        }

        int index = 0;
        for (int i = 0; i < (gridRow - 1) * (gridColumn - 1); i++)
        {
            int j = i % (gridColumn - 1) + (i / (gridColumn - 1)) * gridColumn;
            indices[index] = j;
            indices[index + 1] = j + gridColumn;
            indices[index + 2] = j + gridColumn + 1;

            indices[index + 3] = j;
            indices[index + 4] = j + gridColumn + 1;
            indices[index + 5] = j + 1;

            index += 6;
        }

        Mesh mesh = Filter.mesh;

        mesh.Clear();

        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.normals = normals;
        mesh.triangles = indices;

        mesh.RecalculateBounds();

        Filter.sharedMesh.name = "Earth";
    }
}
