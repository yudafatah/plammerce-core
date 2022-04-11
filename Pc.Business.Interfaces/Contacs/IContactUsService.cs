using Pc.Core.Entities;
using System.Threading.Tasks;

namespace Pc.Business.Interfaces.Contacs
{
    public interface IContactUsService
    {
        Task Create(ContactUs contactUs);
    }
}
