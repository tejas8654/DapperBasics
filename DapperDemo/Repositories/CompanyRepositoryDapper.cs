using Dapper;
using DapperDemo.Data;
using DapperDemo.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperDemo.Repositories
{
    public class CompanyRepositoryDapper : ICompanyRepository
    {

        private IDbConnection db;
        public CompanyRepositoryDapper(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public Company Add(Company company)
        {
            string sql = "INSERT INTO Companies (Name, Address, City, PostalCode) VALUES(@Name, @Address, @City, @PostalCode);"+
                        "SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = db.Query<int>(sql, new 
            { 
                @Name = company.Name, 
                Address = company.Address, 
                @City = company.City, 
                PostalCode = company.PostalCode 
            }).Single();
            company.CompanyId = id;
            return company;
        }

        public Company Find(int id)
        {
            string sql = "SELECT * FROM Companies WHERE CompanyId = @CompanyId";
            return this.db.Query<Company>(sql, new { @CompanyId = id }).Single();
        }

        public List<Company> GetAll()
        {
            string sql = "select * from Companies";
            return this.db.Query<Company>(sql).ToList();            
        }

        public void Remove(int id)
        {
            string sql = "DELETE FROM Companies WHERE CompanyId = @Id";
            this.db.Query(sql, new {@Id=id});
        }

        public Company Update(Company company)
        {
            string sql = "UPDATE Companies SET Name = @Name, Address = @Address, City = @City, PostalCode = @PostalCode WHERE CompanyId = @CompanyId";
            var id = db.Query<int>(sql, new
            {
                @Name = company.Name,
                Address = company.Address,
                @City = company.City,
                PostalCode = company.PostalCode,
                CompanyId=company.CompanyId
            });
            return company;
        }
    }
}
