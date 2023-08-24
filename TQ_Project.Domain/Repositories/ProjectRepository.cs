using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TQ_Project.Domain.DataAccess;
using TQ_Project.Domain.Entities;
using TQ_Project.Domain.Interfaces;

namespace TQ_Project.Domain.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProject
    {
        public ProjectRepository(EfCoreDbContext context) : base(context)
        {
        }

        public async Task<Project>? GetByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            var projectName = await _dbSet.FirstOrDefaultAsync(x => x.ProjectName == name);

            return projectName;
        }
    }
}
