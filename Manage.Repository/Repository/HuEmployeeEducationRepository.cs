using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Model.Context;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuEmployeeEducationRepository : RepositoryBase<HuEmployeeEducation>, IHuEmployeeEducationRepository
    {
        public HuEmployeeEducationRepository(DatabaseContext context) : base(context)
        {
        }
        
    }
}
