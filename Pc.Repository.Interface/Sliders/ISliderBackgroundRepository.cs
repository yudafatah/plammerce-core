using Pc.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pc.Repository.Interface.Sliders
{
    public interface ISliderBackgroundRepository
    {
        Task Delete(string id);
        Task DeleteAll();
        Task<List<SliderBackground>> GetAll();
        Task<SliderBackground> GetById(string id);
        Task Insert(SliderBackground entity);
        Task Update(SliderBackground entity);
        Task Upsert(SliderBackground entity);
    }
}
