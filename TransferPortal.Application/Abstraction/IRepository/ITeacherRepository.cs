using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferPortal.Application.Abstraction.RRModal;
using TransferPortal.Domain.Entities;

namespace TransferPortal.Application.Abstraction.IRepository
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAll();
        Task <Teacher> GetByPhone(string no);
        Task<Teacher> GetById(Guid id);

        Task<IEnumerable<TransferList>> GetResult();
        
        Task<int> Add(Teacher t);
        Task<int> Delete(Guid id);

         


      
    }
}
