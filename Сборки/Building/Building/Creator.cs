using System.Collections.Generic;

namespace Building
{
    public class Creator
    {
        
        internal static Dictionary<int, Build> _buildings = new Dictionary<int, Build>();

        public Creator()
        {
        }

        public static Build CreateBuilding(int height, int floors, int apartments, int entrances)
        {
            Build building = new Build(height, floors, apartments, entrances);
            _buildings.Add(building.GetUniqueNumber(), building);
            return building;
        }

        public static void RemoveBuilding(int uniqueNumber)
        {
            _buildings.Remove(uniqueNumber);
        }
        public static Build GetBuilding(int uniquenumber)
        {
            return _buildings[uniquenumber];
        }
        public static bool IsBuildingClosed(int uniqueNumber)
        {
            return !_buildings.ContainsKey(uniqueNumber);
        }
    }
}
