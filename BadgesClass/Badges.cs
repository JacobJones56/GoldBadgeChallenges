using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesClass
{
    public class Badges
    {
        public int BadgeId { get; set; }
        public List<string> DoorCodeNames { get; set; } = new List<string>();
        public string BadgeName { get; set; }

        public Badges() { }

        public Badges(int badgeId, List<string> doorCodeNames, string badgeName)
        {
            BadgeId = badgeId;
            DoorCodeNames = doorCodeNames;
            BadgeName = badgeName;
        }
    }
}
