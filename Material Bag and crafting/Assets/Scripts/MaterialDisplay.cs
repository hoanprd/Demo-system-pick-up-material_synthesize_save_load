using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialDisplay : MonoBehaviour
{
    public MaterialClass mc;
    public Image materialSprite;
    public GameObject thisGameObject;
    public GameObject[] star;

    public int[] slotArray;
    private int materialStarRandom;
    public int mSlotId;
    public int mId;
    public string mName;
    public int mStar;
    public string mAttribute;

    // Start is called before the first frame update
    void Start()
    {
        slotArray = new int[9999];
        for (int i = 0; i < 9999; i++)
        {
            slotArray[i] = i;
        }

        StartCoroutine(LoadDelay());
    }

    public void ChooseToSynthesize()
    {
        SynthesizeInterface.chooseLoad = false;

        foreach (GameObject go in BagListController.cl.ToArray())
        {
            MaterialDisplay materialDisplay = go.GetComponent<MaterialDisplay>();

            if (materialDisplay.mSlotId == this.mSlotId)
            {
                SaveData sd = new SaveData();
                sd.sSlotId = materialDisplay.mSlotId;
                sd.sId = materialDisplay.mId;
                sd.sName = materialDisplay.mName;
                sd.sStar = materialDisplay.mStar;
                sd.sAttribute = materialDisplay.mAttribute;

                Debug.Log(sd.sName);

                SaveListData.listSynthesize.Add(sd);

                if (sd.sId == 0)
                {
                    SynthesizeController.woodStarValue = sd.sStar;
                    SynthesizeController.woodOn = true;
                }
                else if (sd.sId == 1)
                {
                    SynthesizeController.pureWaterStarValue = sd.sStar;
                    SynthesizeController.pureWaterOn = true;
                }

                BagListController.synl.Add(thisGameObject);

                foreach (GameObject go2 in BagListController.bl.ToArray())
                {
                    MaterialDisplay materialDisplay2 = go2.GetComponent<MaterialDisplay>();

                    if (materialDisplay2.mSlotId == this.mSlotId)
                    {
                        BagListController.bl.Remove(go2);
                        Destroy(go2);
                    }
                }
                BagListController.cl.Remove(go);
                Destroy(go);
            }
        }

        AddMaterials.closeBag = true;
        AddMaterials.closeSynthesizeChoose = true;
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(0f);

        if (AddMaterials.LoadGame == false && SynthesizeInterface.chooseLoad == false && SynthesizeInterface.pushBackLoad == false)
        {
            int temp = 0;
            bool a = false;
            if (BagListController.bl.Count > 0)
            {
                for (int i = 0; i < BagListController.bl.Count; i++)
                {
                    foreach (GameObject go in BagListController.bl)
                    {
                        if (go.GetComponent<MaterialDisplay>().mSlotId == slotArray[i])
                        {
                            a = true;
                            break;
                        }
                    }
                    if (a == true)
                    {
                        a = false;
                        temp = slotArray[i] + 1;
                        mSlotId = temp;
                    }
                    else
                    {
                        temp = slotArray[i];
                        mSlotId = temp;
                        break;
                    }
                }
            }
            else
            {
                mSlotId = 0;
            }

            materialStarRandom = Random.Range(1, 6);
            mc.materialStar = materialStarRandom;
            materialSprite.sprite = mc.artwork;
            mId = mc.id;
            mName = mc.materialName;
            mStar = mc.materialStar;
            mAttribute = mc.materialAttribute;

            BagListController.bl.Add(thisGameObject);

            for (int i = 0; i < mStar; i++)
            {
                star[i].SetActive(true);
            }

            //Debug.Log(BagListController.bl.Count);

            /*foreach (GameObject go in BagListController.bl)
            {
                Debug.Log("ID: " + go.GetComponent<MaterialDisplay>().mId);
                Debug.Log("Name: " + go.GetComponent<MaterialDisplay>().mName);
                Debug.Log("Star: " + go.GetComponent<MaterialDisplay>().mStar);
            }*/
        }
        else
        {
            materialSprite.sprite = mc.artwork;

            for (int i = 0; i < mStar; i++)
            {
                star[i].SetActive(true);
            }
        }
    }
}
