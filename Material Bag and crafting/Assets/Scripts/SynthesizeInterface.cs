using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SynthesizeInterface : MonoBehaviour
{
    SynthesizeController sc;

    public GameObject[] manaCoreStarDisplay;
    public GameObject chooseListPanel, manaCoreChooseDisplay;

    public static int manaCoreStarValue;
    public static bool chooseLoad, pushBackLoad, woodHad, pureWaterHad, itemSynRes;

    // Start is called before the first frame update
    void Start()
    {
        sc = FindObjectOfType<SynthesizeController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (woodHad && pureWaterHad && BagListController.synl.Count == 2)
        {
            manaCoreChooseDisplay.GetComponent<Image>().color = Color.red;

            manaCoreStarValue = (SynthesizeController.woodStarValue + SynthesizeController.pureWaterStarValue) / 2;

            for (int i = 0; i < manaCoreStarValue; i++)
            {
                manaCoreStarDisplay[i].SetActive(true);
            }
        }
    }

    public void ChooseWoodList()
    {
        if (!chooseLoad && !woodHad)
        {
            chooseLoad = true;
            woodHad = true;
            chooseListPanel.SetActive(true);
            sc.ChooseListIndex(0);
        }
    }

    public void ChooseWaterList()
    {
        if (!chooseLoad && !pureWaterHad)
        {
            chooseLoad = true;
            pureWaterHad = true;
            chooseListPanel.SetActive(true);
            sc.ChooseListIndex(1);
        }
    }

    public void SynthesizeManaCore()
    {
        if (woodHad && pureWaterHad && BagListController.synl.Count == 2)
        {
            woodHad = false;
            pureWaterHad = false;
            SynthesizeController.woodOff = true;
            SynthesizeController.pureWaterOff = true;
            sc.RemoveChooseList();
            sc.AddItemBagList();
        }
    }

    public void CloseChooseListPanel()
    {
        chooseLoad = false;
        woodHad = false;
        pureWaterHad = false;
        AddMaterials.closeSynthesizeChoose = true;
    }

    public void CloseSynthesizePanel()
    {
        if (itemSynRes)
        {
            chooseLoad = false;
            pushBackLoad = true;
            woodHad = false;
            pureWaterHad = false;
            manaCoreChooseDisplay.GetComponent<Image>().color = Color.white;
            SynthesizeController.woodOff = true;
            SynthesizeController.pureWaterOff = true;
            AddMaterials.closeSynthesize = true;
        }
        else
        {
            chooseLoad = false;
            pushBackLoad = true;
            woodHad = false;
            pureWaterHad = false;
            manaCoreChooseDisplay.GetComponent<Image>().color = Color.white;
            for (int i = 0; i < 5; i++)
            {
                manaCoreStarDisplay[i].SetActive(false);
            }
            sc.PushBackChooseList();
            SynthesizeController.woodOff = true;
            SynthesizeController.pureWaterOff = true;
            AddMaterials.closeSynthesize = true;
        }
    }
}
