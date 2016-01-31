using UnityEngine;
using System.Collections;
//using System.Collections.;

public class JoueurManager : MonoBehaviour {

    public GameObject[] listeAttack;
    private GameObject myAttack ;
    public int idAttack = 0;
    private int previousIdAttack;
    // Use this for initialization
    void Start () {
        //donne le premier
        myAttack = Instantiate(listeAttack[idAttack]) as GameObject;
        myAttack.transform.parent = gameObject.transform;
    }
	
	// Update is called once per frame
	void Update () {
        previousIdAttack = idAttack;
        if (Input.GetKeyDown(KeyCode.Alpha1)) idAttack = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) idAttack = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) idAttack = 2;

        if (previousIdAttack != idAttack){
            Vector3 pos = myAttack.transform.position;
            Destroy(myAttack);
            myAttack = Instantiate(listeAttack[idAttack], pos, Quaternion.identity) as GameObject;
            myAttack.transform.parent = gameObject.transform;
        }
	}
}
