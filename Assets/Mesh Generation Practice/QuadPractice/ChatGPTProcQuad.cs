using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralGrid : MonoBehaviour
{
    public bool Regenerate;
    public int width = 10;  // Number of quads (not vertices)
    public int height = 10;
    public float cellSize = 1f;

    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;
    
    void Start()
    {
        GenerateMesh();
    }
    private void Update()
    {
        if(Regenerate)
        {
            GenerateMesh();
            Regenerate = false;
        }
    }
    void GenerateMesh()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        vertices = new Vector3[(width + 1) * (height + 1)];
        triangles = new int[width * height * 6];
        var cellSizeX = cellSize / width;
        var cellSizeY = cellSize / height;
        // Generate vertices
        for (int y = 0; y <= height; y++)
        {
            for (int x = 0; x <= width; x++)
            {
                int index = y * (width + 1) + x;
                vertices[index] = new Vector3( x * cellSizeX, 0, y * cellSizeY);
            }
        }

        // Generate triangles
        int tris = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int vertIndex = y * (width + 1) + x;

                // First triangle
                triangles[tris + 0] = vertIndex;
                triangles[tris + 1] = vertIndex + width + 1;
                triangles[tris + 2] = vertIndex + 1;

                // Second triangle
                triangles[tris + 3] = vertIndex + 1;
                triangles[tris + 4] = vertIndex + width + 1;
                triangles[tris + 5] = vertIndex + width + 2;

                tris += 6;
            }
        }

        // Apply to mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals(); // Fix lighting issues
    }
}
