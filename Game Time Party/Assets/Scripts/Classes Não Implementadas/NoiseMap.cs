using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NoiseMap 
{
    public static float[,] GerarNoiseMap(int largura,int altura,float escala,int octaves,int seed,float lacunaridade,float persistencia,Vector2 offset)
    {
        float[,] noiseMap = new float[largura, altura];
        Vector2[] octaveOffsets = new Vector2[octaves];

        System.Random prng = new System.Random(seed);
        float valorMaxDaAltura = float.MinValue;
        float valorMinDaAltura = float.MaxValue;
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(-100000, 100000) + offset.y;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }
        if(escala <= 0)
        {
            escala = 0.0001f;
        }
        for(int y = 0; y < altura; y++)
        {
            for (int x = 0; x < largura; x++)
            {
                float amplitude = 1;
                float frequencia = 1;
                float alturaDoNoise = 0;
                for(int o = 0;o < octaves; o++)
                {
                    float xValor = x / escala * frequencia;
                    float yValor = y / escala * frequencia;

                    float valorDoPerlinNoise = Mathf.PerlinNoise(xValor, yValor);
                    alturaDoNoise += valorDoPerlinNoise * amplitude;
                    amplitude *= persistencia;
                    frequencia *= lacunaridade;

                }
                if(alturaDoNoise < valorMinDaAltura)
                {
                    valorMinDaAltura = alturaDoNoise;
                }
                else if(alturaDoNoise > valorMaxDaAltura)
                {
                    valorMaxDaAltura = alturaDoNoise;
                }
                noiseMap[x, y] = alturaDoNoise;
            }
        }
        return noiseMap;
    }
}
