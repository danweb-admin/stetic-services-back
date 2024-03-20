using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using Solucao.Application.Data.Entities;
using Solucao.Application.Utils;

namespace Solucao.Application.Data.Repositories
{
	public class HistoryRepository
	{
        public IUnitOfWork UnitOfWork => Db;
        protected readonly SolucaoContext Db;
        protected readonly DbSet<History> DbSet;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserRepository userRepository;

        public HistoryRepository(SolucaoContext _context, IHttpContextAccessor _httpContextAccessor, UserRepository _userRepository)
		{
            Db = _context;
            DbSet = Db.Set<History>();
            httpContextAccessor = _httpContextAccessor;
            userRepository = _userRepository;
        }

        public virtual async Task Add(string tableName, Guid recordId, string operation)
        {

            var userName = httpContextAccessor.HttpContext.User?.Identity.Name;
            if (string.IsNullOrEmpty(userName))
                userName = "administrador";
            var user = await userRepository.GetByName(userName);

            var history = new History
            {
                Id = Guid.NewGuid(),
                TableName = tableName,
                RecordId = recordId,
                Operation = operation,
                UserId = user.Id,
                OperationDate = Helpers.DateTimeNow()

            };
            DbSet.Add(history);
            await Db.SaveChangesAsync();

        }

        public async Task<IEnumerable<History>> GetAll(string tableName, Guid recordId)
        {
            return await DbSet.Include(x => x.User).Where(x => x.TableName == tableName && x.RecordId == recordId)
                .OrderBy(x => x.OperationDate)
                .ToListAsync();
        }
    }
}

