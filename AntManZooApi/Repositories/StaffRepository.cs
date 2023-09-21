using AntManZooApi.Datas;
using AntManZooClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AntManZooApi.Repositories
{
    public class StaffRepository : IRepository<Staff>
    {

        private ApplicationDbContext _dbContext { get; }
        public StaffRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CRUD


        // Create

        public async Task<int> Add(Staff staff)
        {
            var addedObj = await _dbContext.Staffs.AddAsync(staff);
            await _dbContext.SaveChangesAsync();
            return addedObj.Entity.Id;
        }

        // Read

        public async Task<Staff?> GetById(int id)
        {
            return await _dbContext.Staffs.FindAsync(id);
        }
        public async Task<Staff?> Get(Expression<Func<Staff, bool>> predicate)
        {
            return await _dbContext.Staffs.FirstOrDefaultAsync(predicate);
        }
        public async Task<List<Staff>> GetAll()
        {
            return await _dbContext.Staffs.ToListAsync();
        }
        public async Task<List<Staff>> GetAll(Expression<Func<Staff, bool>> predicate)
        {
            return await _dbContext.Staffs.Where(predicate).ToListAsync();
        }

        // Update

        public async Task<bool> Update(Staff staff)
        {
            var staffFromDb = await GetById(staff.Id);

            if (staffFromDb == null)
                return false;

            if (staffFromDb.Firstname != staff.Firstname)
                staffFromDb.Firstname = staff.Firstname;
            if (staffFromDb.Lastname != staff.Lastname)
                staffFromDb.Lastname = staff.Lastname;
            if (staffFromDb.Email != staff.Email)
                staffFromDb.Email = staff.Email;
            if (staffFromDb.Password != staff.Password)
                staffFromDb.Password = staff.Password;

            return await _dbContext.SaveChangesAsync() > 0;
        }

        // Delete

        public async Task<bool> Delete(int id)
        {
            var staff = await GetById(id);

            if (staff == null)
                return false;

            _dbContext.Staffs.Remove(staff);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
