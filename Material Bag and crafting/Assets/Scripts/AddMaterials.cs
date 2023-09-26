using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class AddMaterials : MonoBehaviour
{
    public GameObject[] prefab, prefabItem;
    public GameObject bagList, synthesizeList, synthesizeListChoose, chooseListContentSynthesize, chooseListContentBag;
    //public GameObject prefab2;
    public Transform root, rootItem;
    public static bool LoadGame, closeSynthesize, closeSynthesizeChoose, closeBag, synthesizeOff;
    string userPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    // Start is called before the first frame update
    void Start()
    {
        if (!Directory.Exists($"{userPath}\\{"PRD Team"}"))
        {
            Directory.CreateDirectory($"{userPath}\\{"PRD Team"}");
        }

        //SaveListData.bagMaterialsld = new List<SaveData>();

        // Now, you can access the loaded data as needed
        /*foreach (SaveData saveData in SaveListData.bagMaterialsld)
        {
            // Instantiate the prefab
            GameObject materialObject = Instantiate(prefab[saveData.sId], root);

            // Attach it to the parent GameObject
            //materialObject.transform.parent = root;

            // Get the MaterialDisplay component from the instantiated GameObject
            MaterialDisplay materialDisplay = materialObject.GetComponent<MaterialDisplay>();

            // Set the properties based on the loaded data
            materialDisplay.mSlotId = saveData.sSlotId;
            materialDisplay.mId = saveData.sId;
            materialDisplay.mName = saveData.sName;
            materialDisplay.mStar = saveData.sStar;
            materialDisplay.mAttribute = saveData.sAttribute;

            BagListController.bl.Add(materialObject);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab[0], root);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(prefab[1], root);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            //ChangePlace = true;
            SceneManager.LoadScene("OutSide");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            //ChangePlace = true;
            SceneManager.LoadScene("InSide");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SynthesizeInterface.chooseLoad = false;
            closeSynthesize = true;
            bagList.SetActive(true);
            StartCoroutine(DelayLoadPushBack());
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            closeBag = true;
            synthesizeList.SetActive(true);
        }

        if (closeSynthesize)
        {
            closeSynthesize = false;
            foreach (GameObject go in BagListController.cl.ToArray())
            {
                BagListController.cl.Remove(go);
            }
            DestroyObject(chooseListContentSynthesize);
            synthesizeList.SetActive(false);
        }
        if (closeSynthesizeChoose)
        {
            closeSynthesizeChoose = false;
            foreach (GameObject go in BagListController.cl.ToArray())
            {
                BagListController.cl.Remove(go);
            }
            DestroyObject(chooseListContentSynthesize);
            synthesizeListChoose.SetActive(false);
        }
        if (synthesizeOff)
        {
            synthesizeOff = false;
            synthesizeList.SetActive(false);
        }
        if (closeBag)
        {
            closeBag = false;
            //DestroyObject(chooseListContentBag);
            bagList.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            FileSaveData sld = new FileSaveData();
            sld.mlsd = new List<SaveData>();

            foreach (GameObject go in BagListController.bl)
            {
                MaterialDisplay materialDisplay = go.GetComponent<MaterialDisplay>();

                if (materialDisplay != null)
                {
                    SaveData sd = new SaveData();
                    sd.sSlotId = materialDisplay.mSlotId;
                    sd.sId = materialDisplay.mId;
                    sd.sName = materialDisplay.mName;
                    sd.sStar = materialDisplay.mStar;
                    sd.sAttribute = materialDisplay.mAttribute;

                    sld.mlsd.Add(sd);
                }
                else
                {
                    Debug.LogError("MaterialDisplay component not found on GameObject: " + go.name);
                }
            }

            sld.ilsd = new List<SaveData>();

            foreach (GameObject go in BagListController.il)
            {
                ItemDisplay itemDisplay = go.GetComponent<ItemDisplay>();

                if (itemDisplay != null)
                {
                    SaveData sd = new SaveData();
                    sd.sSlotId = itemDisplay.iSlotId;
                    sd.sId = itemDisplay.iId;
                    sd.sName = itemDisplay.iName;
                    sd.sStar = itemDisplay.iStar;
                    sd.sAttribute = itemDisplay.iAttribute;

                    sld.ilsd.Add(sd);
                }
                else
                {
                    Debug.LogError("MaterialDisplay component not found on GameObject: " + go.name);
                }
            }

            string json = JsonUtility.ToJson(sld, true);

            if (!Directory.Exists($"{userPath}\\{"PRD Team"}\\{"M2"}\\{"SaveData01"}"))
            {
                Directory.CreateDirectory($"{userPath}\\{"PRD Team"}\\{"M2"}\\{"SaveData01"}");
            }

            File.WriteAllText(userPath + "/PRD Team/M2/SaveData01/SaveD1.prd", json);

            Debug.Log("Saved!");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            string filePath = userPath + "/PRD Team/M2/SaveData01/SaveD1.prd";

            LoadGame = true;

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);

                // Deserialize the JSON into a SaveListData object
                FileSaveData loadedSld = JsonUtility.FromJson<FileSaveData>(json);

                // Now, you can access the loaded data as needed
                foreach (SaveData saveData in loadedSld.mlsd)
                {
                    Debug.Log("================================");
                    Debug.Log("Loaded Data:");
                    Debug.Log("SlotID: " + saveData.sSlotId);
                    Debug.Log("ID: " + saveData.sId);
                    Debug.Log("Name: " + saveData.sName);
                    Debug.Log("Star: " + saveData.sStar);
                    Debug.Log("Attribute: " + saveData.sAttribute);

                    // Instantiate the prefab
                    GameObject materialObject = Instantiate(prefab[saveData.sId], root);

                    // Get the MaterialDisplay component from the instantiated GameObject
                    MaterialDisplay materialDisplay = materialObject.GetComponent<MaterialDisplay>();

                    // Set the properties based on the loaded data
                    materialDisplay.mSlotId = saveData.sSlotId;
                    materialDisplay.mId = saveData.sId;
                    materialDisplay.mName = saveData.sName;
                    materialDisplay.mStar = saveData.sStar;
                    materialDisplay.mAttribute = saveData.sAttribute;

                    Debug.Log("================================");

                    BagListController.bl.Add(materialObject);
                }

                foreach (SaveData saveData in loadedSld.ilsd)
                {
                    Debug.Log("================================");
                    Debug.Log("Loaded Data:");
                    Debug.Log("SlotID: " + saveData.sSlotId);
                    Debug.Log("ID: " + saveData.sId);
                    Debug.Log("Name: " + saveData.sName);
                    Debug.Log("Star: " + saveData.sStar);
                    Debug.Log("Attribute: " + saveData.sAttribute);

                    // Instantiate the prefab
                    GameObject materialObject = Instantiate(prefabItem[saveData.sId], rootItem);

                    // Get the MaterialDisplay component from the instantiated GameObject
                    ItemDisplay materialDisplay = materialObject.GetComponent<ItemDisplay>();

                    // Set the properties based on the loaded data
                    materialDisplay.iSlotId = saveData.sSlotId;
                    materialDisplay.iId = saveData.sId;
                    materialDisplay.iName = saveData.sName;
                    materialDisplay.iStar = saveData.sStar;
                    materialDisplay.iAttribute = saveData.sAttribute;

                    Debug.Log("================================");

                    BagListController.il.Add(materialObject);
                }
            }
            else
            {
                Debug.LogError("File not found: " + filePath);
            }

            StartCoroutine(LoadDoneDelay());
            Debug.Log("Loaded!");
        }
    }

    public void DestroyObject(GameObject gameObject)
    {
        for (var i = gameObject.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
    }

    IEnumerator LoadDoneDelay()
    {
        yield return new WaitForSeconds(1f);
        LoadGame = false;
    }

    IEnumerator DelayLoadPushBack()
    {
        yield return new WaitForSeconds(1f);
        SynthesizeInterface.pushBackLoad = false;
        //ChangePlace = false;
    }
}
