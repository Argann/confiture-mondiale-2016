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
		if (InputBroker.GetKeyDown (KeyCode.Alpha1)) {
			if (SkillsState.isAccessible("sword"))
				idAttack = 0;
            InputBroker.UnsetKeyDown(KeyCode.Alpha1);
		}
		if (InputBroker.GetKeyDown (KeyCode.Alpha2)) {
			if (SkillsState.isAccessible("fireball"))
				idAttack = 1;
            InputBroker.UnsetKeyDown(KeyCode.Alpha2);
        }
        if (InputBroker.GetKeyDown (KeyCode.Alpha3)) {
			if (SkillsState.isAccessible ("around"))
				idAttack = 2;
            InputBroker.UnsetKeyDown(KeyCode.Alpha3);
        }
        if (InputBroker.GetKeyDown (KeyCode.Alpha4)) {
			if (SkillsState.isAccessible ("shield"))
				idAttack = 3;
            InputBroker.UnsetKeyDown(KeyCode.Alpha4);
        }
    }
}
