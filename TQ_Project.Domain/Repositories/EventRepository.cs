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
    public class EventRepository : GenericRepository<Event>, IEvent
    {
        public EventRepository(EfCoreDbContext context) : base(context)
        {
        }
    }
}
