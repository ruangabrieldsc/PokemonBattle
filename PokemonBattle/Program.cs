using PokemonBattle;
using System.Xml.Serialization;

pokeType Grass = new pokeType ("Grass", 1);
pokeType Normal = new pokeType("Normal", 2);
pokeType Fire = new pokeType("Fire", 3);
pokeType Water = new pokeType("Water", 4);
pokeType Poison = new pokeType("Poison", 5);
pokeType Ghost = new pokeType("Ghost", 6);
pokeType None = new pokeType("None", 99);

Move Tackle = new Move("Tackle", 40, 35, 100, Normal, false, true);
Move RazorLeaf = new Move("Razor Leaf", 55, 25, 95, Grass, true, true);
Move Venoshock = new Move("Venoshock", 65, 10, 100, Poison, false, false);
Move Growth = new Move("Growth", 0, 20, 100, Normal, false, true);
Move Scratch = new Move("Scratch", 40, 35, 100, Normal, false, true);
Move Ember = new Move("Ember", 40, 25, 100, Fire, false, false);
Move Inferno = new Move("Inferno", 100, 5, 65, Fire, false, false);
Move ScaryFace = new Move("Scary Face", 0, 10, 100, Normal, false, true);
Move Withdraw = new Move("Withdraw", 0, 40, 100, Water, false, true);
Move LifeDew = new Move("Life Dew", 0, 35, 100, Water, false, true);
Move WaterPulse = new Move("Water Pulse", 60, 20, 100, Water, false, false);
Move ShadowBall = new Move("Shadow Ball", 80, 15, 100, Ghost, false, false);
Move TakeDown = new Move("Take Down", 90, 20, 85, Normal, false, true);
Move FlameWheel = new Move("Flame Wheel", 60, 25, 100, Fire, false, true);
Move Lick = new Move("Lick", 30, 30, 100, Ghost, false, true);
Move ClearSmog = new Move("Clear Smog", 50, 15, 100, Poison, false, false);
Move Facade = new Move("Facade", 70, 20, 100, Normal, false, true);

Ability Overgrow = new Ability("Overgrow", 1, "Powers up grass moves when the hp is below half");
Ability Blaze = new Ability("Blaze", 2, "Powers up fire moves when the hp is below half");
Ability Torrent = new Ability("Torrent", 3, "Powers up water moves when the hp is below half");
Ability RunAway = new Ability("Run Away", 4, "Does nothing");
Ability Levitate = new Ability("Overgrow", 5, "Does nothing");


Pokemon Bulbasaur = new Pokemon("Bulbasaur", 32, 17, 17, 21, 21, 17,
RazorLeaf, Tackle, Growth, Venoshock, Overgrow, Grass, Poison);

Pokemon Charmander = new Pokemon("Charmander", 30, 18, 16, 20, 18, 21, 
Scratch, Ember, Inferno, ScaryFace, Blaze, Fire, None);

Pokemon Squirtle = new Pokemon("Squirtle", 31, 17, 21, 18, 20, 16, 
Withdraw, LifeDew, WaterPulse, Tackle, Torrent, Water, None);

Pokemon Rattata = new Pokemon("Rattata", 29, 19, 15, 13, 15, 22,
ShadowBall, TakeDown, FlameWheel, Scratch, RunAway, Normal, None);

Pokemon Gastly = new Pokemon("Gastly", 29, 15, 14, 28, 15, 24,
Lick, ClearSmog, Facade, ScaryFace, Levitate, Ghost, Poison);




string number = "";

while (true)
{
    Console.WriteLine("");
    Console.WriteLine("What Pokemon you wanna use?");
    Console.WriteLine("Bulbasaur - 1      Charmander - 2");
    Console.WriteLine("Squirtle - 3      Rattata - 4");
    Console.WriteLine("Gastly - 5");
    Console.WriteLine("");


    string choice = Console.ReadLine();

    if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5")
    {
        number = choice;
        break;
    } else
    {
        Console.WriteLine("You typed an invalid number");
        Console.WriteLine("");
    }
}

Pokemon x = null;

if (number == "1")
{
    x = Bulbasaur;
}else if (number == "2")
{
    x = Charmander;
}else if (number == "3")
{
    x = Squirtle;
}else if (number == "4")
{
    x = Rattata;
}else if (number == "5")
{
    x = Gastly;
}

while (true)
{
    Console.WriteLine("");
    Console.WriteLine("What Pokemon your opponent will use?");
    Console.WriteLine("Bulbasaur - 1      Charmander - 2");
    Console.WriteLine("Squirtle - 3       Rattata - 4");
    Console.WriteLine("Gastly - 5         Random - 6");
    Console.WriteLine("");


    string choice = Console.ReadLine();

    if (choice == "6")
    {
        Random random = new Random();
        int c = random.Next(1, 6);
        string b = c.ToString();
        choice = b;
    }

    if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5")
    {
        number = choice;
        break;
    }
    else
    {
        Console.WriteLine("You typed an invalid number");
        Console.WriteLine("");
    }
}

Pokemon y = null;


