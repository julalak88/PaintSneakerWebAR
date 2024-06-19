using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingEventHandler : MonoBehaviour
{
    ZapparIntegetion zapparIntegetion;
    GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        zapparIntegetion = ZapparIntegetion.instance;
        model = zapparIntegetion.GetCurrentModel().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void HideModel(bool isHide)
    {
        if (zapparIntegetion.IsShowingModel())
        {

                model.SetActive(!isHide);
        }
    }

}

