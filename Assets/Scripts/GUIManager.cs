using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {
	public Text level;
	public Image experience;
	private int niveau;
	private int xp;
	private float maxWidth;
	private const int ratio = 100;

	// Use this for initialization
	void Start () {
		niveau = int.Parse(level.text);
		maxWidth = experience.rectTransform.sizeDelta.x;
		xp = ratio;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			if (niveau > 1) {
				xp--;
				if (xp == 0) {
					xp = ratio;
					niveau--;
				}
			} else {
				xp = 0;
			}
		}
		if (niveau > 1) {
			experience.rectTransform.sizeDelta = new Vector2 (maxWidth * xp / ratio, experience.rectTransform.sizeDelta.y);
		} else {
			experience.rectTransform.sizeDelta = new Vector2 (0, experience.rectTransform.sizeDelta.y);
		}
		level.text = niveau.ToString();
	}
}
