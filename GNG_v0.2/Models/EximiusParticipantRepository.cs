using GNG_v0._2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNG_v0._2.Models
{
    public interface EximiusParticipantRepository
    {
        ExismiusViewModel GetParticipant(int ID);
        IEnumerable<ExismiusViewModel> GetAllParticipant();
        ExismiusViewModel Register(ExismiusViewModel exismiusViewModel);
        ExismiusViewModel Delete(int ID);
    }
}
