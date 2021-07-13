using _07_InfernoInfinity.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace _07_InfernoInfinity.Models
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int minDamage;
        private int maxDamage;
        private IGem[] gems;
        private int strength;
        private int agility;
        private int vitality;
        private Rarity rarity;

        protected Weapon(string name, int minDamage, int maxDamage, Rarity rarity, int gemSlots)
        {
            this.name = name;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.Rarity = rarity;
            this.gems = new IGem[gemSlots];
        }

        public virtual string Name => this.name;

        public virtual int MinDamage
        {
            get { return this.minDamage * (int)this.Rarity; }
            protected set { this.minDamage = value; }
        }

        public virtual int MaxDamage
        {
            get { return this.maxDamage * (int)this.Rarity; }
            protected set { this.maxDamage = value; }
        }

        public virtual Rarity Rarity
        {
            get { return this.rarity; }
            private set { this.rarity = value; }
        }

        public IReadOnlyCollection<IGem> Gems
        {
            get => this.gems.ToList().AsReadOnly();
            private set { this.gems = value.ToArray(); }
        }

        public virtual int ModifiedMinDamage => this.MinDamage + this.Strength * 2 + this.Agility * 1;

        public virtual int ModifiedMaxDamage => this.MaxDamage + this.Strength * 3 + this.Agility * 4;

        public virtual int Strength
        {
            get => this.strength;
            private set
            {
                if (value < 0)
                {
                    this.strength = 0;
                }
                else
                {
                    this.strength = value;
                }
            }
        }

        public virtual int Agility
        {
            get => this.agility;
            private set
            {
                if (value < 0)
                {
                    this.agility = 0;
                }
                else
                {
                    this.agility = value;
                }
            }
        }

        public virtual int Vitality
        {
            get => this.vitality;
            private set
            {
                if (value < 0)
                {
                    this.vitality = 0;
                }
                else
                {
                    this.vitality = value;
                }
            }
        }

        public virtual void AddSocked(IGem gem, int index)
        {
            if (index >= 0 && index < gems.Length)
            {
                if (this.gems[index] == null)
                {
                    this.gems[index] = gem;
                    this.Strength += gem.Strength;
                    this.Agility += gem.Agility;
                    this.Vitality += gem.Vitality;
                }
                else
                {
                    this.RemoveSocked(index);
                    this.gems[index] = gem;
                    this.Strength += gem.Strength;
                    this.Agility += gem.Agility;
                    this.Vitality += gem.Vitality;
                }
            }
        }

        public virtual void RemoveSocked(int index)
        {
            if (index >= 0 && index < gems.Length)
            {
                IGem gem = this.gems[index];
                this.gems[index] = null;
                this.Strength -= gem.Strength;
                this.Agility -= gem.Agility;
                this.Vitality -= gem.Vitality;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.ModifiedMinDamage}-{this.ModifiedMaxDamage} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
        }
    }
}
