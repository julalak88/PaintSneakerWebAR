using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningUI : MonoBehaviour
{

    [SerializeField] private List<Button> sneakerButtonList;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Button sneakerBtn in sneakerButtonList)
        {
            sneakerBtn.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Confirm()
    {
        foreach(Button sneakerBtn in sneakerButtonList)
        {
            sneakerBtn.enabled = true;
        }
        this.gameObject.SetActive(false);
    }
}
