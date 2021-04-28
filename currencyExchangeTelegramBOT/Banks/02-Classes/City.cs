using Banks._01_Inerfaces;

namespace Banks._02_Classes
{
    class City : IStructure
    {
        public City(int id, string nameLat, string nameRus) : base(id, nameLat, nameRus) { }
    }
}
