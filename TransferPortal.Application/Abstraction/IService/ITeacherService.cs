using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferPortal.Application.Abstraction.RRModal;
using TransferPortal.Domain.Entities;

namespace TransferPortal.Application.Abstraction.IService
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherResponse>> GetAll();
        Task<TeacherResponse> GetByPhone(string no);
        Task<TeacherResponse> GetByID(Guid id);
        Task<IEnumerable<TransferList>> GetResult();

        Task<int> Add(TeacherRequest modal);
        Task<int> Delete(Guid id);
    }
}
