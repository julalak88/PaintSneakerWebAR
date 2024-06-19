using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UVScannerManager : MonoBehaviour
{
    public static UVScannerManager instance;
    public Button snapButton;
    private int referenceWidth, referenceHeight, frameStartPointX, frameStartPointY;

    Texture2D sneakerUV;
    Texture2D snapShot;
    Texture2D resizeTex;
    Rect areaToSnap;
    UIManager uiManager;
    ZapparIntegetion zapparIntegetion;
    Sneaker currentSneakerObject;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        uiManager = UIManager.instance;
        zapparIntegetion = ZapparIntegetion.instance;
        snapShot = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
        areaToSnap = new Rect(0, 0, Screen.width, Screen.height);
    }

    public void Snapshot()
    {
        currentSneakerObject = zapparIntegetion.GetCurrentModel().GetComponent<Sneaker>();
        sneakerUV = currentSneakerObject.GetUV();

        float ratio = (float)Screen.width / (float)Screen.height;
        if (ratio >= 0.74) currentSneakerObject.SetRatio(true);

        referenceWidth = currentSneakerObject.GetRefWidth();
        referenceHeight = currentSneakerObject.GetRefHeight();
        frameStartPointX = currentSneakerObject.GetStartPointX();
        frameStartPointY = currentSneakerObject.GetStartPointY();
        StartCoroutine(ScreenSnap(sneakerUV, snapShot));
    }

    private void GenerateUV(Texture2D sneakerUV, Texture2D snapShot)
    {
        StartCoroutine(ChangeUV(sneakerUV, snapShot));
    }

    IEnumerator ScreenSnap(Texture2D sneakerUV, Texture2D snapShot)
    {
        uiManager.GetUI("scan").SetActive(false);
        yield return new WaitForEndOfFrame();

        snapShot.ReadPixels(areaToSnap, 0, 0, false);
        snapShot.Apply();
        if (snapShot.width != referenceWidth && snapShot.height != referenceHeight)
        {
            Resize(snapShot, referenceWidth, referenceHeight);
            snapShot = resizeTex;
        }
        uiManager.GetUI("scan").SetActive(true);
        GenerateUV(sneakerUV, snapShot);
        yield break;

    }

    IEnumerator ChangeUV(Texture2D sneakerUV, Texture2D snapShot)
    {
        for (int i = 0; i < sneakerUV.width; i++)
        {
            for (int j = 0; j < sneakerUV.height; j++)
            {
                int snapX = i + frameStartPointX;
                int snapY = j + frameStartPointY;

                Color snapColor = snapShot.GetPixel(snapX, snapY);
                if (sneakerUV.GetPixel(i, j) != snapColor)
                {
                    sneakerUV.SetPixel(i, j, snapColor);
                }
            }
        }
        sneakerUV.Apply();
        zapparIntegetion.IsShowingModel(true);
        uiManager.GetUI("scan").SetActive(false);
        uiManager.GetUI("camera").SetActive(true);
        yield break;
    }

    private void Resize(Texture2D texture2D, int targetX, int targetY)
    {
        RenderTexture resizeTexture = new RenderTexture(targetX, targetY, 24);
        RenderTexture.active = resizeTexture;
        Graphics.Blit(texture2D, resizeTexture);
        resizeTex = new Texture2D(targetX, targetY);
        resizeTex.ReadPixels(new Rect(0, 0, targetX, targetY), 0, 0);
        resizeTex.Apply();
        Destroy(resizeTexture);
    }

    public void DisableSnapButton(bool isDisable)
    {
        snapButton.interactable = !isDisable;
    }

    private void OnDisable()
    {
        Destroy(snapShot);
        Destroy(resizeTex);
    }
}

