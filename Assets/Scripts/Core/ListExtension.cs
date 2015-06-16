using UnityEngine;
using System.Collections.Generic;

public static class ListExtension 
{
    public static T GetRandomObject<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}
