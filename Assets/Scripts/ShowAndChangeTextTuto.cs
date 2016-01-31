using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowAndChangeTextTuto : MonoBehaviour {
	
	public string texte;
	
	public Text ui_text;
	
	void Awake(){
		ui_text.gameObject.SetActive(false);
	}
	
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.CompareTag ("Player")) {
			this.ui_text.text = texte;
			ui_text.gameObject.SetActive(true);
		}
	}
	
	void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.CompareTag ("Player")) {
			ui_text.gameObject.SetActive(false);
		}
	}
}