if (number == "1")
{
    y = new Pokemon("Bulbasaur", 32, 17, 17, 21, 21, 17,
    RazorLeaf, Tackle, Growth, Venoshock, Overgrow, Grass, Poison);
}
else if (number == "2")
{
    y = new Pokemon("Charmander", 30, 18, 16, 20, 18, 21,
    Scratch, Ember, Inferno, ScaryFace, Blaze, Fire, None);
}
else if (number == "3")
{
    y = new Pokemon("Squirtle", 31, 17, 21, 18, 20, 16,
    Withdraw, LifeDew, WaterPulse, Tackle, Torrent, Water, None);
}
else if (number == "4")
{
    y = new Pokemon("Rattata", 29, 19, 15, 13, 15, 22,
    ShadowBall, TakeDown, FlameWheel, Scratch, RunAway, Normal, None);
}
else if (number == "5")
{
    y = new Pokemon("Gastly", 29, 15, 14, 28, 15, 24,
    Lick, ClearSmog, Facade, ScaryFace, Levitate, Ghost, Poison);
}

Console.WriteLine("");
Console.WriteLine("You send out " + x.Name + "!");
Console.WriteLine("");
Console.WriteLine("Your opponent send out " + y.Name + "!");


while (true)
{
    int potion = 1;

    Console.WriteLine("\n" + x.Name + " HP: " + x.Hp + "\n");
    Console.WriteLine(y.Name + " HP: " + y.Hp + "\n");

    Console.WriteLine("");
    Console.WriteLine("What will " + x.Name + " do? \n");
    Console.WriteLine(x.move1.Name + "     Power: " + x.move1.BP);
    Console.WriteLine("PP: " + x.move1.PP + "       Acc: " + x.move1.Acc + " (Type 1)");
    Console.WriteLine("");

    Console.WriteLine(x.move2.Name + "     Power: " + x.move2.BP);
    Console.WriteLine("PP: " + x.move2.PP + "       Acc: " + x.move2.Acc + " (Type 2)");
    Console.WriteLine("");

    Console.WriteLine(x.move3.Name + "     Power: " + x.move3.BP);
    Console.WriteLine("PP: " + x.move3.PP + "       Acc: " + x.move3.Acc + " (Type 3)");
    Console.WriteLine("");

    Console.WriteLine(x.move4.Name + "     Power: " + x.move4.BP);
    Console.WriteLine("PP: " + x.move4.PP + "       Acc: " + x.move4.Acc + " (Type 4)");
    Console.WriteLine("");

    Console.WriteLine("Use potion " + potion + " (Type 5) \n");

    string choice = null;

    while (true)
    {
        string choic = Console.ReadLine();

        if (choic == "1" || choic == "2" || choic == "3" || choic == "4" || choic == "5")
        {
            choice = choic;
            break;
        }
        else { Console.WriteLine("\nInvalid move choice.\n"); }
    }

        int dmg = 0;
    if (x.Speed >= y.Speed) { 
        if (choice == "1")
        {
            dmg = x.attack(x, y, x.move1);
            y.Hp -= dmg;

        } else if (choice == "2")
        {
            dmg = x.attack(x, y, x.move2);
            y.Hp -= dmg;

        } else if (choice == "3")
        {
            dmg = x.attack(x, y, x.move3);
            y.Hp -= dmg;

        } else if (choice == "4")
        {
            dmg = x.attack(x, y, x.move4);
            y.Hp -= dmg;
        
        } else if (choice == "5") {
            if (potion >0)
            {
                x.potion(x);
            } else
            {
                Console.WriteLine("You have no potions left!");
            }

        } 

        if (x.Hp <= 0)
        {
            Console.WriteLine("\n" + x.Name + " fainted! \n" + y.Name + " wins!");
            break;
        }
        else if (y.Hp <= 0)
        {
            Console.WriteLine("\n" + y.Name + " fainted! \n" + x.Name + " wins!");
            break;
        }


    int dmge = y.determineMove(y, x);
    x.Hp -= dmge;


    }
    else
    {
        int dmge = y.determineMove(y, x);
        x.Hp -= dmge;

        if (x.Hp <= 0)
        {
            Console.WriteLine("\n" + x.Name + " fainted! \n" + y.Name + " wins!");
            break;
        }
        else if (y.Hp <= 0)
        {
            Console.WriteLine("\n" + y.Name + " fainted! \n" + x.Name + " wins!");
            break;
        }

        if (choice == "1")
        {
            dmg = x.attack(x, y, x.move1);
            y.Hp -= dmg;

        }
        else if (choice == "2")
        {
            dmg = x.attack(x, y, x.move2);
            y.Hp -= dmg;

        }
        else if (choice == "3")
        {
            dmg = x.attack(x, y, x.move3);
            y.Hp -= dmg;

        }
        else if (choice == "4")
        {
            dmg = x.attack(x, y, x.move4);
            y.Hp -= dmg;

        }
        else if (choice == "5")
        {
            if (potion > 0)
            {
                x.potion(x);
            }
            else
            {
                Console.WriteLine("You have no potions left!");
            }

        }

        if (x.Hp <= 0)
        {
            Console.WriteLine("\n" + x.Name + " fainted! \n" + y.Name + " wins!");
            break;
        }
        else if (y.Hp <= 0)
        {
            Console.WriteLine("\n" + y.Name + " fainted! \n" + x.Name + " wins!");
            break;
        }
    }


    
}







