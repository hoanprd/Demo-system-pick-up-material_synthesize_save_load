using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public ItemClass ic;
    public Image itemSprite;
    public GameObject thisGameObject;
    public GameObject[] star;

    public int[] slotArray;
    public int iSlotId;
    public int iId;
    public string iName;
    public int iStar;
    public string iAttribute;

    // Start is called before the first frame update
    void Start()
    {
        slotArray = new int[1000];
        for (int i = 0; i < 1000; i++)
        {
            slotArray[i] = i;
        }

        StartCoroutine(LoadDelay());
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(0f);

        if (AddMaterials.LoadGame == false && SynthesizeInterface.chooseLoad == false)
        {
            int temp = 0;
            bool a = false;
            if (BagListController.il.Count > 0)
            {
                for (int i = 0; i < BagListController.il.Count; i++)
                {
                    foreach (GameObject go in BagListController.il)
                    {
                        if (go.GetComponent<ItemDisplay>().iSlotId == slotArray[i])
                        {
                            a = true;
                            break;
                        }
                    }
                    if (a == true)
                    {
                        a = false;
                        temp = slotArray[i] + 1;
                        iSlotId = temp;
                    }
                    else
                    {
                        temp = slotArray[i];
                        iSlotId = temp;
                        break;
                    }
                }
            }
            else
            {
                iSlotId = 0;
            }

            ic.itemStar = SynthesizeInterface.manaCoreStarValue;
            itemSprite.sprite = ic.artwork;
            iId = ic.id;
            iName = ic.itemName;
            iStar = ic.itemStar;
            iAttribute = ic.itemAttribute;

            for (int i = 0; i < iStar; i++)
            {
                star[i].SetActive(true);
            }

            BagListController.il.Add(thisGameObject);
        }
        else
        {
            itemSprite.sprite = ic.artwork;

            for (int i = 0; i < iStar; i++)
            {
                star[i].SetActive(true);
            }
        }

        /*if (AddMaterials.LoadGame == false && SynthesizeInterface.chooseLoad == false && SynthesizeInterface.pushBackLoad == false)
        {
            Debug.Log("Hi");
            int temp = 0;
            bool a = false;
            if (BagListController.il.Count > 0)
            {
                for (int i = 0; i < BagListController.il.Count; i++)
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
                        iSlotId = temp;
                    }
                    else
                    {
                        temp = slotArray[i];
                        iSlotId = temp;
                        break;
                    }
                }
            }
            else
            {
                iSlotId = 0;
            }
            Debug.Log("Hi2");
            ic.itemStar = SynthesizeInterface.manaCoreStarValue;
            itemSprite.sprite = ic.artwork;
            iId = ic.id;
            iName = ic.itemName;
            iStar = ic.itemStar;
            iAttribute = ic.itemAttribute;

            for (int i = 0; i < iStar; i++)
            {
                star[i].SetActive(true);
            }

            BagListController.il.Add(thisGameObject);
        }
        else
        {
            Debug.Log("Hi3");
            itemSprite.sprite = ic.artwork;

            for (int i = 0; i < iStar; i++)
            {
                star[i].SetActive(true);
            }
        }*/
    }
}
