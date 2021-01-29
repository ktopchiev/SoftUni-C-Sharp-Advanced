using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int[]> stations = new Queue<int[]>();
            int stationsNum = int.Parse(Console.ReadLine());

            GetStationsData(stationsNum, stations);
            
            int stationIndex = 0;
            int truckFuelQty = 0;
            int passedStations = 0;
            
            for (int i = 0; i < stations.Count; i++)
            {
                
                int[] currentStation = stations.Peek();
                int stationGasQty = currentStation[0];
                int stationDistance = currentStation[1];

                if (truckFuelQty + stationGasQty >= stationDistance)
                {
                    passedStations++;

                    truckFuelQty += (stationGasQty - stationDistance);
                    stations.Enqueue(stations.Dequeue());
                    
                    if (passedStations == stationsNum)
                    {
                        Console.WriteLine(stationIndex);
                        break;
                    }
                }
                else
                {
                    stationIndex++;
                    
                    if (stationIndex == stations.Count - 1)
                    {
                        break;
                    }

                    truckFuelQty = 0;
                    passedStations = 0;
                    
                    stations.Enqueue(stations.Dequeue());

                    i = -1;
                }
            }
        }

        private static void GetStationsData(int stationsNum, Queue<int[]> stations)
        {
            for (int i = 0; i < stationsNum; i++)
            {
                int[] stationsInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                stations.Enqueue(stationsInfo);
            }
        }
    }
}