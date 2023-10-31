using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferPortal.Application.Abstraction.IRepository;
using TransferPortal.Application.Abstraction.IService;
using TransferPortal.Application.Abstraction.RRModal;
using TransferPortal.Domain.Entities;

namespace TransferPortal.Application.Abstraction.Service
{
    public class TeacherService : ITeacherService
    {
        readonly ITeacherRepository? repository;

        public TeacherService(ITeacherRepository? repository)
        {
            this.repository = repository;
        }


        public async Task<int> Add(TeacherRequest modal)
        {
            string input = modal.Name;
            string capitalized = char.ToUpper(input[0]) + input.Substring(1);
            Teacher teacher = new()
            {
                Id = Guid.NewGuid(),
                Name = capitalized,
                Phone = modal.Phone,
                Designation = modal.Designation,
                FromDist = modal.FromDist,
                ToDist = modal.ToDist,
                CreatedOn = DateTime.Now.ToString()
            };
            var x = await repository.Add(teacher);
            return x;

        }

        public async Task<int> Delete(Guid id)
        {
            return await repository.Delete(id);
        }

        public async Task<IEnumerable<TeacherResponse>> GetAll()
        {
            var res = await repository.GetAll();
            var i = res.Select(x => new TeacherResponse
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Designation = x.Designation,
                FromDist = x.FromDist,
                ToDist = x.ToDist,
                CreatedOn = x.CreatedOn
            });
            return i;
        }

        public async Task<TeacherResponse> GetByID(Guid i)
        {
            var x = await repository.GetById(i);
            var teacher = new TeacherResponse
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Designation = x.Designation,
                FromDist = x.FromDist,
                ToDist = x.ToDist,
                CreatedOn = x.CreatedOn
            };
            return teacher;
        }

        public async Task<TeacherResponse> GetByPhone(string no)
        {
            var x = await repository.GetByPhone(no);
            var teacher = new TeacherResponse
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Designation = x.Designation,
                FromDist = x.FromDist,
                ToDist = x.ToDist,
                CreatedOn = x.CreatedOn

            };
            return teacher;
        }

        public async Task<IEnumerable<TransferList>> GetResult()
        {
            var res = await repository.GetResult();
            var results = res.Select(x => new TransferList
            {
                Match = x.Match,
                Match_Id = x.Match_Id,
                ToDist = x.ToDist,
                FromDist = x.FromDist,
                Match_Contact = x.Match_Contact,
                Match_Created = x.Match_Created,
                Match_Designation = x.Match_Designation,
                Match_Gender = x.Match_Gender,

                MatchWith_Id = x.MatchWith_Id,
                MatchWith = x.MatchWith,
                MatchWith_Contact = x.MatchWith_Contact,
                MatchWith_Created = x.MatchWith_Created,
                MatchWith_Designation = x.MatchWith_Designation,
                MatchWith_FromDist = x.MatchWith_FromDist,
                MatchWith_Gender = x.MatchWith_Gender,
                MatchWith_ToDist = x.MatchWith_ToDist,
            });
            return results;
        }
    }
}
