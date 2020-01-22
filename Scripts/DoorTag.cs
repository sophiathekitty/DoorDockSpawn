using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Room/Door Tag")]
public class DoorTag : ScriptableObject
{
    public Color color;
    public Vector3 size;
    public Vector3 pos;
    public bool mirror;
}
