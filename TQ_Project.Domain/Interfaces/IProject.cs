using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TQ_Project.Domain.Entities;

namespace TQ_Project.Domain.Interfaces
{
    public interface IProject : IGeneric<Project>
    {
        Task<Project>? GetByName(string name);
    }
}
