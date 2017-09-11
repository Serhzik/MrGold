using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

//-- This section only necessary for Asset Package integration --//
//
//#if UNITY_IOS
//private string gameId = "1486551";
//#elif UNITY_ANDROID
//private string gameId = "1486550";
//#endif

//--------------------------------------------------------------//

//ColorBlock newColorBlock = new ColorBlock();
//public Color green = new Color(0.1F, 0.8F, 0.1F, 1.0F);

[RequireComponent(typeof(Button))]
public class Ads : MonoBehaviour
{
	public Sprite Inactive, Active;
	public Control control;
	Button m_Button;
	Image image;

	public string placementId = "rewardedVideo";

	void Start ()
	{    
		m_Button = GetComponent<Button> ();
		image = GetComponent<Image> ();
		if (m_Button) m_Button.onClick.AddListener (ShowAd);

		//		if (Advertisement.isSupported) {
		//			Advertisement.Initialize (gameId, true);
		//		}

		//		//-- This section only necessary for Asset Package integration --//
		//
		//		if (Advertisement.isSupported) {
		//			Advertisement.Initialize (gameId, true);
		//		}
		//		//---------------------------------------------------------------//
	}

	void Update ()
	{
		if (Advertisement.IsReady (placementId))
			image.sprite = Active;
		else
			image.sprite = Inactive;
	}

	void ShowAd ()
	{
		var options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show(placementId, options);
	}

	void HandleShowResult (ShowResult result)
	{
		if(result == ShowResult.Finished) {
			Debug.Log("Video completed - Offer a reward to the player");
			control.IncreaseScore ();
		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");

		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
		}
	}
}
