using System;
using System.Collections.Generic;
using System.Linq;
using static ColonyOfAnt.Utility;

namespace ColonyOfAnt
{
    public class LocationMorning : Location
    {
        private List<Ant> AllAnts = new List<Ant>();
        private List<List<Ant>> AntOnHeapFromColony;
        private List<List<List<Ant>>> AntOnHeap;

        public LocationMorning(List<Heap> heaps, List<List<Ant>> allAnt) : base(heaps, allAnt)
        {
            nameLocation = "утро";
        }

        protected override void ActionOnHeap(Heap heap, List<List<Ant>> Ants)
        {
            // AllAnts - список муравьёв со всех колоний
            foreach (var listAnts in Ants)
            {
                AllAnts.AddRange(listAnts);
            }

            foreach (var ant in AllAnts)
            {
                if (ant.myModifier.Contains("бригадир") && ant.myClass == "рабочий" ||
                    ant.myModifier.Contains("эпический"))
                {
                    ant.ModifierAction(heap, AllAnts);
                }
            }
        }
    }
}