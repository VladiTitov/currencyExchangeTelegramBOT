using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IPhoneService
    {
        List<PhoneDTO> GetData();
        void Add(PhoneDTO bank);
        void Update(PhoneDTO bank);
        void Delete(PhoneDTO item);
    }
}
