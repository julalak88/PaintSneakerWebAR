using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediaControl : MonoBehaviour
{
    
    public GameObject footer,photoBtn,actionBtn,videoBtn, exitBtn0, backBtn0;
    [HideInInspector]
    public Button _photoBtn, _actionBtn, _videoBtn;
    public GameObject groupShare;
    public string currentAction;
    public string vdoStatus;
    public ZVidPromptTest ZVidPromptTest;
    public ZSNSTest zSNSTest;
    public ScreenShotter screenShotter;
    public Color colorrec;
    public RawImage image;
    public GameObject bgShare;
    void Awake()
    {
        _photoBtn = photoBtn.GetComponent<Button>();
        _actionBtn = actionBtn.GetComponent<Button>();
        _videoBtn = videoBtn.GetComponent<Button>();
        _videoBtn.interactable = false;
        image.gameObject.SetActive(false);
        bgShare.SetActive(false);
        groupShare.SetActive(false);
    }

    public void SelectAction(string ac) {
        currentAction = ac;
        if (currentAction.Equals("photo")) {
            _videoBtn.interactable = false;
        } else if (currentAction.Equals("vdo")) {
            _photoBtn.interactable = false;
        }
    }

    public void TakeAction() {
       
        if (!string.IsNullOrEmpty(currentAction)) {
            if (currentAction.Equals("photo")) {
                footer.SetActive(false);
                photoBtn.SetActive(false);
                actionBtn.SetActive(false);
                videoBtn.SetActive(false);
                exitBtn0.SetActive(false);
                backBtn0.SetActive(false);
                  screenShotter.callCaptureToTexture();
                //zSNSTest.TakeSnapshot();
            } else if (currentAction.Equals("vdo")) {
               
                if (vdoStatus.Equals("inRecord")) {
                    ZVidPromptTest.StopRecording();
                    _actionBtn.image.color = Color.white;
                    vdoStatus = string.Empty;
                } else {
                    footer.SetActive(false);
                    photoBtn.SetActive(false);
                    videoBtn.SetActive(false);
                    exitBtn0.SetActive(false);
                    backBtn0.SetActive(false);
                    _actionBtn.image.color = colorrec;
                    ZVidPromptTest.StartRecording();
                }
               
            }
        }
    }

    public void BackToMain() {
        image.texture = null;
        image.gameObject.SetActive(false);
        bgShare.SetActive(false);
        groupShare.SetActive(false);

        GetBack();
    }

    public void ScreenshortFinished() {
        groupShare.SetActive(true);
      

    }


   
    public void GetBack( ) {
        footer.SetActive(true);
        photoBtn.SetActive(true);
        actionBtn.SetActive(true);
        videoBtn.SetActive(true);
        exitBtn0.SetActive(false);
        backBtn0.SetActive(true);
        
        groupShare.SetActive(false);
        _videoBtn.interactable = true;
        _photoBtn.interactable = true;
        currentAction = string.Empty;


    }



}
