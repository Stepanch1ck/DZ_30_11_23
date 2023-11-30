

namespace Building
{
    public class Build
    {
        private static int nextUniqueNumber = 1;
        private int uniqueNumber;
        private double Height;
        private int Floors;
        private int Apartments;
        private int Entrances;

        internal Build(double height, int floors, int apartments, int entrances)
        {
            Height = height;
            Floors = floors;
            Apartments = apartments;
            Entrances = entrances;
            uniqueNumber = nextUniqueNumber;
            nextUniqueNumber++;
        }

        public static Build CreateBuilding(double height, int floors, int apartments, int entrances)
        {
            return new Build(height, floors, apartments, entrances);
        }

        public static void RemoveBuilding(int uniqueNumber)
        {
            Creator._buildings.Remove(uniqueNumber);
        }

        public int GetUniqueNumber()
        {
            return uniqueNumber;
        }

        public double GetHeight()
        {
            return Height;
        }

        public int GetFloors()
        {
            return Floors;
        }

        public int GetApartments()
        {
            return Apartments;
        }

        public int GetEntrances()
        {
            return Entrances;
        }

        public int GetApartmentsOnFloor()
        {
            return Apartments / Floors;
        }

        public int GetApartmentsInEntrance()
        {
            return Apartments / Entrances;
        }

        public double GetFloorHeight()
        {
            return Height / Floors;
        }

        public override string ToString()
        {
            return $"Номер здания: {uniqueNumber}, высота: {Height}, этажность: {Floors}, количество квартир: {Apartments}, количество подъездов: {Entrances}";
        }
    }
}
