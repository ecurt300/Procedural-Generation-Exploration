
using UnityEngine;

[System.Serializable]
public  class NoiseProfile
{
  public  int octaves;
    public float amplitude;
    public float scale;
    public float lacunarity;

    public float persistance;
    public int width;
    public int height;
}
public static class TerrainUtils
{

    public static float PerlinNoise(float x, float y, NoiseProfile noiseProfile)
    {
        float total = 0;
        float frequency = 1;
        float amplitude = 1;
        float maxValue = 0;
        for (int i = 0; i < noiseProfile.octaves; i++)
        { 



                float coordX = x / noiseProfile.width * frequency * noiseProfile.scale + 1000;
                float coordY = y / noiseProfile.height * frequency * noiseProfile.scale + 1000;
                float noise = Mathf.PerlinNoise(coordX, coordY);
                noise = 1 - Mathf.Abs(noise * 2 - 1);
                noise = Mathf.Clamp01(noise);
                total += noise * amplitude; 
                maxValue += amplitude;
                
                    
                amplitude *= noiseProfile.persistance;
                frequency *= noiseProfile.lacunarity;





      }

        
   
  

        return total / maxValue;
    }


    public static float LakeNoise(float lakeThreshold,float lakeScale,int size,float lakePower,int x, int y,NoiseProfile noiseProfile)
    {
        float coordX = RiverNoise(lakeThreshold, x, y,lakeScale,lakePower, noiseProfile);
        float coordY = RiverNoise(lakeThreshold, x,y,lakeScale,lakePower, noiseProfile);
        float height = PerlinNoise((coordX + size), (coordY + size), noiseProfile);

        if (height < lakeThreshold)
        {

            height *= 0.005f;
        }
        return height;
    }

    public static float RiverNoise(float riverThreshold, float x,float y, float warpScale, float warpStrength, NoiseProfile noiseProfile)
    {
        float noiseX = WarpedNoise(x, y, warpScale, warpStrength, noiseProfile);
        float noisY = WarpedNoise(x, y, warpScale, warpStrength, noiseProfile);
        float height = PerlinNoise(noiseX, noisY, noiseProfile);
        if (height < riverThreshold)
        {
            height *= 0.5f;
        }
        return height;
    }
    public static float WarpedNoise(float x, float y,float warpScale,float warpStrength,NoiseProfile noiseProfile)
    {
        var tempNoiseProfile = noiseProfile;
    
        


        float coordX = PerlinNoise(x + 100,y + 100, tempNoiseProfile) * warpStrength;
        float coordY = PerlinNoise(x + 100, y + 100, tempNoiseProfile) * warpStrength;

        return PerlinNoise((int)(coordX + x), (int)(coordY + y), noiseProfile);
    }
}


