using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class SkillsState {
	public static int playerLevel;
	private static Dictionary<string, int> requiredLevelForSkill;

	public static void setRequirements () {
		Debug.Log ("requirements intialized");
		requiredLevelForSkill = new Dictionary<string, int> ();
		/*
         * On prend par defaut un niveau 100. La variable sera update par l'instance de joueur. 
         */
		playerLevel = 100;
		requiredLevelForSkill.Add ("ultimate", 95);
		requiredLevelForSkill.Add ("widest", 70);
		requiredLevelForSkill.Add ("aroundest", 70);
		requiredLevelForSkill.Add ("wider", 50);
		requiredLevelForSkill.Add ("around", 50);
		requiredLevelForSkill.Add ("shield", 50);
		requiredLevelForSkill.Add ("fireball", 20);
		requiredLevelForSkill.Add ("sword", 10);
	}

	public static bool isAccessible(string skill) {
		return requiredLevelForSkill [skill] <= playerLevel;
	}
}