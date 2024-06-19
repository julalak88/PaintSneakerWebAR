using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager instance = null;

    [SerializeField] private GameObject scanUI;
    [SerializeField] private GameObject cameraUI;
    [SerializeField] private List<Sprite> outlineList;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
     scanUI.transform.Find("ScanArea").GetComponent<Image>().sprite = FindOutlineImage(MarkerManager.instance.GetCurrentMarker().Split('.')[0]+"_Outline");
    }

    public GameObject GetUI(string interfaceName)
    {
        GameObject objectToReturn = null;

        switch (interfaceName)
        {
            case "scan":
                return objectToReturn = scanUI;

            case "camera":
                return objectToReturn = cameraUI;

            default:
                Debug.Log("UI not found");
                break;

        }

        return objectToReturn;
    }

    private Sprite FindOutlineImage(string name)
    {
        Sprite spriteToReturn = null;
        foreach(Sprite outlineImage in outlineList)
        {
            if (outlineImage.name.Equals(name))
            {
                spriteToReturn = outlineImage;
            }
        }

        return spriteToReturn;
    }

    public void BackToSelect()
    {
        SceneManager.LoadScene("Select");
    }
}
