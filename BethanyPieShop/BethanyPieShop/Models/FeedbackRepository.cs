using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Models
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _appDbContext;

        //Constructor Inject the DbContext to allow EF to work
        public FeedbackRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddFeedback(Feedback feedback)
        {
            //Add feedback to database
            _appDbContext.Feedbacks.Add(feedback);
            //Persist changes in databse
            _appDbContext.SaveChanges();
        }

    }
}
