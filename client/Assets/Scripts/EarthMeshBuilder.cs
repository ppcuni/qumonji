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

        UpdateMesh();
    }

    private void UP1(int index)
    {
        Mesh mesh = Filter.mesh;

        vertices[mesh.triangles[index * 3]].y += 0.05f;

        UpdateMesh();
    }

    private void UP2(int index)
    {
        Mesh mesh = Filter.mesh;

        vertices[mesh.triangles[index * 3]].y += 0.1f;
        vertices[mesh.triangles[index * 3 + 1]].y += 0.1f;
        vertices[mesh.triangles[index * 3 + 2]].y += 0.1f;
        vertices[mesh.triangles[index * 3 + 5]].y += 0.1f;

        UpdateMesh();
    }

    private void DOWN1(int index)
    {
        Mesh mesh = Filter.mesh;

        vertices[mesh.triangles[index * 3]].y -= 0.1f;

        UpdateMesh();
    }

    private void DOWN2(int index)
    {
        Mesh mesh = Filter.mesh;

        vertices[mesh.triangles[index * 3]].y -= 0.1f;
        vertices[mesh.triangles[index * 3 + 1]].y -= 0.1f;
        vertices[mesh.triangles[index * 3 + 2]].y -= 0.1f;
        vertices[mesh.triangles[index * 3 + 5]].y -= 0.1f;

        UpdateMesh();
    }

    private void UpdateMesh()
    {
        Mesh mesh = Filter.mesh;

        mesh.Clear();

        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.normals = normals;
        mesh.triangles = indices;

        mesh.RecalculateBounds();
        mesh.Optimize();

        GetComponent<MeshCollider>().sharedMesh = null;
        GetComponent<MeshCollider>().sharedMesh = Filter.mesh;
    }

    private void DisplayEditGrid(int index)
    {
        if (index % 2 != 0) index -= 1;

        Mesh mesh = Filter.mesh;

        var lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetVertexCount(9);
        lineRenderer.SetPosition(0, vertices[mesh.triangles[index * 3]]);
        lineRenderer.SetPosition(1, vertices[mesh.triangles[index * 3 + 1]]);
        lineRenderer.SetPosition(2, vertices[mesh.triangles[index * 3 + 2]]);
        lineRenderer.SetPosition(3, vertices[mesh.triangles[index * 3 + 5]]);
        lineRenderer.SetPosition(4, vertices[mesh.triangles[index * 3]]);

        lineRenderer.SetPosition(5, vertices[mesh.triangles[(index - 2) * 3 + 1]]);
        lineRenderer.SetPosition(6, vertices[mesh.triangles[(index - 2) * 3 + 2]]);
        lineRenderer.SetPosition(7, vertices[mesh.triangles[(index - 2) * 3 + 1]]);
        lineRenderer.SetPosition(8, vertices[mesh.triangles[(index - 2) * 3]]);
    }
}
