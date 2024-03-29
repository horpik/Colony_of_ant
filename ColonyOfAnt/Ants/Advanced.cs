using System.Collections.Generic;

namespace ColonyOfAnt
{
    public class Advanced : Ant
    {
        // <продвинутый> ВОИН(здоровье=6, защита=2, урон=4) может атаковать 2 цели за раз и наносит 1 укус.
        // <продвинутый бригадир> РАБОЧИЙ(здоровье=6, защита=2) может брать 2 ресурса: 'веточка или камушек' за раз; все рабочие могут брать +1 ресурс.
        // <продвинутый опытный> РАБОЧИЙ(здоровье=6, защита=2) может брать 2 ресурса: 'росинка или росинка' за раз; может брать любой тип ресурса.
        public Advanced(string UnitClass, Colony colony)
        {
            myModifier = new List<string>(){"продвинутый"};
            InitializingParameters(6, 2, 4, UnitClass, colony, new int[2] {2, 1}, new int[2]{2,1});
        }
    }
}