using System;
using System.Collections.Generic;
using System.Text;

namespace Application.GameCQ.Unit.Queries
{
    public class UnitViewModel
    {
        public string Name { get; set; }

        public string ClassType { get; set; }

        public string Race { get; set; }

        public int Level { get; set; }

        public double AttackPower { get; set; }

        public double MagicPower { get; set; }

        public double ArmorValue { get; set; }

        public double RessistanceValue { get; set; }
    }
}
