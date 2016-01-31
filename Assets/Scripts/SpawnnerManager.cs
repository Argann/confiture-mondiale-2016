using UnityEngine;
using System.Collections;

public class SpawnnerManager : MonoBehaviour {

    public GameObject prefabEnemy;
    public float countdown = 3f;
    public int stackEnnemy = 3;

    private float countdownt ;

    void Start()
    {
        countdownt = countdown;
    }

	// Update is called once per frame
	void Update () {
        countdownt -= Time.deltaTime;
        if(countdownt <= 0.0f && stackEnnemy > 0)
        {
            stackEnnemy--;
            countdownt = countdown ;
            Instantiate(prefabEnemy,gameObject.transform.position ,Quaternion.identity);
        }

    }
}
