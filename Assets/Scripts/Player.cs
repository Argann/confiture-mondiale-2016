using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	//Vitesse du joueur
	public float speed;
	
	//Niveau du joueur
	public int level;

	public int shield = 0;
	public Animator legs_animator;
	
	public Animator arms_animator;

	public GameObject healthbar = null;
	public bool useHealth = false;
	public int maxHealth = 0;
	private int health = 0;
	
	public int attackPower;
   
    //xpMax du niveau en cours (xpMin = 0)
    private int xpMax
    {
        get { return 10 * level; }
    }

    //XP actuel du personnage dans ce niveau
    public int xp;

    //Gestionnaire de l'affichage des infos sur le joueur
    public GUIManager guiManager;
	
    void Start()
    {
		if (useHealth) {
			health = maxHealth;
		}
        guiManager = GameObject.Find("GUI").GetComponent<GUIManager>();
        guiManager.Level = level;
        guiManager.Ratio = xpMax;
        guiManager.XP = xp;
		SkillsState.playerLevel = level;

    }


    //Permet d'affecter un nouveau niveau au joueur
    private void NewLevel(int level, bool levelup)
    {
        this.level = level;
        xp = (levelup ? 0 : xpMax);
        guiManager.XP = xp;
        guiManager.Ratio = xpMax;
        guiManager.Level = level; 
		SkillsState.playerLevel = level;
    }

    //A déclencher quand le joueur est touché
    public void Touched(int damage)
    {
		if (useHealth) {
			health -= damage;
			healthbar.transform.localScale = new Vector3((float)health / maxHealth, 1);
		}
		damage -= shield;
        if (this.level < 100 && damage > 0)
        {
            xp += damage;
            guiManager.XP = xp;
            if (xp >= xpMax)
            {
                NewLevel(level + 1, true);
            }
        }
    }

    //A déclencher quand le joueur tue un/des ennemi(s)
    public void KillEnemies(int xpMonster, int count = 1)
    {
        if (this.level < 100)
        {
            xp -= count * xpMonster;
            guiManager.XP = xp;
            if (xp <= 0)
            {
                NewLevel(level - 1, false);
            }
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (this.guiManager == null) {
			guiManager = GameObject.Find("XPBar").GetComponent<GUIManager>();
			guiManager.Level = level;
			guiManager.Ratio = xpMax;
			guiManager.XP = xp;
		}

		//Déplacement du personnage
		Vector2 direction = Vector2.up * Input.GetAxisRaw("up") + Vector2.left * Input.GetAxisRaw("left")
			+ Vector2.down * Input.GetAxisRaw("down") + Vector2.right * Input.GetAxisRaw("right");
		float step = speed * Time.deltaTime;

		this.legs_animator.SetBool ("isWalking", !(direction == Vector2.zero));

		transform.position = Vector3.MoveTowards(transform.position, (Vector2)transform.position + direction, step);
		
		//Le sprite suit des yeux le curseur de la souris
		Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if (this.healthbar != null) {
			this.healthbar.transform.position = new Vector3(transform.position.x, transform.position.y + 0.7f);
		}

		if (this.health <= 0 && this.useHealth) {
			Destroy (this.gameObject);
		}
	}


}
