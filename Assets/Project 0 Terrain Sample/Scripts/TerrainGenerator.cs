using System;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;
[RequireComponent(typeof(MeshRenderer),typeof(MeshFilter))]
public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int octaves;
    [SerializeField] private float scale;
    [Range(1f, 4f)]
    [SerializeField] private int LOD = 1;
    [SerializeField] private int height;
    [SerializeField] private int width;
    [SerializeField] private int meshSimplicationIncrement = 1;
    
    [SerializeField] TerrainData TerrainData;
    [SerializeField] Texture2D terrainTest;
    private MeshData meshData;
    [SerializeField] int vertexPerLine;
    private void InitMesh()
    {
        meshSimplicationIncrement = LOD;
        vertexPerLine = (width-1)/ meshSimplicationIncrement + 1;
        meshData = new MeshData(vertexPerLine, vertexPerLine);
    }

    void GenerateTerrainMesh()
    {
        float[,] noiseMap = TerrainUtils.NoiseMap(width, height, scale,octaves);
       
        for (int x = 0,i = 0; x < width; x += meshSimplicationIncrement)
        {
            for (int y = 0; y < height; y += meshSimplicationIncrement,i++)
            {
                
                int  index = i;
                meshData.Vertices[index] = new Vector3(x - width / 2, 0, y - height / 2);
                meshData.Normals[index] = Vector3.back;
                var sample =  noiseMap[x, y];
                Color terrainColor = new Color(sample, sample, sample);
               
                meshData.Uvs[index] = new Vector2(((float)x )/ width, (((float)y )/ height)) ;
                meshData.Vertices[index].y = sample;
                if (x < width - 1 && y < height - 1)
                {
                    meshData.AddTriangle( index, index +vertexPerLine + 1, index + vertexPerLine);
                    meshData.AddTriangle( index + vertexPerLine + 1, index, index +1);
                }
               // terrainTest.SetPixel(x, y, terrainColor);

            }
         
        }
        
    }

    private void GenerateTerrain()
    {


        /*
         private void Start()
         {
             Texture2D heightTexture = TerrainData.GenerateHeightmapTexture();
            var totalVertices = ((height  + 1) * (width  + 1));
            Debug.Log(totalVertices);
           vertices = new Vector3[totalVertices];
           Indices = new int[totalVertices * 6];
          var  normals = new Vector3[totalVertices];
          var  uv = new Vector2[(totalVertices)];
           var cellSizeX = cellSize / width;
           var cellSizeY = cellSize / height;

            for (int x = 0; x <= height; x++)
            {
                for (int y = 0; y <= width ; y++)
                {
                    int index = y * (width) + x;



                    var vertX =  x - (width / 2);
                    var vertY =   y - (height / 2);
                    vertices[index] = new Vector3((vertX * cellSizeX ), 0, (vertY * cellSizeY));


                    normals[index] = Vector3.back;
                    uv[index] = new Vector2( (float)vertX/width,(float)vertY/height);


                }
            }
            int tris = 0;
            for (int x = 0; x < height ; x += 2)
            {
                for (int y = 0; y < width; y+= 2)
                {
                    int index = y * (width) + x;
                    Indices[tris + 0] = index ;
                    Indices[tris + 1] = index + width + 1;
                    Indices[tris + 2] = index  + 1;

                    Indices[tris + 3] = index + 1;
                    Indices[tris + 4] = index + width + 1;
                    Indices[tris + 5] = index + width + 2;
                    tris += 6;
                }
            }
            for(int x= 0; x < width; x++)
            {
                for(int y = 0;y < height;y++)
                {
                    int index = y * (width + 1) + x;
                    var uvs = uv[index];
                    var color = heightTexture.GetPixelBilinear(uvs.x, uvs.y);
                    var heightMap = ( color.r)* TerrainData.HeightMultiplier;
                    vertices[index].y = heightMap;
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

        }
     }
        */
    }

    private void Start()
    {
        TerrainData.Initialize();
        terrainTest = new Texture2D(width, height);
    }
    private void Update()
    {


        InitMesh();
        GenerateTerrainMesh();
        GetComponent<MeshFilter>().mesh = meshData.GenerateMesh();
        GetComponent<Renderer>().material.mainTexture = terrainTest;
    }
}

