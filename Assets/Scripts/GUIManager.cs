using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {
	private Text levelText;
	private Slider experience;

	private int level;
    public int Level
    {
        get { return level; }
        set
        {
            level = value;
            levelText.text = level.ToString();
        }
    }

	private int xp;
    public int XP
    {
        get { return xp; }
        set
        {
            xp = value;
            experience.value = xp;
        }
    }

    private int ratio = 1000;
    public int Ratio
    {
        get { return ratio; }
        set {
            ratio = value;
            experience.maxValue = ratio;
        }
    }

	// Use this for initialization
	void Start () {
		levelText = GameObject.FindWithTag ("LevelText").GetComponent<Text> ();
        print(levelText);
		experience = GameObject.FindWithTag ("XPBar").GetComponent<Slider> ();
		level = int.Parse(levelText.text);
		xp = ratio;
	}
	
	// Update is called once per frame
	void Update () {
		//experience.maxValue = ratio;
		/* 2 Commandes pour tester la XPBar, supprimer quand les tests ne seront plus necessaires
		if (Input.GetKey (KeyCode.UpArrow)) {
			AddXP (10);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			AddXP (-10);
		}
		//*/
		//experience.value = xp;
		//levelText.text = level.ToString();
	}
}
