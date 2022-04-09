using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.ContactUsx
{
    public interface IContactUsRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<ContactUs>> GetAll();
        Task<ContactUs> GetById(string id);
        Task Insert(ContactUs entity);
        Task Update(ContactUs entity);
        Task Upsert(ContactUs entity);
    }
}
