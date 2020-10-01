using GNG_v0._2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNG_v0._2.Models
{
    public class MockEximiusParticipantRepository : EximiusParticipantRepository
    {
        private List<ExismiusViewModel> ParticipantList;

        public MockEximiusParticipantRepository()
        {
            ParticipantList = new List<ExismiusViewModel>();
        }


        public ExismiusViewModel GetParticipant(int ID)
        {
            return ParticipantList.FirstOrDefault(e => e.Id == ID);
        }

        public ExismiusViewModel Register(ExismiusViewModel exismiusViewModel)
        {
            if (exismiusViewModel == null)
            {
                exismiusViewModel.Id = 1;
            }
            else
            {
                exismiusViewModel.Id = ParticipantList.Max(e => e.Id) + 1;
            }
            ParticipantList.Add(exismiusViewModel);
            return exismiusViewModel;
        }

        public ExismiusViewModel Delete(int ID)
        {
            ExismiusViewModel deleteParticipant = ParticipantList.FirstOrDefault(e => e.Id == ID);
            if (deleteParticipant != null)
            {
                ParticipantList.Remove(deleteParticipant);
            }
            return deleteParticipant;
        }


        
        public IEnumerable<ExismiusViewModel> GetAllParticipant()
        {
            return ParticipantList;
        }
    }
}
