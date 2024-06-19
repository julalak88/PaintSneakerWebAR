using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakerManager : MonoBehaviour
{
    public static SneakerManager instance;

    [SerializeField]List<GameObject> sneakerList;
    Dictionary<string, GameObject> sneakerDict;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        sneakerDict = new Dictionary<string, GameObject>();
        foreach (GameObject sneaker in sneakerList)
        {
            sneakerDict.Add(sneaker.GetComponent<Sneaker>().GetName(), sneaker);
        }
    }

    public Texture2D GetSneakerUV(string sneakerName)
    {
        return sneakerDict[sneakerName].GetComponent<Sneaker>().GetUV();
    }


    public GameObject GetSneaker(string sneakerName)
    {
        return sneakerDict[sneakerName];
    }

}
