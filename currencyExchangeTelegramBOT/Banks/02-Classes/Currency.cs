using Banks._01_Inerfaces;

namespace Banks._02_Classes
{
    class Currency : IStructure
    {
        public Currency(int id, string nameLat, string nameRus) : base(id, nameLat, nameRus) { }
    }
}
