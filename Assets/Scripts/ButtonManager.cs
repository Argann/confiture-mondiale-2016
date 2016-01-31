using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    public Player player;
    private int lastLevel;
    


    void Update()
    {
        if (lastLevel != player.level)
        {
            Button[] bs = this.GetComponentsInChildren<Button>();
            string[] atks = new string[] { "wider", "fireball", "around", "shield"};
            for (int i = 0; i < 4; i++)
            {
                bs[i].enabled = SkillsState.isAccessible(atks[i]);
                if (!bs[i].enabled)
                {
                    bs[i].image.color = Color.gray;
                }
            }
        }
        lastLevel = player.level;
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
        //TODO
    }
}
