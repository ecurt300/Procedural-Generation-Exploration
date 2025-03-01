
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

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
    /*
     * Standard Layered PerlinNoise 
     * As work on more complex terrain we include things such as 
     * Temperature,
     * Elevation and 
     * Moisture masks
     * Since we are working with a single terrain sample and not planets we don't have to worry about equatorial temperature
     * changes
     */

    public static float[,] NoiseMap( int width,int height,float scale,int octaves)
    {
        float[,] map = new float[width,height];
        
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                for (int i = 0; i < octaves; i++)
                {
                    float xCoord = ((x * scale / width) + 1000);
                    float yCoord = ((y * scale / height) + 1000);
                    float noise = Mathf.PerlinNoise(xCoord, yCoord);
                    map[x, y] += noise;

                }
            }
        }
        return map;
    }


    public static float LayeredPerlinNoise(float offsetX,float flattness,float offsetY,float x,float y,int width,int height,float scale)
    {
        float total = 0;
        
        float e = 0;
        for (int oc = 0; oc < 4; oc++)
        {
            float xCoord = (x / width) + offsetX;
            float yCoord = (y / height) + offsetY;
            float noise0 = Mathf.PerlinNoise(xCoord *  scale, yCoord * scale);
           
         
          
            
           
            total = noise0;
           
           e = Mathf.Pow(total ,flattness);

           
        }

        return e; 
    }
   
}


