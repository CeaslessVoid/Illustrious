using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace Illustrious
{
    public class WeaponTiers
    {

        private WeaponTiers(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Name;
        }

        public static WeaponTiers GetTier(int weight)
        {
            if (weight < 1 || weight > 5)
                Log.Error("[Illustrious] Weight must be between 1 and 5 and not " + weight.ToString());

            Random random = new Random();
            int roll = random.Next(0, 100);

            if (roll < 5 * weight) return Epic;
            if (roll < 15 + 10 * weight) return Rare;
            if (roll < 40 + 15 * weight) return Uncommon;

            return Common;
        }



        public static readonly WeaponTiers Common = new WeaponTiers("Common", 0);

        public static readonly WeaponTiers Uncommon = new WeaponTiers("Uncommon", 1);

        public static readonly WeaponTiers Rare = new WeaponTiers("Rare", 2);

        public static readonly WeaponTiers Epic = new WeaponTiers("Epic", 3);

        public static readonly WeaponTiers Legendary = new WeaponTiers("Legendary", 4);

        public static readonly WeaponTiers Illustrious = new WeaponTiers("Illustrious", 5);

        public string Name { get; }
        public int Value { get; }


    }

}
