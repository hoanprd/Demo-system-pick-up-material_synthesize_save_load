using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FileSaveData
{
    public List<SaveData> mlsd;
    public List<SaveData> ilsd;


    public FileSaveData()
    {
        mlsd = new List<SaveData>();
        ilsd = new List<SaveData>();
    }
}
