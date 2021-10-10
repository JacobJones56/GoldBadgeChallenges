using BadgesClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesRepositroy
{
    public class BadgesRepo
    {
        private Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();
       
        // Create
        public void CreateNewBadge(Badges newBadges)
        {
            _badges.Add(newBadges.BadgeId, newBadges.DoorCodeNames);
        }

        // Read 
        public Dictionary<int, List<string>> GetListOfBadges()
        {
            return _badges;
        }

        public bool CheckBadge(int id)
        {
            bool badgeIsReal = _badges.ContainsKey(id);

            if (badgeIsReal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> CheckKeys(int id)
        {
            foreach (var badges in _badges)
            {
                int badgeIds = badges.Key;
                List<string> doorNames = badges.Value;

                if(badgeIds == id)
                {
                    return doorNames;
                }
            }
            return null;
        }
        public bool RemoveDoorCodeNames(int id, string doorCodeNames) 
        { 
            foreach(var badges in _badges)
            {
                int badgeIds = badges.Key;
                List<string> doorValue = badges.Value;

                foreach (string door in doorValue) 
                {
                    if (doorCodeNames == door && id == badges.Key)
                    {
                        doorValue.Remove(doorCodeNames);
                        return true;
                    }
                }
            }
            return false;
        }

        public void AddDoorCodeNames(int id, string doorCodeNames)
        {
           foreach(var badges in _badges)
            {
                int badgeIds = badges.Key;
                List<string> doorValue = badges.Value;

                if(id == badges.Key)
                {
                    doorValue.Add(doorCodeNames);
                }
            }
        }

    }
    
}
