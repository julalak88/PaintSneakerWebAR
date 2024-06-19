using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarkerEventHandler : MonoBehaviour
{
    MarkerManager markerManager;
    // Start is called before the first frame update
    void Start()
    {
        markerManager = MarkerManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMarker(string markerName)
    {
        markerManager.SetMarker(markerName);
        SceneManager.LoadScene("Main");
    }
}
