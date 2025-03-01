using UnityEngine;
using System.Collections.Generic;

public class MeshData
{
    private int width, height;
    private Vector3[] vertices;
    private Vector3[] normals;
    private Vector2[] uvs;
    private int[] triangles;
    int tris = 0;
    public Vector3[] Vertices { get => vertices; set => vertices = value; }
    public Vector2[] Uvs { get => uvs; set => uvs = value; }
    public Vector3[] Normals { get => normals; set => normals = value; }
    public int[] Triangles { get => triangles; set => triangles = value; }

    public void AddTriangle(int a,int b,int c)
    {
       
        triangles[tris]   = a;
        triangles[tris + 1] = b;
        triangles[tris + 2] = c;
        tris += 3;
      
    }

    public void AddUV(int index,int x,int y)
    {
        Uvs[index] = new Vector2(x/width,y/height);
    }

    public MeshData(int width,int height)
    {
        //Level of Detail should be replaced with shader in later projects in this project
        this.width = width;
        this.height = height;
        int vertexCount = (height + 1) * (width + 1);
        Vertices = new Vector3[vertexCount];
        Normals = new Vector3[vertexCount];
        triangles = new int[vertexCount * 6];
        Uvs = new Vector2[vertexCount];
    }
    public Mesh GenerateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = Vertices;
        mesh.uv = Uvs;
        mesh.normals = Normals;
      
        mesh.triangles = Triangles;
     
        return mesh;
    }
}
