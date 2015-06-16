using UnityEngine;
using System.Collections;

public static class TransformExtension 
{
    /// <summary>
    /// Returns a point within the transform object. E.g. if you set the scale to 800 on the x and 640 on the y it will 
    /// return a point from the middle of the transform and 400 on the x axis on either side and 320 on the y axis on either side
    /// </summary>
    /// <param name="transform"></param>
    /// <returns></returns>
    public static Vector3 GetRandomPointInTransform(this Transform transform)
    {
        Vector3 randomPositionWithin;
        randomPositionWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0.0f);
        randomPositionWithin = transform.TransformPoint(randomPositionWithin * .5f);
        return randomPositionWithin;
    }
}
