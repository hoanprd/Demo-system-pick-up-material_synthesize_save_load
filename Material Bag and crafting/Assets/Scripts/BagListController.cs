using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagListController : MonoBehaviour
{
    public static BagListController Instance { get; private set; }
    public static List<GameObject> bl;
    public static List<GameObject> cl;
    public static List<GameObject> synl;
    public static List<GameObject> il;

    // Start is called before the first frame update
    void Start()
    {
        bl = new List<GameObject>();
        cl = new List<GameObject>();
        synl = new List<GameObject>();
        il = new List<GameObject>();
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
