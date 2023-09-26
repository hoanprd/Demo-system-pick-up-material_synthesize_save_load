using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New material", menuName = "GameMaterial")]
public class MaterialClass : ScriptableObject
{
    public int slotId;
    public int id;
    public string materialName;
    public int materialStar;
    public string materialAttribute;

    public Sprite artwork;

    public void PrintInfo()
    {
        Debug.Log("Star: " + materialStar);
    }
}
