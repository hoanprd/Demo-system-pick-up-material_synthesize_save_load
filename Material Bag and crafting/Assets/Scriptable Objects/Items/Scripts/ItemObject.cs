using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Material
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    public string materialName;
    public int materialStar;
    public string materialAtribute;
}
