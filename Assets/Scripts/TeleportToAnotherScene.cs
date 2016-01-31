using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeleportToAnotherScene : MonoBehaviour
{
	public Image FadeImg;
	public float fadeSpeed = 5f;
	public string level;
	private bool sceneStarting = true;
	private bool sceneEnding = false;
	public bool destroyPlayer = false;


	void Awake()
	{
		FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
	}

	void FixedUpdate()
	{
		// If the scene is starting...
		if (sceneStarting)
			// ... call the StartScene function.
			StartScene();

		if (sceneEnding)
			EndScene ();
	}


	void FadeToClear()
	{
		// Lerp the colour of the image between itself and transparent.
		FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
	}


	void FadeToBlack()
	{
		// Lerp the colour of the image between itself and black.
		FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
	}


	void StartScene()
	{
		// Fade the texture to clear.
		FadeToClear();

		// If the texture is almost clear...
		if (FadeImg.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the RawImage.
			FadeImg.color = Color.clear;
			FadeImg.enabled = false;

			// The scene is no longer starting.
			sceneStarting = false;
		}
	}


	public void EndScene()
	{


		// Start fading towards black.
		FadeToBlack();

		// If the screen is almost black...
		if (FadeImg.color.a >= 0.95f) {
			// ... reload the level
			GameObject go = GameObject.FindGameObjectWithTag ("PlayerPrefab");
			if (!destroyPlayer) {
				DontDestroyOnLoad (go);
			} else {
				Destroy (go);
			}
			SceneManager.LoadScene (level, LoadSceneMode.Single);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.CompareTag("Player")){
			sceneEnding = true;
			FadeImg.enabled = true;
		}

	}
}