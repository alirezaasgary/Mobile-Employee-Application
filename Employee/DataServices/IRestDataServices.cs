using Employee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DataServices
{
    public interface IRestDataServices
    {

        Task<List<Company>> GetCompanyListAsync();
        Task AddCompany(Company company);
        Task DeleteCompany(int id);
        Task UpdateCompany(Company company);
    }
}
