using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace NewScripts
{
    public class GUIManager : MonoBehaviour
    {

        public Text levelText;
        public Slider experience;
        private PlayerManager player;

        private int lastLevel;

        // Use this for initialization
        void Start()
        {
            player = GameObject.Find("Player").GetComponent<PlayerManager>();
            lastLevel = player.level;
            SkillsState.setRequirements();
            Button[] bs = this.GetComponentsInChildren<Button>();
            string[] atks = new string[] { "wider", "fireball", "around", "shield" };
            for (int i = 0; i < 4; i++)
            {
                bs[i].enabled = SkillsState.isAccessible(atks[i], player.level);
                if (!bs[i].enabled)
                {
                    bs[i].image.color = new Color(0.1f, 0.1f, 0.1f, 0.5f);
                }
            }
            bs[4].image.color = Color.black;
        }

        // Update is called once per frame
        void Update()
        {
            levelText.text = player.level.ToString();
            experience.maxValue = 10 * player.level;
            experience.value = player.curLevelxp;

            //Gestion des boutons
            if (lastLevel != player.level)
            {
                Button[] bs = this.GetComponentsInChildren<Button>();
                string[] atks = new string[] { "wider", "fireball", "around", "shield" };
                for (int i = 0; i < 4; i++)
                {
                    bs[i].enabled = SkillsState.isAccessible(atks[i], player.level);
                    if (!bs[i].enabled)
                    {
                        bs[i].image.color = new Color(0.1f, 0.1f, 0.1f, 0.5f);
                    }
                    else
                    {
                        bs[i].image.color = Color.white;
                    }
                }
                bs[4].image.color = new Color(0.1f, 0.1f, 0.1f, 0.5f);
            }
            lastLevel = player.level;
        }

        void FixedUpdate()
        {
            Camera.main.gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10.0f);
        }

        public void OnClickSkill(Object button)
        {
            switch (button.name)
            {
                case "b_1":
                    InputBroker.SetKeyDown(KeyCode.Alpha1);
                    break;
                case "b_2":
                    InputBroker.SetKeyDown(KeyCode.Alpha2);
                    break;
                case "b_3":
                    InputBroker.SetKeyDown(KeyCode.Alpha3);
                    break;
                case "b_4":
                    InputBroker.SetKeyDown(KeyCode.Alpha4);
                    break;
                case "b_5":
                    InputBroker.SetKeyDown(KeyCode.Alpha5);
                    break;
                default:
                    break;
            }
        }
    }
}