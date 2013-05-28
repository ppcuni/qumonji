using UnityEngine;
using System.Collections;

public class EarthMesh : MonoBehaviour
{
    protected Vector3[] vertices;
    protected Vector3[] normals;
    protected int[] indices;

    protected Vector3 centerOffset;

    protected int gridRow = 10;
    protected int gridColumn = 10;
    protected float sideLength = 2.0f;

    public int GridRow { get { return gridRow; } }
    public int GridColumn { get { return gridColumn; } }
    public float SideLength { get { return sideLength; } }
    public int VertexCount { get { return gridRow * gridColumn; } }
    public MeshFilter Filter { get; protected set; }

    protected virtual void Awake()
    {
        Filter = GetComponent<MeshFilter>();
        Filter.mesh = new Mesh();
    }
}
