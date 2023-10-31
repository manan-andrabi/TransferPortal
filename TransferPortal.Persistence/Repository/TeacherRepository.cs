using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferPortal.Application.Abstraction.IRepository;
using TransferPortal.Application.Abstraction.RRModal;
using TransferPortal.Domain.Entities;
using TransferPortal.Persistence.Data;

namespace TransferPortal.Persistence.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly TransferPortalDbContext context;
        public TeacherRepository(TransferPortalDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Add(Teacher teacher)
        {
          var x=  context.AddAsync(teacher);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid id)
        {
            var teacher = await context.Teachers.FindAsync(id);

            if (teacher != null)
            {
                context.Teachers.Remove(teacher);
                return await context.SaveChangesAsync();
            }

            return 0; // Teacher with the specified id was not found.
        }


        public async Task<IEnumerable<Teacher>> GetAll()
        {
            return await context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetById(Guid id)
        {
            var teacher = await context.Teachers.FindAsync(id);
          
            return teacher;
        }

        public async Task<Teacher> GetByPhone(string no)
        {
            var teacher = await context.Teachers.FirstOrDefaultAsync(t => t.Phone == no);

            return teacher;
        }

        




        //REsults
        public async Task<IEnumerable<TransferList>> GetResult()
        {
         
                var query = from t1 in context.Teachers
                            join t2 in context.Teachers
                            on new { FromDist = t1.FromDist, ToDist = t1.ToDist }
                            equals new { FromDist = t2.ToDist, ToDist = t2.FromDist }
                            select new TransferList
                            {
                                Match_Id=t1.Id,
                                Match_Gender = t1.Gender,
                                Match = t1.Name,
                                Match_Contact=t1.Phone,
                                Match_Created=t1.CreatedOn,
                                Match_Designation=t1.Designation,
                                FromDist = t1.FromDist,
                                ToDist= t1.ToDist,  

                                MatchWith_Id = t2.Id,
                                MatchWith_Contact=t2.Phone, 
                                MatchWith_Created = t2.CreatedOn,
                                MatchWith_Designation=t2.Designation,
                                MatchWith =t2.Name,
                                MatchWith_Gender=t2.Gender,
                                MatchWith_FromDist=t2.FromDist,
                                MatchWith_ToDist=t2.ToDist,   
                            };
                return await query.ToListAsync();
        }
    }
}
