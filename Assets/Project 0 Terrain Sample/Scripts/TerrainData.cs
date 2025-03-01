using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine.UIElements;
[System.Serializable]
public class TerrainData
{
    Texture2D heightMap;

    public int width = 200;
    public int height = 200;
    [SerializeField] private int octaves;
    [SerializeField] private float scale;
    [SerializeField] private float heightMultiplier;
    [SerializeField] private float moistureAmount;
    public float HeightMultiplier
    {
        get { return heightMultiplier; }
    }

    public Texture2D HeightMap { get => heightMap; set => heightMap = value; }

    public void Initialize()
    {
        HeightMap = new Texture2D(width, height);
    }
    public Texture2D GenerateHeightmapTexture(int x, int y)
    {





        float Xcoord = (float)x / 200 * scale;
        float Ycoord = (float)y / 200 * scale;
        float sample = Mathf.PerlinNoise(Xcoord, Ycoord);




        Color color = new Color(sample, sample, sample);

        HeightMap.SetPixel((int)Xcoord, (int)Ycoord, color);



        HeightMap.filterMode = FilterMode.Point;
        HeightMap.Apply();
        return HeightMap;

    }



}


    
