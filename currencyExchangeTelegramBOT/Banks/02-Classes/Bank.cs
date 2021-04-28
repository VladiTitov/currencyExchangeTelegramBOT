using Banks._01_Inerfaces;

namespace Banks._02_Classes
{
    public class Bank : IStructure
    {
        public Bank(int id, string nameLat, string nameRus) : base(id, nameLat, nameRus) { }
    }
}
