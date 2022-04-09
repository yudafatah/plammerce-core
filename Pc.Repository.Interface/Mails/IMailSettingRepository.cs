using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Mails
{
    public interface IMailSettingRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<MailSetting>> GetAll();
        Task<MailSetting> GetById(string id);
        Task Insert(MailSetting entity);
        Task Update(MailSetting entity);
        Task Upsert(MailSetting entity);
    }
}
