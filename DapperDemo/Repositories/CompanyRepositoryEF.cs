using DapperDemo.Data;
using DapperDemo.Models;

namespace DapperDemo.Repositories
{
    public class CompanyRepositoryEF : ICompanyRepository
    {
        private readonly ApplicationDBContext _db;

        public CompanyRepositoryEF(ApplicationDBContext context)
        {
            _db = context;
        }
        public Company Add(Company company)
        {
            _db.Companies.Add(company);
            _db.SaveChanges();
            return company;
        }

        public Company Find(int id)
        {
            return _db.Companies.FirstOrDefault(x => x.CompanyId == id);
        }

        public List<Company> GetAll()
        {
            return _db.Companies.ToList();
        }

        public void Remove(int id)
        {
            Company company = _db.Companies.FirstOrDefault(x => x.CompanyId == id);
            _db.Remove(company);
            _db.SaveChanges();
            return;
        }

        public Company Update(Company company)
        {
            _db.Companies.Update(company);
            _db.SaveChanges();
            return company;
        }
    }
}
