using UnityEngine;

public static class ExtensionFunctions
{
    // Extendeds Texture2D
    public static bool CompareTexture(this Texture2D texture1, Texture2D texture2)
    {
        Color[] firstPix = texture1.GetPixels();
        Color[] secondPix = texture2.GetPixels();
        if (firstPix.Length != secondPix.Length)
        {
            return false;
        }
        for (int i = 0; i < firstPix.Length; i++)
        {
            if (firstPix[i] != secondPix[i])
            {
                return false;
            }
        }
        return true;
    }

}