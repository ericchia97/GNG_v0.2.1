using GNG_v0._2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNG_v0._2.Models
{
    public class SQLEximiusParticipantRepository : EximiusParticipantRepository
    {
        private readonly AppDbContext context;

        public SQLEximiusParticipantRepository(AppDbContext context)
        {
            this.context = context;
        }
        public ExismiusViewModel Delete(int ID)
        {
            ExismiusViewModel delete = context.EximiusParticipantTable.Find();
            if (delete != null)
            {
                context.EximiusParticipantTable.Remove(delete);
                context.SaveChanges();
            }
            return delete;
        }

        public IEnumerable<ExismiusViewModel> GetAllParticipant()
        {
            return context.EximiusParticipantTable;
        }

        public ExismiusViewModel GetParticipant(int Id)
        {
            return context.EximiusParticipantTable.Find(Id);
        }

        public ExismiusViewModel Register(ExismiusViewModel exismiusViewModel)
        {
            context.EximiusParticipantTable.Add(exismiusViewModel);
            context.SaveChanges();
            return exismiusViewModel;
        }
    }
}
