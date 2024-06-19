using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerManager : MonoBehaviour
{
    public static MarkerManager instance;
    [SerializeField]private string currentMarker;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentMarker = "";
    }


    public void SetMarker(string markerName)
    {
        this.currentMarker = markerName;
    }

    public string GetCurrentMarker()
    {
        return this.currentMarker;
    }
}
