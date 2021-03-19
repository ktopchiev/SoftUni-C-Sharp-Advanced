using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command;

            List<Soldier> soldiers = new List<Soldier>();
            List<Private> privates = new List<Private>();


            while ((command = Console.ReadLine()) != "End")
            {
                var input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (input[0].ToLower())
                {
                    case "private":
                        Private soldier = new Private(int.Parse(input[1]), input[2], input[3], decimal.Parse(input[4]));
                        soldiers.Add(soldier);
                        privates.Add(soldier);
                        break;
                    case "lieutenantgeneral":
                        int[] privatesIds = privates.Select(x => x.Id).ToArray();
                        LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(int.Parse(input[1]), input[2], input[3], decimal.Parse(input[4]), privatesIds);
                        lieutenantGeneral.AddPrivates(privates);
                        soldiers.Add(lieutenantGeneral);
                        break;
                    case "engineer":
                        Engineer engineer = Engineer.NewEngineer(int.Parse(input[1]), input[2], input[3], decimal.Parse(input[4]), input[5]);

                        if (engineer != null)
                        {
                            for (int i = 6; i < input.Length; i += 2)
                            {
                                Repair repair = new Repair(input[i], int.Parse(input[i + 1]));
                                engineer.AddRepair(repair);
                            }
                        }

                        soldiers.Add(engineer);
                        break;
                    case "commando":
                        Commando commando = Commando.NewCommando(int.Parse(input[1]), input[2], input[3], decimal.Parse(input[4]), input[5]);

                        if (commando != null)
                        {
                            for (int i = 6; i < input.Length; i += 2)
                            {
                                Mission mission = Mission.Create(input[i], input[i + 1]);
                                commando.AddMission(mission);
                            }
                        }

                        soldiers.Add(commando);
                        break;
                    case "spy":
                        Spy spy = new Spy(int.Parse(input[1]),input[2],input[3],int.Parse(input[4]));
                        soldiers.Add(spy);
                        break;
                    default:
                        break;
                }
            }

            if (soldiers.Count > 0)
            {
                soldiers.ForEach(Console.WriteLine);
            }
        }
    }
}
