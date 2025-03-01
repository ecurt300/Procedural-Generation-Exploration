using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine.UIElements;
[System.Serializable]
public class TerrainProfile
{
    public int width;
    public int height;
    public float RiverThreshold;
    public float LakeThreshold;
    public float lakePower;
    public float riverStrength;
    public float riverPower;
    public float lakeSize;
}

[System.Serializable]
public class TerrainData
{
  
    public Texture2D heightMap;
    public Texture2D lastHeightMap;
    public Texture2D colorMap;
    public NoiseProfile profile;
    public TerrainProfile terrainProfile;

    public float GenerateHeight()
    {
        float maxValue = 0;
        float total = 0;
        for (int i = 0; i < terrainProfile.width; i++)
        {
            for (int j = 0; j < terrainProfile.height; j++)
            {
                float xCoord = i / terrainProfile.width * profile.scale;
                float yCoord = j / terrainProfile.height * profile.scale;

                float noise = TerrainUtils.PerlinNoise(i, j, profile);
                float riverNoise = TerrainUtils.RiverNoise(terrainProfile.RiverThreshold, (int)xCoord, (int)yCoord, terrainProfile.riverPower, terrainProfile.riverStrength, profile);
                float lakeNoise = TerrainUtils.LakeNoise(terrainProfile.LakeThreshold, terrainProfile.lakePower, (int)terrainProfile.lakeSize, terrainProfile.lakePower, (int)xCoord, (int)yCoord, profile);
                noise *= riverNoise;

                total += noise;
                maxValue += profile.amplitude;




            }
        }
        return total / maxValue;
    }
    


public Texture2D GenerateHeightmapTexture()
    {
       heightMap = new Texture2D(200,200);
       

        for (int i = 0; i < terrainProfile.height; i++)
        {
            for (int j = 0; j < terrainProfile.width; j++)
            {
                float xCoord = (float)i / profile.width * profile.scale;
                float yCoord = (float)j / profile.height * profile.scale;
                float sample = TerrainUtils.WarpedNoise(xCoord,yCoord,profile.scale,terrainProfile.riverStrength,profile);
                float riverMask = TerrainUtils.RiverNoise(terrainProfile.RiverThreshold,xCoord,yCoord,terrainProfile.riverPower,terrainProfile.riverStrength,profile);
                float height = sample;
                if(height < terrainProfile.RiverThreshold)
                {
                    height *= riverMask * 0.5f;
                }
                Color color = new Color(height, height, height);

                heightMap.SetPixel(i, j, color);

            }
        }
        
        heightMap.filterMode = FilterMode.Point;
        heightMap.Apply();
        return heightMap;
        
    }
        
   
   
}
