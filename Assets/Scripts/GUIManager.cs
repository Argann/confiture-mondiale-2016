using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {
	private Text level;
	private Slider experience;

	private int niveau;
	private int xp;
	private int ratio = 1000;

	// Use this for initialization
	void Start () {
		level = GameObject.FindWithTag ("LevelText").GetComponent<Text> ();
		experience = GameObject.FindWithTag ("XPBar").GetComponent<Slider> ();
		niveau = int.Parse(level.text);
		xp = ratio;
	}
	
	// Update is called once per frame
	void Update () {
		experience.maxValue = ratio;
		/* 2 Commandes pour tester la XPBar, supprimer quand les tests ne seront plus necessaires
		if (Input.GetKey (KeyCode.UpArrow)) {
			AddXP (10);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			AddXP (-10);
		}
		//*/
		experience.value = xp;
		level.text = niveau.ToString();
	}

	public void AddXP(int xpRecue) {
		xp -= xpRecue;
		if (xp < 1) {
			if (niveau > 1) {
				xp = ratio;
				niveau--;
			} else {
				xp = 0;
			}
		}
		if (xp > ratio) {
			if (niveau < 10) {
				xp = 0;
				niveau++;
			} else {
				xp = ratio;
			}
		}
	}

	public void SetRatio(int xpMax) {
		ratio = xpMax;
	}
}
