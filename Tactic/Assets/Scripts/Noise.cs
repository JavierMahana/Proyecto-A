using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise  {


    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, Vector2 offSet, int octaves, float persistance, float lacunarity, float scale)
    {
        Debug.Log("inicio noise");
        System.Random prng = new System.Random(seed);
        Vector2[] octavesOffSet = new Vector2[octaves];

        for (int i = 0; i < octaves; i++)
        {
            float offSetX = prng.Next(-100000, 100000) + offSet.x;
            float offSetY = prng.Next(-100000, 100000) + offSet.y;
            octavesOffSet[i] = new Vector2(offSetX, offSetY);
        }
        Debug.Log("post offset");
        float[,] noiseMap = new float[mapWidth, mapHeight];
     
        if (scale == 0)
        {
            scale = 0.0001f;
        }

        float maxValue = float.MinValue;
        float minValue = float.MaxValue;

        float halfWidth = mapWidth / 2;
        float HalfHeight = mapHeight / 2;

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {

                float amplitude = 1;
                float frecuency = 1;



                float noiseHeight = 0;
                for (int i = 0; i < octaves; i++)
                {
                    

                    float sampleX = (x - halfWidth) / scale * frecuency + octavesOffSet[i].x;
                    float sampleY = (y - HalfHeight) / scale * frecuency + octavesOffSet[i].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    
                    noiseHeight += perlinValue * amplitude;

                    

                    amplitude *= persistance;
                    frecuency *= lacunarity;
                }

                if (noiseHeight> maxValue)
                {
                    maxValue = noiseHeight;
                }
                else if (noiseHeight < minValue)
                {
                    minValue = noiseHeight;
                }

                noiseMap[x, y] = noiseHeight;

            }
        }
        Debug.Log("post creacion noise heigth");
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minValue, maxValue, noiseMap[x, y]);
            }
        }
        Debug.Log("noise normalizado");
        return noiseMap;
    }

}
