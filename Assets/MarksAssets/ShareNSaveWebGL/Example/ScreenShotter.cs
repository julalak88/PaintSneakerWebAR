using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using MarksAssets.ShareNSaveWebGL;
using status = MarksAssets.ShareNSaveWebGL.ShareNSaveWebGL.status;

public class ScreenShotter : MonoBehaviour {
	private Texture2D texture;
	private byte[] file;
	public MediaControl media;
	 
	public void callCaptureToTexture() {
		 
		
		StartCoroutine(captureToTexture());
	}
	
    private IEnumerator captureToTexture()
    {
        yield return new WaitForEndOfFrame();
        texture = ScreenCapture.CaptureScreenshotAsTexture();
		file = texture.EncodeToPNG();

		
		ShowTexture();
		media.ScreenshortFinished();
	}

	 void ShowTexture() {

		media.image.gameObject.SetActive(true);
		media.bgShare.SetActive(true);
		media.image.texture = texture;
		 
	}
	
	public void share() {
		Debug.Log(ShareNSaveWebGL.CanShare(file, "image/png"));
		ShareNSaveWebGL.Share(shareCallback, file, "image/png");

		//ShareNSaveWebGL.Share(shareCallback, "Module.ScreenshotWebGL.screenShotBlob");//share using my ScreenshotWebGL asset
		//ShareNSaveWebGL.Share(shareCallback, null, null, "MyURL", "MyTitle", "MyText");//share text only
	}
	
	public void save() {
		ShareNSaveWebGL.Save(file, "image/png","myimage");
		 
	}

	public void shareCallback(status stat) {
		StopCoroutine("captureToTexture");
		//ssGO.SetActive(true);
		//shareGO.SetActive(true);
		//saveGO.SetActive(true);
	}

	 
}