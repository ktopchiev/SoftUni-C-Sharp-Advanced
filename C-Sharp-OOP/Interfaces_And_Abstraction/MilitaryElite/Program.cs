using MilitaryElite.Contracts;
using MilitaryElite.Enums;
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

            Dictionary<int, Soldier> soldiers = new Dictionary<int, Soldier>();
            List<Private> privates = new List<Private>();

            while ((command = Console.ReadLine()) != "End")
            {
                var input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);


                switch (input[0])
                {
                    case "Private":
                        Private soldier = new Private(int.Parse(input[1]), input[2], input[3], decimal.Parse(input[4]));
                        privates.Add(soldier);

                        if (soldiers.ContainsKey(int.Parse(input[1])))
                        {
                            soldiers[int.Parse(input[1])] = soldier;
                        }
                        else
                        {
                            soldiers.Add(int.Parse(input[1]), soldier);
                        }
                        break;
                    case "LieutenantGeneral":

                        LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(int.Parse(input[1]),
                        input[2],
                        input[3],
                        decimal.Parse(input[4]));

                        for (int i = 5; i < input.Length; i++)
                        {

                            lieutenantGeneral.AddPrivate((IPrivate)soldiers[int.Parse(input[i])]);
                        }

                        if (soldiers.ContainsKey(int.Parse(input[1])))
                        {
                            soldiers[int.Parse(input[1])] = lieutenantGeneral;
                        }
                        else
                        {
                            soldiers.Add(int.Parse(input[1]), lieutenantGeneral);
                        }
                        break;
                    case "Engineer":

                        bool isValidCorps = Enum.TryParse(input[5], out Corps corps);

                        if (!isValidCorps)
                        {
                            continue;
                        }

                        Engineer engineer = new Engineer(int.Parse(input[1]),
                        input[2],
                        input[3],
                        decimal.Parse(input[4]),
                        corps);

                        if (engineer != null)
                        {
                            for (int i = 6; i < input.Length; i += 2)
                            {
                                Repair repair = new Repair(input[i],
                                int.Parse(input[i + 1]));
                                engineer.AddRepair(repair);
                            }
                        }
                        if (soldiers.ContainsKey(int.Parse(input[1])))
                        {
                            soldiers[int.Parse(input[1])] = engineer;
                        }
                        else
                        {
                            soldiers.Add(int.Parse(input[1]), engineer);
                        }

                        break;
                    case "Commando":
                        
                        isValidCorps = Enum.TryParse(input[5], out Corps commandoCorps);

                        if (!isValidCorps)
                        {
                            continue;
                        }

                        Commando commando = new Commando(int.Parse(input[1]),
                            input[2],
                            input[3],
                            decimal.Parse(input[4]),
                            commandoCorps);
                                
                        for (int i = 6; i < input.Length; i += 2)
                        {
                                    
                            bool isMissionStateValid = Enum.TryParse(input[i + 1], out MissionState missionState);

                            if (!isMissionStateValid)
                            {
                                continue;
                            }

                            IMission mission = new Mission(input[i], missionState);

                            commando.AddMission(mission);
                        }

                        if (soldiers.ContainsKey(int.Parse(input[1])))
                        {
                            soldiers[int.Parse(input[1])] = commando;
                        }
                        else
                        {
                            soldiers.Add(int.Parse(input[1]), commando);
                        }
                        break;
                    case "Spy":
                        
                        Spy spy = new Spy(int.Parse(input[1]),
                        input[2],
                        input[3],
                        int.Parse(input[4]));

                        if (soldiers.ContainsKey(int.Parse(input[1])))
                        {
                            soldiers[int.Parse(input[1])] = spy;
                        }
                        else
                        {
                            soldiers.Add(int.Parse(input[1]), spy);
                        }
                        break;
                    default:
                        break;
                }
            }

            if (soldiers.Count > 0)
            {
                foreach (var pair in soldiers)
                {
                    Console.WriteLine(pair.Value);
                }
            }
        }
    }
}
