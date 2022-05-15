using System;
using System.Collections.Generic;
using System.Linq;
using static ColonyOfAnt.Utility;

namespace ColonyOfAnt
{
    public class LocationDay : Location
    {
        private List<List<Ant>> AntOnHeapFromColony;
        private List<List<List<Ant>>> AntOnHeap;


        public LocationDay(List<Heap> heaps, List<List<Ant>> allAnt) : base(heaps, allAnt)
        {
            nameLocation = "день";
        }

        protected override void ActionOnHeap(Heap heap, List<List<Ant>> ListColony)
        {
            foreach (var thisColony in ListColony)
            {
                var enemyColony = new List<Ant>();
                foreach (var listAnt in ListColony.Where(listAnt => listAnt != thisColony))
                {
                    enemyColony.AddRange(listAnt);
                }

                foreach (var ant in thisColony)
                {
                    if (ant.myClass == "рабочий")
                    {
                        ant.TakeResource(heap);
                    }

                    if (ant.myClass == "воин")
                    {
                        ant.Attack(enemyColony);
                    }

                    if (ant.myClass == "особый")
                    {
                        if (ant.myModifier.Contains("агрессивный"))
                        {
                            ant.Attack(ant.myModifier.Contains("аномальный") ? thisColony : enemyColony);
                        }
                        if (ant.myModifier.Contains("мирный") && !ant.myModifier.Contains("ленивый"))
                        {
                            ant.TakeResource(heap);
                        }
                    }
                }
            }
        }
    }
}