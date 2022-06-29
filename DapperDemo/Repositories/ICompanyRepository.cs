﻿using DapperDemo.Models;

namespace DapperDemo.Repositories
{
    public interface ICompanyRepository
    {
        Company Find(int id);

        List<Company> GetAll();

        Company Add(Company company);
        Company Update(Company company);
        void Remove(int id);
    }
}
