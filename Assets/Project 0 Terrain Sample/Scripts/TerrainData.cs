using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine.UIElements;
[System.Serializable]
public class TerrainData : MonoBehaviour
{
    Texture2D heightMap;

    [SerializeField] private float width;
    [SerializeField] private float height;
    [SerializeField] private int octaves;
    [SerializeField] private float scale;
    [SerializeField] private float persistance;
    [SerializeField] private float lacunarity;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float octave1, octave2,octave3,octave4;
    [SerializeField] private float heightMultiplier;
    [SerializeField] private float moistureAmount;
    public float HeightMultiplier
    {
        get { return heightMultiplier; }
    }
    public Texture2D GenerateHeightmapTexture()
        {
         


            for (int i = 0; i < 200; i++)
            {
                for (int j = 0; j < 200; j++)
                {

                    float height = TerrainUtils.LayeredPerlinNoise(offsetX,moistureAmount,offsetY,octaves,octave1,octave2,octave3,octave4,i,j,200,200,scale);
                  

               
                    float sample = height;
                   
                    Color color = new Color(sample,sample,sample);
                        
                    heightMap.SetPixel(i, j, color);

                }
            }

            heightMap.filterMode = FilterMode.Point;
            heightMap.Apply();
            return heightMap;

        }
    private void Start()
    {
       heightMap = new Texture2D(200, 200);
    }
    private void Update()
    {
    }

}

    
