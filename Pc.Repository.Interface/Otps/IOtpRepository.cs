using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Otps
{
    public interface IOtpRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<Otp>> GetAll();
        Task<Otp> GetById(string id);
        Task Insert(Otp entity);
        Task Update(Otp entity);
        Task Upsert(Otp entity);
    }
}
