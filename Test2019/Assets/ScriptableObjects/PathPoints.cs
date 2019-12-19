using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Path Points")]
public class PathPoints : ScriptableObject
{
    public List<Vector3> points = new List<Vector3>();
}
