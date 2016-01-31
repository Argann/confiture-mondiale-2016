using UnityEngine;
using System.Collections;
//using System.Collections.;

public class JoueurManager : MonoBehaviour {
	
    public int idAttack = 0;

	void Start(){
		idAttack = 0;
	}


	// Update is called once per frame
	void Update () {
		print (GameObject.FindGameObjectsWithTag ("Attack"));
        if (Input.GetKeyDown(KeyCode.Alpha1)) idAttack = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) idAttack = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) idAttack = 2;
		if (Input.GetKeyDown(KeyCode.Alpha4)) idAttack = 3;

      /*  if (previousIdAttack != idAttack){
			if(GameObject.FindGameObjectsWithTag("Attack")[previousIdAttack].GetComponent<AttackEnemy>() != null)
				GameObject.FindGameObjectsWithTag("Attack")[previousIdAttack].GetComponent<AttackEnemy>().active =false;
			else
				GameObject.FindGameObjectsWithTag("Attack")[previousIdAttack].GetComponent<AttackManager>().active =false;
		
			if(GameObject.FindGameObjectsWithTag("Attack")[idAttack].GetComponent<AttackEnemy>() != null)
				GameObject.FindGameObjectsWithTag("Attack")[idAttack].GetComponent<AttackEnemy>().active =true;
			else
				GameObject.FindGameObjectsWithTag("Attack")[idAttack].GetComponent<AttackManager>().active =true;
        }*/
	}
}
