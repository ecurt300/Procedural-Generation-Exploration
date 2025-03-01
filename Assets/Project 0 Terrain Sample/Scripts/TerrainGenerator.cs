using System;
using UnityEngine;
[RequireComponent(typeof(MeshRenderer),typeof(MeshFilter))]
public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private bool regenerate;
    [SerializeField] private int height;
    [SerializeField] private int width;
    [SerializeField] private int cellSize = 1;
    [SerializeField] TerrainData TerrainData;


    private void GenerateTerrain()
    {
        
        Texture2D heightTexture = TerrainData.GenerateHeightmapTexture();
        width = heightTexture.width;
        height = heightTexture.height;
        var vertices = new Vector3[(height + 1) * (width + 1)];
        var Indices = new int[height * width * 6];
        var normals = new Vector3[(height + 1) * (width + 1)];
        var uv = new Vector2[(height + 1) * (width + 1)];

        for (int x = 0, v = 0; x <= height; x++)
        {
            for (int y = 0; y <= width; y++, v++)
            {
                int index = y * (width + 1) + x;
                var coordX = x * cellSize % heightTexture.width;
                var coordY = y * cellSize % heightTexture.height;
                var heightMap = heightTexture.GetPixelBilinear(uv[index].x, uv[index].y).r * 2000;


                vertices[index] = new Vector3((x * width * 2 ) * cellSize, 0, (y * height * 2 ) * cellSize);
                vertices[index].y += heightMap;

                normals[v] = Vector3.back;
                uv[v] = new Vector2( (float)x/1000,(float)y/1000);

            }
        }

        for (int x = 0, v = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++, v+=6)
            {
                int index = y * (width + 1) + x;
                Indices[v + 0] = index;
                Indices[v + 1] = index + width + 1;
                Indices[v + 2] = index + 1;

                Indices[v + 3] = index + 1;
                Indices[v + 4] = index + width + 1;
                Indices[v + 5] = index + width + 2;

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
        GetComponent<Renderer>().material.mainTexture = heightTexture;
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(4, 4);
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
        if(regenerate)
        {
            regenerate = false;
            GenerateTerrain();
        }
    }
}

