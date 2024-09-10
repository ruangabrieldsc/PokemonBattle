using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle
{
    public class Pokemon : ICloneable
    {
        public string Name {  get; set; }

        pokeType pkType;
        pokeType secpkType;
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int backupAttack { get; set; }
        public int Defense { get; set; }
        public int backupDefense { get; set; }
        public int SpAttack { get; set; }
        public int backupSpAttack { get; set; }
        public int SpDefense { get; set; }
        public int Speed { get; set; }
        public int backupSpeed { get; set; }

        public int Level { get; set; }
        public Move move1 { get; set; }
        public Move move2 { get; set; }
        public Move move3 { get; set; }
        public Move move4 { get; set; }

        Ability Ability;

        public int hpCopy { get; set; }

        public Pokemon(string name, int Hp, int Attack, int Defense, int SpAttack, int SpDefense, int Speed
            , Move One, Move Two, Move Three, Move Four, Ability Ab, pokeType pkType, pokeType SecpkType) {

            this.Name = name;
            this.Hp = Hp;
            this.Attack = Attack;
            this.Defense = Defense;
            this.SpAttack = SpAttack;
            this.SpDefense = SpDefense;
            this.Speed = Speed;
            this.move1 = One;
            this.move2 = Two;
            this.move3 = Three;
            this.move4 = Four;
            this.Ability = Ab;
            this.hpCopy = Hp;
            this.pkType = pkType;
            this.secpkType = SecpkType;
            this.backupAttack = Attack;
            this.backupDefense = Defense;
            this.backupSpAttack = SpAttack;
            this.backupSpeed = Speed;
        }

        public int attack(Pokemon x, Pokemon y, Move z) {
            int pkHPcopy = x.hpCopy;
            int pkHP = x.Hp;
            int pkType = x.pkType.Cod;
            int pkType2 = x.secpkType.Cod;
            int pkAbility = x.Ability.abCod;
            int moveType = z.pkType.Cod;
            int pk2Type = y.pkType.Cod;
            int pk2Type2 = y.secpkType.Cod;

            double Variables = 1;

            Console.WriteLine("\n" + x.Name + " used " + z.Name + "!");

            if(z.PP == 0)
            {
                Console.WriteLine("You have no PP left in this move!");
                Console.WriteLine(x.Name + " used struggle!");
                return 1;
            }

            if (z.Acc < 100)
            {
                Random rnd = new Random();
                int check = rnd.Next(101);
                if (check > z.Acc)
                {
                    Console.WriteLine(x.Name + "'s attack missed!");
                    return 0;
                }
            }

            if (z.Name == "Growth")
            {
                Console.WriteLine(x.Name + "'s attack and special attack rose!");
                x.Attack += x.backupAttack / 2;
                x.SpAttack += x.backupSpAttack / 2;
                z.PP -= 1;
                return 0;
            }

            if (z.Name == "Withdraw")
            {
                Console.WriteLine(x.Name + "'s defense rose!");
                x.Defense += x.backupDefense / 2;
                z.PP -= 1;
                return 0;
            }

            if (z.Name == "Scary Face")
            {
                Console.WriteLine(y.Name + "'s speed decreased!");
                y.Speed /= 2;
                z.PP -= 1;
                return 0;
            }

            if (z.Name == "Life Dew")
            {
                Console.WriteLine(x.Name + "'s HP was restored by 3 points");
                x.Hp += 3;
                z.PP -= 1;
                return 0;
            }

            if (moveType == 2 & pk2Type == 6 | moveType == 6 & pk2Type == 2)
            {
                Console.WriteLine(y.Name + " it's immune to this move");
                return 0;
            }

            if (moveType == 6 & pk2Type == 6)
            {
                Variables *= 2;
            }

            double nmb = Effectiveness(y, z);

            Variables *= nmb;



            if (Variables >= 2)
            {
                Console.WriteLine("It's super effective!");
            } else if (Variables < 1)
            {
                Console.WriteLine("It's not very effective...");
            }

            if (moveType == 1 && pkAbility == 1 && pkHP < pkHPcopy/2 || moveType == 3 && pkAbility == 2 && pkHP < pkHPcopy / 2
            || moveType == 4 && pkAbility == 3 && pkHP < pkHPcopy / 2)
            {
                Variables += 0.3;
            }

            if (moveType == pkType || moveType == pkType2)
            {
                Variables += 0.5;
            }

            if (z.critChance)
            {
                Random rnd = new Random();
                int check = rnd.Next(1, 101);
                if (check <= 12)
                {
                    Console.WriteLine("It's a critical hit!");
                    Variables += 0.5;
                }
            }
            else
            {
                Random rnd = new Random();
                int check = rnd.Next(1, 101);
                if (check <= 4)
                {
                    Console.WriteLine("It's a critical hit!");
                    Variables += 0.5;
                }
            }

            z.PP -= 1;

            if (z.phyEsp)
            {
                double damageBeta = (((((2 * x.Level / 5) + 2) * z.BP * x.Attack / y.Defense) / 50) + 2) * Variables;
                int damage = (int)damageBeta;
                Console.WriteLine(y.Name + " took " + damage + " damage!");
                return damage;
            }
            else
            {
                double damageBeta = (((((2 * x.Level / 5) + 2) * z.BP * x.SpAttack / y.SpDefense) / 50) + 2) * Variables;
                int damage = (int)damageBeta;
                Console.WriteLine(y.Name + " took " + damage + " damage!");
                return damage;
            }
    
        }

        public void potion(Pokemon x) {
            if (x.Hp == x.hpCopy)
            {
                Console.WriteLine("Your HP is full!");
            } else if (x.Hp < x.hpCopy - 20)
            {
                Console.WriteLine("\n" + x.Name + " used a potion! \n");
                x.Hp += 20;
            }
            else
            {
                Console.WriteLine("\n" + x.Name + " used a potion! \n");
                x.Hp = x.hpCopy;
            }
        }

        public int determineMove(Pokemon x, Pokemon y)
        {
            int pk2Type = y.pkType.Cod;
            int pk2Type2 = y.secpkType.Cod;
            int move1 = 25;
            int move2 = 50;
            int move3 = 75;
            int move4 = 100;

            if (Effectiveness(y, x.move1) >= 2)
            {
                move1 = 50;
                move2 = 67;
                move3 = 84;
                move4 = 100;
                if (Effectiveness(y, x.move2) < 1)
                {
                    move3 = 70;
                    move4 = 90;
                    move2 = 100;
                }
                else if (Effectiveness(y, x.move3) < 1)
                {
                    move2 = 70;
                    move4 = 90;
                    move3 = 100;
                }
                else if (Effectiveness(y, x.move4) < 1)
                {
                    move2 = 70;
                    move3 = 90;
                    move4 = 100;
                }

            } else if (Effectiveness(y, x.move2) >= 2)
                {
                move2 = 50;
                move1 = 67;
                move3 = 84;
                move4 = 100;
                if (Effectiveness(y, x.move1) < 1)
                {
                    move3 = 70;
                    move4 = 90;
                    move1 = 100;
                }
                else if (Effectiveness(y, x.move3) < 1)
                {
                    move1 = 70;
                    move4 = 90;
                    move3 = 100;
                }
                else if (Effectiveness(y, x.move4) < 1)
                {
                    move1 = 70;
                    move3 = 90;
                    move4 = 100;
                }

            }
            else if (Effectiveness(y, x.move3) >= 2)
            {
                move3 = 50;
                move1 = 67;
                move2 = 84;
                move4 = 100;
                if (Effectiveness(y, x.move1) < 1)
                {
                    move2 = 70;
                    move4 = 90;
                    move1 = 100;
                }
                else if (Effectiveness(y, x.move2) < 1)
                {
                    move1 = 70;
                    move4 = 90;
                    move2 = 100;
                }
                else if (Effectiveness(y, x.move4) < 1)
                {
                    move1 = 70;
                    move2 = 90;
                    move4 = 100;
                }

            }
            else if (Effectiveness(y, x.move4) >= 2)
            {
                move4 = 50;
                move1 = 67;
                move3 = 84;
                move2 = 100;
                if (Effectiveness(y, x.move1) < 1)
                {
                    move3 = 70;
                    move2 = 90;
                    move1 = 100;
                }
                else if (Effectiveness(y, x.move3) < 1)
                {
                    move1 = 70;
                    move2 = 90;
                    move3 = 100;
                }
                else if (Effectiveness(y, x.move2) < 1)
                {
                    move1 = 70;
                    move3 = 90;
                    move2 = 100;
                }

            }

            Random rnd = new Random();
            int check = rnd.Next(1, 101);

            if (check <= move1)
            {
                int a = x.attack(x, y, x.move1);
                return a;
            } else if (check <= move2)
            {
                int a = x.attack(x, y, x.move2);
                return a;
            } else if (check <= move3)
            {
                int a = x.attack(x, y, x.move3);
                return a;
            } else
            {
                int a = x.attack(x, y, x.move4);
                return a;
            }


        }

        public double Effectiveness(Pokemon x, Move z)
        {
            int moveType = z.pkType.Cod;
            int pk2Type = x.pkType.Cod;
            int pk2Type2 = x.secpkType.Cod;

            double nmb = 1;

            if (moveType == 2 && pk2Type == 2)
            {
                nmb *= 2;
            }

            if (moveType == 1 && pk2Type == 4 || moveType == 3 && pk2Type == 1
                || moveType == 4 && pk2Type == 3 || moveType == 5 && pk2Type == 1)
            {
                nmb *= 2;
            }
            else if (moveType == 1 && pk2Type == 3 || moveType == 3 && pk2Type == 4
                || moveType == 4 && pk2Type == 1 || moveType == pk2Type || moveType == 5 && pk2Type == 6)
            {
                nmb /= 2;
            }
            if (moveType == 1 && pk2Type2 == 4 || moveType == 3 && pk2Type2 == 1
            || moveType == 4 && pk2Type2 == 3 || moveType == 5 && pk2Type2 == 1)
            {
                nmb *= 2;
            }
            else if (moveType == 1 && pk2Type2 == 3 || moveType == 3 && pk2Type2 == 4
            || moveType == 4 && pk2Type2 == 1 || moveType == pk2Type2 || moveType == 5 && pk2Type2 == 6)
            {
                nmb /= 2;
            }

            return nmb;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
