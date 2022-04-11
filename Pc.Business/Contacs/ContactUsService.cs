using Pc.Business.Interfaces.Contacs;
using Pc.Core.Entities;
using Pc.Repository.Interface.ContactUsx;
using System.Threading.Tasks;

namespace Pc.Business.Contacs
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;
        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        public Task Create(ContactUs contactUs)
        {
            return _contactUsRepository.Insert(contactUs);
        }
    }
}
