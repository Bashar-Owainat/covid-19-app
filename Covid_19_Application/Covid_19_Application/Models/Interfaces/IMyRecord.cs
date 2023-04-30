using System.Threading.Tasks;
using System;
using Covid_19_Application.Models.DTOs;
using System.Collections.Generic;

namespace Covid_19_Application.Models.Interfaces
{
    public interface IMyRecord
    {
        Task<MyRecord> Create(MyRecord myRecord);

        Task<MyRecord> Get(String ID);
        Task<List<MyRecord>> GetAll();
        Task Delete(String ID);
    }
}
