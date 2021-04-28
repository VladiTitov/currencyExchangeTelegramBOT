namespace Banks._01_Inerfaces
{
    public abstract class IStructure
    {
        public IStructure(int key, string nameLat, string nameRus)
        {
            Key = key;
            NameLat = nameLat;
            NameRus = nameRus;
        }

        public int Key { get; set; }
        public string NameLat { get; set; }
        public string NameRus { get; set; }
    }
}
