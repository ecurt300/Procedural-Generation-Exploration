using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProcGrid : MonoBehaviour
{
    [SerializeField] private int height;
    [SerializeField] private int width;
    [SerializeField] private int cellSize = 1;
    Vector3[] vertices;
    private void Start()
    {
        vertices = new Vector3[(height + 1) * (width + 1)];
        var Indices = new int[height * width * 6];
        var normals = new Vector3[(height + 1) * (width + 1)];
        var uv = new Vector2[(height + 1) * (width + 1)];

        for (int i = 0, v = 0; i <= width; i++)
        {
            for (int j = 0; j <= height; j++, v++)
            {
                int index = (j * (width + 1) + i);
                vertices[index] = new Vector3((i * cellSize), (j * cellSize), 0);
         
                normals[v] = Vector3.back;

                uv[v] = new Vector2(i - 1, j - 1);

            }
        }
        for (int i = 0, v = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++, v += 6)
            {
                int index = j * (width + 1) + i;




                Indices[v + 0] = index;
                Indices[v + 1] = index + width + 1;
                Indices[v + 2] = index + 1;
                
                Indices[v + 3] = index+1;
                Indices[v + 4] = index  + width + 1;
                Indices[v + 5] = index + width + 2;
           
              
            }
        }
       
        Debug.Log(Indices);
        var mesh = new Mesh()
        {

            vertices = vertices,
            triangles = Indices,
            normals = normals,
            uv = uv,

            name = "ProcGrid"
        };
        GetComponent<MeshFilter>().mesh = mesh;
        }
    private void OnDrawGizmos()
    {
        vertices = new Vector3[(height + 1) * (width + 1)];
        for (int i = 0, v = 0; i < height - 1; i++)
        {
            for (int j = 0; j < width - 1; j++, v++)
            {
                vertices[v] = new Vector3(i, j);
                Gizmos.DrawSphere(vertices[v] ,0.05f);
                
            }
        }
    }
}

