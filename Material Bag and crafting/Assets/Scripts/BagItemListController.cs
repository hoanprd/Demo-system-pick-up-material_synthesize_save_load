using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagItemListController : MonoBehaviour
{
    public static List<GameObject> item;

    // Start is called before the first frame update
    void Start()
    {
        item = new List<GameObject>();
    }
}
