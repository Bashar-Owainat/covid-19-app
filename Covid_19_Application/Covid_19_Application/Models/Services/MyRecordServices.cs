using Covid_19_Application.Data;
using Covid_19_Application.Models.DTOs;
using Covid_19_Application.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Covid_19_Application.Models.Services
{
    public class MyRecordServices :IMyRecord
    {
        private readonly CovidDbContext _context;

        public MyRecordServices(CovidDbContext context)
        {
            _context = context;
        }

        public async Task<MyRecord> Create(MyRecord myRecord)
        {
            _context.Entry(myRecord).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return myRecord;
        }
        public async Task<MyRecord> Get(string ID)
        {
            MyRecord myRecord = await _context.Records.FindAsync(ID);

            return myRecord;
        }

        public async Task Delete(string ID)
        {
            MyRecord myRecord = await Get(ID);

            _context.Entry(myRecord).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<MyRecord>> GetAll()
        {
           List<MyRecord> records = await _context.Records.ToListAsync();

            return records;
        }
    }
}
