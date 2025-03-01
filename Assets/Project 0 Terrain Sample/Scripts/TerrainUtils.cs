
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

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

    public static float LayeredPerlinNoise(float offsetX,float flattness,float offsetY,int octaves,float octave1,float octave2,float octave3,float octave4,float x,float y,int width,int height,float scale)
    {
        float total = 0;
        float waveLength = scale / (width * height);
        float e = 0;
        for (int oc = 0; oc < octaves; oc++)
        {
            float xCoord = (x / width) + offsetX;
            float yCoord = (y / height) + offsetY;
            float noise0 = Mathf.PerlinNoise(xCoord *  scale, yCoord * scale)  * octave1;
            float noise1 = Mathf.PerlinNoise(xCoord *  scale, yCoord *  scale) * octave2;
            float noise2 = Mathf.PerlinNoise(xCoord *  scale, yCoord *  scale)  * octave3;
         
          
            
           
            total += noise0 + noise1 + noise2 ;
           
           e = Mathf.Pow(total ,flattness);

           
        }

        return e; 
    }
   
}


