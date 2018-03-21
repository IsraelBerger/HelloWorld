using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloworld
{

    
        public class RollTheDice
        {
            public static int Play1skill = 0;
            public static int Play1Strength = 0;
            public static int Play2skill = 0;
            public static int Play2Strength = 0;
            public int Skill = 10;
            public int Strength = 10;
            public int Modifier = 0;
            public RollTheDice()
            {
                int enter = 0;
                int FaultCounter = 0;
                Console.WriteLine("Please set the skill value");
                bool Nonumber = false;// = int.TryParse(rubbish, out enter);
                while (Nonumber == false)
                {
                    while (FaultCounter > 0)
                    {
                        Console.WriteLine("please enter a number you want skill to");
                        break;
                    }
                    string rubbish = Console.ReadLine();
                    FaultCounter++;
                    Nonumber = int.TryParse(rubbish, out enter);
                    if (Nonumber == true)
                    {
                        break;
                    }
                }


                this.Skill = enter;
                Console.WriteLine("Skill total = {0}", this.Skill);
                Console.WriteLine();
                Console.WriteLine("please enter a number you want strength to be");
                int enter2 = 0;// = int.Parse(Console.ReadLine());
                bool Nonumber2 = false;
                int FaultCounter2 = 0;
                while (Nonumber2 == false)
                {
                    while (FaultCounter2 > 0)
                    {
                        Console.WriteLine("please enter a number you want strength to be");
                        break;
                    }
                    string rubbish = Console.ReadLine();
                    FaultCounter2++;
                    Nonumber = int.TryParse(rubbish, out enter2);
                    if (Nonumber == true)
                    {
                        break;
                    }
                }
                this.Strength = enter2;
                Console.WriteLine("Strength total = {0}", this.Strength);
                Console.WriteLine();

                NumOfPlayers++;
            }

            public static int Dice0(Random Dice1, int sides = 8)
            {
                int RolledNymber;
                RolledNymber = Dice1.Next(1, sides);
                Console.WriteLine("Dice of {0} sides Score= {1}", sides - 1, RolledNymber);
                return RolledNymber;
            }
            public static int Dice1(Random Dice1, int sides = 8)
            {
                int RolledNymber;
                RolledNymber = Dice1.Next(1, sides);
                return RolledNymber;
            }
            public static int Dice2(Random Dice2, int sides = 7)
            {
                int RolledNymber;
                RolledNymber = Dice2.Next(1, sides);
                return RolledNymber;
            }
            static Random ThrowDice1 = new Random();
            static Random ThrowDice2 = new Random();
            static int NumOfPlayers = 0;
            public static int DisplayNumOfPlayers()
            {
                Console.WriteLine(NumOfPlayers + " Number Of Players");
                return NumOfPlayers;

            }


            public static int RollThrow()
            {
                int FirstToss = Dice1(ThrowDice1, 7);
                int SecondToss = Dice1(ThrowDice2, 13);
                Console.WriteLine();
                int Score = SecondToss / FirstToss;
                //  RollThrow(); if this is called it will keep on going
                Console.WriteLine("{0}  added to your score", Score);
                Console.WriteLine();

                return Score;

            }

            public static int SkillModifier;
            public static int StrengthModifier;
            public static void Comparer()
            {
                int Winnerskill;
                int WinnerStrength;

                if ((Play1skill == Play2skill) && (Play1Strength == Play2Strength))
                {
                    Console.WriteLine("no winner at all");

                }
                if (Play1skill == RollTheDice.Play2skill)
                {
                    Console.WriteLine("no winner for skill");
                    goto Part2;
                }
                Winnerskill = Math.Max(RollTheDice.Play1skill, RollTheDice.Play2skill);
                if (Winnerskill == RollTheDice.Play1skill)
                {
                    Console.WriteLine(" player 1 is the winner for skill  your score is {0}", Winnerskill);
                    goto Part2;
                }
                if (Winnerskill == RollTheDice.Play2skill)
                {
                    Console.WriteLine(" Player 2 is the winner for skill your score is {0}", Winnerskill);
                    goto Part2;
                }
                Part2:
                if (Play1Strength == RollTheDice.Play2Strength)
                {
                    Console.WriteLine("no winner for Strength");
                    goto FINISH;
                }
                WinnerStrength = Math.Max(RollTheDice.Play1Strength, RollTheDice.Play2Strength);
                if (WinnerStrength == RollTheDice.Play1Strength)
                {
                    Console.WriteLine(" player 1 is the winner for strength  your score is {0}", WinnerStrength);
                }
                if (WinnerStrength == RollTheDice.Play2Strength)
                {
                    Console.WriteLine(" Player 2 is the winner for strength  your score is {0}", WinnerStrength);
                }
                FINISH:
                {
                    if (Play1skill != Play2skill)
                    {
                        Console.WriteLine("as there was an encounter lets try to modifie skill");
                        MakeWinnerskill();
                    }
                    if (Play1Strength != Play2Strength)
                    {
                        Console.WriteLine("as there was an encounter lets try to modifie strength");
                        MakeWinnerStrength();
                    }
                    Console.WriteLine("good luck");
                }
            }


            public static void MakeWinnerskill()
            {

                int SkillMax = Math.Max(Play1skill, Play2skill);
                int SkillMin = Math.Min(Play1skill, Play2skill);
                int SkillDifference = (SkillMax - SkillMin) / 5;
                int DiceScore1 = Dice1(ThrowDice1, 7);
                int DiceScore2 = Dice2(ThrowDice2, 7);
                int DicePlayer1 = DiceScore1;
                int DicePlayer2 = DiceScore2;
                Console.WriteLine("dice score player 1 for skill " + DicePlayer1);
                Console.WriteLine("dice score player 2 for skill " + DicePlayer2);
                if (DicePlayer1 > DicePlayer2)
                {
                    Play1skill += SkillDifference;
                    Play2skill -= SkillDifference;
                    Console.WriteLine("player 1 your skill is now " + Play1skill);
                    Console.WriteLine("player 2 your skill is now " + Play2skill);
                    if (Play2Strength < 0)
                    {
                        Console.WriteLine("Player 2 your character died");
                    }

                }
                if (DicePlayer2 > DicePlayer1)
                {
                    Play1skill -= SkillDifference;
                    Play2skill += SkillDifference;
                    Console.WriteLine("player 1 your skill is now " + Play1skill);
                    Console.WriteLine("player 2 your skill is now " + Play2skill);
                    if (Play1Strength < 0)
                    {
                        Console.WriteLine("Player 1 your character died");
                    }
                }
                if (DicePlayer2 == DicePlayer1)
                {
                    Console.WriteLine("no chages are being made");
                }

            }

            static int DiceScore3 = Dice1(ThrowDice1, 7);
            static int DiceScore4 = Dice2(ThrowDice2, 7);
            public static void MakeWinnerStrength()
            {
                int StrengthMax = Math.Max(Play1Strength, Play2Strength);
                int StrengthMin = Math.Min(Play1Strength, Play2Strength);
                int StrengthDifference = (StrengthMax - StrengthMin) / 5;
                int DicePlayer1 = DiceScore3;
                int DicePlayer2 = DiceScore4;
                Console.WriteLine();
                Console.WriteLine("dice score player 1 " + DicePlayer1);
                Console.WriteLine("dice score player 2 " + DicePlayer2);
                if (DicePlayer1 > DicePlayer2)
                {
                    Play1Strength += StrengthDifference;
                    Play2Strength -= StrengthDifference;
                    Console.WriteLine();
                    Console.WriteLine("player 1 your strength is now " + Play1Strength);
                    Console.WriteLine("player 2 your skill is now " + Play2Strength);
                    if (Play2Strength < 0)
                    {
                        Console.WriteLine("Player 2 your character died");
                    }

                }
                if (DicePlayer2 > DicePlayer1)
                {
                    Play1Strength -= StrengthDifference;
                    Play2Strength += StrengthDifference;
                    Console.WriteLine();
                    Console.WriteLine("player 1 your strength is now " + Play1Strength);
                    Console.WriteLine("player 2 your skill is now " + Play2Strength);
                    if (Play1Strength < 0)
                    {
                        Console.WriteLine("Player 1 your character died");
                    }
                }
                if (DicePlayer2 == DicePlayer1)
                {
                    Console.WriteLine("no chages are being made");
                }

            }

            public static int Divide(int a, int b)
            {
                int d = a - b;
                int c = (d / 5);
                return c;
            }
        }
        class Program
        {
            static void Main(string[] args)

            {
            
                Console.WriteLine("welcome to the dice game");
                Console.WriteLine("plesase enter your name");
                string Name1 = Console.ReadLine();

                bool WantToPlay = false;
                Console.WriteLine("would you like to play the dice " + Name1);
                string ifplay = Console.ReadLine();
                ifplay = ifplay.ToLower();
                for (;;)
                {
                    if (ifplay == "yes")
                    {
                        WantToPlay = true;
                        break;
                    }
                    if (ifplay == "no")
                    {
                        Console.WriteLine("have a nice day");
                        WantToPlay = false;
                    }
                    else if ((ifplay != "yes") || (ifplay != "no"))
                    {
                        Console.WriteLine("please enter yes or no");
                        ifplay = Console.ReadLine();
                        ifplay = ifplay.ToLower();
                    }

                }
                int WhileLoopMonitor = 1;
                int GetEvenNumberPlayList = -1;
                int GetOddNumberPlayList = 0;
                string Name2 = " ";
                List<RollTheDice> PlayDice = new List<RollTheDice>();
                while (WantToPlay == true)
                {


                    PlayDice.Add(new RollTheDice());


                    while (WhileLoopMonitor % 2 == 0)

                    {

                        Console.WriteLine();
                        RollTheDice.Play1skill = PlayDice[GetEvenNumberPlayList].Skill;
                        RollTheDice.Play1Strength = PlayDice[GetEvenNumberPlayList].Strength;
                        RollTheDice.Play2skill = PlayDice[GetOddNumberPlayList].Skill;
                        RollTheDice.Play2Strength = PlayDice[GetOddNumberPlayList].Strength;

                        RollTheDice.Comparer();
                        //RollTheDice.MakeWinnerskill();
                        // RollTheDice.MakeWinnerStrength();

                        using (StreamWriter print = new StreamWriter("file.txt"))
                        {
                            print.WriteLine("the score for {0} is {1} skill {2} strenth", Name1, RollTheDice.Play1skill, RollTheDice.Play1Strength);
                            print.WriteLine("the score for {0} is {1} skill {2} strenth", Name2, RollTheDice.Play2skill, RollTheDice.Play2Strength);
                        }

                        break;
                    }

                    RollTheDice.DisplayNumOfPlayers();
                    Console.WriteLine();

                    while (WhileLoopMonitor == 1)
                    {
                        Console.WriteLine("plesase enter your name");
                        Name2 = Console.ReadLine();
                        Console.WriteLine("would you like to play the dice {0} against {1}", Name2, Name1);
                        break;
                    }
                    while (WhileLoopMonitor % 2 == 0)
                    {
                        Console.WriteLine("another game {0} and {1}", Name1, Name2);
                        break;
                    }
                    while ((WhileLoopMonitor % 2 > 0) && (WhileLoopMonitor > 1))

                    {
                        Console.WriteLine("are you ready {0} ", Name2);
                        break;
                    }
                    string again = Console.ReadLine();
                    again = again.ToLower();
                    if ((again != "yes") && (again != "no"))
                    {
                        Console.WriteLine("next time dont type in rubish");
                        Console.WriteLine("SEE YOU");
                        WantToPlay = false;
                        break;
                    }
                    if (again == "no")
                    {
                        Console.WriteLine("thanks for playing");
                        WantToPlay = false;
                    }
                    if (again == "yes")
                    {
                        WhileLoopMonitor++;
                        Console.WriteLine(WhileLoopMonitor + " WhileLoopMonitor");
                        GetEvenNumberPlayList++;
                        Console.WriteLine(GetEvenNumberPlayList + " GetEvenNumberPlayList");
                        GetOddNumberPlayList++;
                        Console.WriteLine(GetOddNumberPlayList + " GetOddNumberPlayList");
                        WantToPlay = true;
                    }
                }

                Console.ReadKey();
            }

            public static int Dice5(Random Dice1, int sides = 8)
            {
                int RolledNymber;
                RolledNymber = Dice1.Next(1, sides);
                Console.WriteLine("Dice of {0} sides Score= {1}", sides - 1, RolledNymber);
                return RolledNymber;
            }
        }
    }

