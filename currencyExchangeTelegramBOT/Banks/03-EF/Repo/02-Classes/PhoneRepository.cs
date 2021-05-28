namespace DataAccess.Repo
{
    public class PhoneRepository : GenericRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(DataContext context) : base(context) { }
    }
}
