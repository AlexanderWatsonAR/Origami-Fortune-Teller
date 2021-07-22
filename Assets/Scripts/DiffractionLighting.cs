using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffractionLighting : MonoBehaviour
{
    private Texture2D SpectralTexture;
    public int Width = 1024;
    public int Height = 1024;

    private int MinWaveLength = 380;
    private int MaxWaveLength = 750;
    private float Distance;
    private void Start()
    {
        SpectralTexture = new Texture2D(Width, Height);
        SpectralTexture.wrapMode = TextureWrapMode.Clamp;
        SpectralTexture.filterMode = FilterMode.Bilinear;
        CreateTexture();
        GameObject mainLight = FindObjectOfType<Light>().gameObject;
        Distance = Vector3.Distance(transform.position, mainLight.transform.position);
    }

    private void CreateTexture()
    {
        // Loops over all the pixels
        for (int y = 0; y < SpectralTexture.height; y++)
        {
            // y:     [0, texture.height-1]
            // TdotL: [-1, +1]
            float TdotL = (y / (float)(SpectralTexture.height - 1)) * 2f - 1f;

            for (int x = 0; x < SpectralTexture.width; x++)
            {
                // y:     [0, texture.width-1]
                // TdotL: [-1, +1]
                float TdotV = (x / (float)(SpectralTexture.width - 1)) * 2f - 1f;

                Color color = DiffractionGrating(TdotV, TdotL);
                SpectralTexture.SetPixel(x, y, color);
            }
        }
        SpectralTexture.Apply();

        GetComponent<Renderer>().material.mainTexture = SpectralTexture;
    }

    private Color DiffractionGrating(float TdotV, float TdotL)
    {
        
        float cos_ThetaL = TdotL; //dot(L, T);
        float cos_ThetaV = TdotV; //dot(V, T);
        float u = Mathf.Abs(cos_ThetaL - cos_ThetaV);
        if (u == 0)
            return Color.black;

        // Diffraction grating
        // for constructive interference
        Color color = Color.black;
        for (int n = 1; n <= 8; n++)
        {
            float wavelength = u * Distance / n;
            color += SpectralColor(wavelength);
        }
        return color;
    }

    private Color SpectralColor(float wavelength)
    {
        // wavelength: [MinWavelength, MaxWavelength]
        // u:          [0,   1  ]
        float u = (wavelength - MinWaveLength) / (MaxWaveLength - MinWaveLength);
        return SpectralTexture.GetPixelBilinear(u, 0.5f);
    }
}
