using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //Vitesse du joueur
    public float speed;

    //Niveau du joueur
    private int level;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }

	//Attaque du joueur
	public int attackPower;


   
    //xpMax du niveau en cours (xpMin = 0)
    private float xpMax
    {
        get { return 10 * level; }
    }

    //XP actuel du personnage dans ce niveau
    private float xp;
    public float XP
    {
        get { return xp; }
        set { xp = value; }
    }


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //Déplacement du personnage
        Vector2 direction = Vector2.up * Input.GetAxisRaw("up") + Vector2.left * Input.GetAxisRaw("left")
                            + Vector2.down * Input.GetAxisRaw("down") + Vector2.right * Input.GetAxisRaw("right");
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, (Vector2)transform.position + direction, step);

        //Le sprite suit des yeux le curseur de la souris
        Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    //Permet d'affecter un nouveau niveau au joueur
    private void NewLevel(int level)
    {
        this.level = level;
        xp = xpMax;
    }

    //A déclencher quand le joueur est touché
    public void Touched(int damage)
    {
        xp += damage;
        if (xp >= xpMax)
        {
            NewLevel(level + 1);
        }
    }

    //A déclencher quand le joueur tue un/des ennemi(s)
    public void KillEnemies(float xpMonster, int count = 1)
    {
        xp -= count * xpMonster;
        if (xp <= 0)
        {
            NewLevel(level - 1);
        }
    }
}
