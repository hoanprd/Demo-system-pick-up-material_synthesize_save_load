using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveListData : MonoBehaviour
{
    public static SaveListData Instance { get; private set; }
    public List<SaveData> lsd;
    public static List<SaveData> listSynthesize;

    public SaveListData()
    {
        lsd = new List<SaveData>();
        listSynthesize = new List<SaveData>();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
