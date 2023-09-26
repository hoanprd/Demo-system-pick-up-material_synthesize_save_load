using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SynthesizeController : MonoBehaviour
{
    public GameObject[] prefab, prefabBag;
    public GameObject[] woodChooseDisplay, pureWaterChooseDisplay;
    public GameObject[] woodStarDisplay, pureWaterStarDisplay;
    public GameObject[] itemPrefab;
    public Transform root, rootBag, itemRootBag;

    public static int woodStarValue, pureWaterStarValue;
    public static bool LoadGame, woodOn, pureWaterOn, manaCoreOn, woodOff, pureWaterOff, manaCoreOff;

    void Update()
    {
        if (woodOn)
        {
            woodOn = false;
            woodChooseDisplay[0].GetComponent<Image>().color = Color.red;
            for (int i = 0; i < woodStarValue; i++)
            {
                woodStarDisplay[i].SetActive(true);
            }
        }
        else if (pureWaterOn)
        {
            pureWaterOn = false;
            pureWaterChooseDisplay[0].GetComponent<Image>().color = Color.red;
            for (int i = 0; i < pureWaterStarValue; i++)
            {
                pureWaterStarDisplay[i].SetActive(true);
            }
        }

        if (woodOff)
        {
            woodOff = false;
            woodChooseDisplay[0].GetComponent<Image>().color = Color.white;
            for (int i = 0; i < 5; i++)
            {
                woodStarDisplay[i].SetActive(false);
            }
        }
        else if (pureWaterOff)
        {
            pureWaterOff = false;
            pureWaterChooseDisplay[0].GetComponent<Image>().color = Color.white;
            for (int i = 0; i < 5; i++)
            {
                pureWaterStarDisplay[i].SetActive(false);
            }
        }
    }

    public void ChooseListIndex(int index)
    {
        foreach (GameObject go in BagListController.bl)
        {
            MaterialDisplay materialDisplay = go.GetComponent<MaterialDisplay>();

            if (materialDisplay.mId == index)
            {
                GameObject materialObject = Instantiate(prefab[materialDisplay.mId], root);

                int slotId;
                int id;
                string name;
                int star;
                string attribute;

                slotId = go.GetComponent<MaterialDisplay>().mSlotId;
                id = go.GetComponent<MaterialDisplay>().mId;
                name = go.GetComponent<MaterialDisplay>().mName;
                star = go.GetComponent<MaterialDisplay>().mStar;
                attribute = go.GetComponent<MaterialDisplay>().mAttribute;

                materialDisplay = materialObject.GetComponent<MaterialDisplay>();

                materialDisplay.mSlotId = slotId;
                materialDisplay.mId = id;
                materialDisplay.mName = name;
                materialDisplay.mStar = star;
                materialDisplay.mAttribute = attribute;

                BagListController.cl.Add(materialObject);
            }
        }
    }

    public void AddItemBagList()
    {
        Instantiate(itemPrefab[0], itemRootBag);
    }

    public void PushBackChooseList()
    {
        if (SaveListData.listSynthesize != null)
        {
            Debug.Log(SaveListData.listSynthesize.Count);
            foreach (SaveData sd in SaveListData.listSynthesize.ToArray())
            {
                GameObject materialObject = Instantiate(prefabBag[sd.sId], rootBag);

                MaterialDisplay materialDisplay = materialObject.GetComponent<MaterialDisplay>();

                // Set the properties based on the loaded data
                materialDisplay.mSlotId = sd.sSlotId;
                materialDisplay.mId = sd.sId;
                materialDisplay.mName = sd.sName;
                materialDisplay.mStar = sd.sStar;
                materialDisplay.mAttribute = sd.sAttribute;

                Debug.Log("Hi");
                BagListController.bl.Add(materialObject);
                //BagListController.synl.Remove(materialObject);
                //SaveListData.listSynthesize.Remove(sd);
            }

            foreach (SaveData sd in SaveListData.listSynthesize.ToArray())
            {
                SaveListData.listSynthesize.Remove(sd);
            }

            foreach (GameObject go in BagListController.synl.ToArray())
            {
                BagListController.synl.Remove(go);
            }
        }
    }

    public void RemoveChooseList()
    {
        foreach (SaveData sd in SaveListData.listSynthesize.ToArray())
        {
            SaveListData.listSynthesize.Remove(sd);
        }

        foreach (GameObject go in BagListController.cl.ToArray())
        {
            BagListController.synl.Remove(go);
        }
    }
}
