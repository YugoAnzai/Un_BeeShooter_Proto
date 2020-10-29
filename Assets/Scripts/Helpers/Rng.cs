using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  YugoA.Helpers
{

    public static class Rng
    {

        public static bool debug = false;

        private static void DebugRich(string funcName, string message)
        {

            if(!debug) return;

            message = "<color=blue>Rng</color> <color=green>" + funcName + "</color>: " + message;
            Debug.LogFormat(message);

        }

        public static bool Coin()
        {
            if (Random.value < 0.5f) return true;
            return false;
        }

        public static bool ChanceInHundred(int chance)
        {
            int rand = Random.Range(1, 101);

            DebugRich("ChanceInHundred", "chance: " + chance + "; rand: " + rand);

            if (rand < chance) return true;
            return false;
        }

        public static int ChancesInHundred(params int[] chances)
        {

            // if random int in the chances sum, return a choice index
            // if random int not in the chances sum, return -1 instead

            int sum = 0;
            int choice = -1;
            int rand = Random.Range(1, 101);

            for(int i = 0; i < chances.Length; i++) {
                sum += chances[i];
                if (choice < 0 && rand <= sum) {
                    choice = i;
                }
            }

            if (sum > 100) Debug.LogWarning("Chances bigger than 100%");

            DebugRich("ChancesInHundred", "options: " + chances.Length + "; rand: " + rand + "; choice: " + choice);

            return choice;

        }

        public static T ChooseInList<T>(List<T> list, int[] chances = null)
        {
            int choice = 0;
            if (chances == null) {
                choice = Random.Range(0, list.Count);
            } else {

                // Check sizes
                if (chances.Length != list.Count) {
                    throw new System.ArgumentException("List and Chances with different size");
                }
                // Check sum
                int sum = 0;
                foreach (int chance in chances) { sum += chance; }
                if (sum != 100) {
                    throw new System.ArgumentException("Chances sum bigger than 100");
                }

                choice = ChancesInHundred(chances);
            }

            return list[choice];
        }

    }

}