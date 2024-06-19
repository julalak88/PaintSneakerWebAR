using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zappar;

public class ZapparIntegetion : MonoBehaviour
{
    public static ZapparIntegetion instance;
    MarkerManager markerManager;
    [SerializeField]ZapparImageTrackingTarget imageTracker;
    bool isShowingModel = false;
    GameObject currentModel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        markerManager = MarkerManager.instance;
        imageTracker.Target = markerManager.GetCurrentMarker();
        string sneakerModelName = imageTracker.Target.Split('.')[0];
        currentModel = SneakerManager.instance.GetSneaker(sneakerModelName);
    }

    public bool IsShowingModel()
    {
        return isShowingModel;
    }

    public void IsShowingModel(bool boolean)
    {
        isShowingModel = boolean;
    }

    public GameObject GetCurrentModel()
    {
        return currentModel; 
    }

}

