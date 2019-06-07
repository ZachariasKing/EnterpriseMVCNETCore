using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public interface IFeedbackRepository
    {
        //Allows user to add feedback
        void AddFeedback(Feedback feedback);
    }
}
