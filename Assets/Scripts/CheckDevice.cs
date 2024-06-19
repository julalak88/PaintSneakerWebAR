using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDevice : MonoBehaviour
{

    
    string platformName;
    [SerializeField] private GameObject warningUI;

#if !UNITY_EDITOR && UNITY_WEBGL
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern bool IsIOSBrowser();
     [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern bool IsAndroidBrowser();
#endif

    private void Start() {
        warningUI.SetActive(false);
        CheckIfMobile();
    }
    private void CheckIfMobile() {
        var isIOSBrowser = false;
        var isAndroidBrowser = false;

#if !UNITY_EDITOR && UNITY_WEBGL
        isIOSBrowser = IsIOSBrowser();
        isAndroidBrowser = IsAndroidBrowser();
#endif

        if (isIOSBrowser) {
             platformName = "ios";
        } else if (isAndroidBrowser) {
           platformName = "Android";
            warningUI.SetActive(true);
        } else {
            platformName = "Other";
        }
    }

    public string GetPlatform() {
        return platformName;
    }
}
