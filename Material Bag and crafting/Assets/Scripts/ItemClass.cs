using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "GameItem")]
public class ItemClass : ScriptableObject
{
    public int slotId;
    public int id;
    public string itemName;
    public int itemStar;
    public string itemAttribute;

    public Sprite artwork;
}
