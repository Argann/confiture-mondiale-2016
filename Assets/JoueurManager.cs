using UnityEngine;
using System.Collections;
//using System.Collections.;

public class JoueurManager : MonoBehaviour {
	
    public int idAttack = 0;

	void Start(){
		idAttack = 0;
		SkillsState.setRequirements ();
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			if (SkillsState.isAccessible("wider"))
				idAttack = 0;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			if (SkillsState.isAccessible("fireball"))
				idAttack = 1;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			if (SkillsState.isAccessible ("around"))
				idAttack = 2;
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			if (SkillsState.isAccessible ("shield"))
				idAttack = 3;
		}
	}
}
