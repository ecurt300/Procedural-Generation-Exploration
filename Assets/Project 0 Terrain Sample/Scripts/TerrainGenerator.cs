using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
[RequireComponent(typeof(MeshRenderer),typeof(MeshFilter))]
public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private bool regenerate;
    [SerializeField] private int height;
    [SerializeField] private int width;
    [SerializeField] private int cellSize = 1;
    [SerializeField] float cellSizeX;
    [SerializeField] float cellSizeY;
    [SerializeField] TerrainData TerrainData;
    [SerializeField] Texture2D terrainTest;
    Vector3[] vertices;
    int[] Indices;
    Vector3[] normals;
    Vector2[] uv;
    private void GenerateTerrain()
    {
        
        Texture2D heightTexture = TerrainData.GenerateHeightmapTexture();
        
        vertices = new Vector3[(height + 1) * (width + 1)];
        Indices = new int[height * width * 6];
        normals = new Vector3[(height + 1) * (width + 1)];
        uv = new Vector2[(height + 1) * (width + 1)];
        cellSizeX = cellSize / width;
        cellSizeY = cellSize / height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int index = y * (width + 1) + x;

               

                var vertX = ( x * cellSizeX - (width / 2));
                var vertY =  ( y * cellSizeY - (height / 2));
                vertices[index] = new Vector3((vertX), 0, (vertY));
                

                normals[index] = Vector3.back;
                uv[index] = new Vector2( (float)vertX/width,(float)vertY/height);
                

            }
        }
        int tris = 0;
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                int index = y * (width + 1) + x;
                Indices[tris + 0] = index;
                Indices[tris + 1] = index + width + 1;
                Indices[tris + 2] = index + 1;

                Indices[tris + 3] = index + 1;
                Indices[tris + 4] = index + width + 1;
                Indices[tris + 5] = index + width + 2;
                tris += 6;
            }
        }
        for(int x= 0; x <= width; x++)
        {
            for(int y = 0;y <= height;y++)
            {
                int index = y * (width + 1) + x;
                var uvs = uv[index];
                var color = heightTexture.GetPixelBilinear(uvs.x, uvs.y);
                var heightMap = ( color.r)* TerrainData.HeightMultiplier;
                vertices[index].y = heightMap - (heightMap/2);
            }
        }
        var mesh = new Mesh()
        {

            vertices = vertices,
            triangles = Indices,
            normals = normals,
            uv = uv,

            name = "TerrainSample"
        };
       
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<Renderer>().material.mainTexture = terrainTest;
   
    }
    /*
     private void Start()
     {
         vertices = new Vector3[(heightMap + 1) * (width + 1)];
         var Indices = new int[heightMap * width * 6];
         var normals = new Vector3[(heightMap + 1) * (width + 1)];
         var uv = new Vector2[(heightMap + 1) * (width + 1)];

         for (int i = 0, v = 0; i <= width; i++)
         {
             for (int j = 0; j <= heightMap; j++, v++)
             {
                 int index = (j * (width + 1) + i);
                 vertices[index] = new Vector3((i * cellSize), (j * cellSize), 0);

                 normals[v] = Vector3.back;

                 uv[v] = new Vector2(i - 1, j - 1);

             }
         }
         for (int i = 0, v = 0; i < width; i++)
         {
             for (int j = 0; j < heightMap; j++, v += 6)
             {
                 int index = j * (width + 1) + i;




                 Indices[v + 0] = index;
                 Indices[v + 1] = index + width + 1;
                 Indices[v + 2] = index + 1;

                 Indices[v + 3] = index + 1;
                 Indices[v + 4] = index + width + 1;
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
         vertices = new Vector3[(heightMap + 1) * (width + 1)];
         for (int i = 0, v = 0; i < heightMap - 1; i++)
         {
             for (int j = 0; j < width - 1; j++, v++)
             {
                 vertices[v] = new Vector3(i, j);
                 Gizmos.DrawSphere(vertices[v], 0.05f);

             }
         }
     }
 }
    */

    private void Update()
    {
       
   
            GenerateTerrain();
        
    }
}

