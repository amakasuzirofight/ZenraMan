using UnityEngine;

public class TrimmingTexture
{
    /*
    public static Texture2D Trim(Vector2Int pointRightTop, Vector2Int pointLeftBottom, Texture2D inputTex)
    {
        var tw = pointRightTop.x - pointLeftBottom.x;
        var th = pointLeftBottom.y - pointRightTop.y;
        var result = new Texture2D(tw, th);

        int CenterY = inputTex.height / 2;
        int additionalX = inputTex.width - pointRightTop.x;
        int additionalY = pointRightTop.y;
        if ((pointRightTop.y + pointRightTop.y) / 2 < CenterY) additionalY *= -1;
        Debug.Log(pointRightTop + "/" + pointLeftBottom + "/" + tw + "/" + th + "/" + additionalX + "/" + additionalY);
        var pixels = inputTex.GetPixels(additionalX, CenterY + additionalY, tw, th);
        result.SetPixels(pixels);
        result.Apply();
        return result;
    }
    */
    public static Texture2D Trim(Vector2Int pointRightTop, Vector2Int pointLeftBottom, Texture2D inputTex)
    {
        var tw = pointRightTop.x - pointLeftBottom.x;
        var th = pointLeftBottom.y - pointRightTop.y;
        var result = new Texture2D(tw, th);

        int additionalX = inputTex.width - pointRightTop.x;
        int additionalY = inputTex.height - pointLeftBottom.y;
        var pixels = inputTex.GetPixels(additionalX, additionalY, tw, th);
        result.SetPixels(pixels);
        result.Apply();
        return result;
    }
}