using UnityEngine;
using System.Collections.Generic;

namespace NewScripts
{
    public static class SkillsState
    {
        private static Dictionary<string, int> requiredLevelForSkill;

        public static void setRequirements()
        {
            requiredLevelForSkill = new Dictionary<string, int>();
            /*
             * On prend par defaut un niveau 100. La variable sera update par l'instance de joueur. 
             */
            //requiredLevelForSkill.Add("ultimate", 95);
            //requiredLevelForSkill.Add("widest", 70);
            //requiredLevelForSkill.Add("aroundest", 70);
            //requiredLevelForSkill.Add("wider", 0);
            //requiredLevelForSkill.Add("around", 50);
            //requiredLevelForSkill.Add("shield", 50);
            //requiredLevelForSkill.Add("fireball", 20);
            //requiredLevelForSkill.Add("sword", 10);
            if (requiredLevelForSkill.Count < 1)
            {
                requiredLevelForSkill.Add("shield", 20);
                requiredLevelForSkill.Add("around", 70);
                requiredLevelForSkill.Add("wider", 40);
                requiredLevelForSkill.Add("fireball", 10);
            }
        }

        public static bool isAccessible(string skill, int playerLevel)
        {
            return requiredLevelForSkill[skill] <= playerLevel;
        }
    }
}