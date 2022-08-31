﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manage.Common;
using Manage.Model.Context;
using Manage.Model.DTO.Bank;
using Manage.Model.DTO.BankBranch;
using Manage.Model.Models;
using Manage.Repository.Base.Repository;
using Manage.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Repository
{
    public class HuBankRepository : RepositoryBase<HuBank>, IHuBankRepository
    {
        public HuBankRepository(DatabaseContext context) : base(context)
        {
           
        }
        public async Task<HuBank> FindByName(string name)
        {
            return await FindByCondition(n => n.Name.Equals(name)).FirstOrDefaultAsync();
        }
        public async Task<List<ListBankBranch>> FindAllBankById(List<ListBankBranch> listBankBranches)
        {
            foreach (ListBankBranch listBankBranch in listBankBranches)
            {
                HuBank huBank= await FindById(listBankBranch.BankID);
                listBankBranch.Bankname = huBank.Name;
            }
            return listBankBranches;
        }

        public async Task<List<HuBank>> GetAll(BaseRequest baseRequest)
        {
            if(baseRequest.keyworks != null)
            {
                        return await FindAll()
                   .Where(n => n.Name.Equals(baseRequest.keyworks) && n.Activeflg.Equals("A"))
                   .OrderBy(a => a.Id)
                   .Skip((baseRequest.pageNum - 1) * baseRequest.pageSize)
                   .Take(baseRequest.pageSize)
                   .ToListAsync();
            }

            return await FindAll()
           .Where(n =>n.Activeflg.Equals("A"))
           .OrderBy(a => a.Id)
           .Skip((baseRequest.pageNum - 1) * baseRequest.pageSize)
           .Take(baseRequest.pageSize)
           .ToListAsync();
        }
    }
}