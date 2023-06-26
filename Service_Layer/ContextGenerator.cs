using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class ContextGenerator
    {
        private static DBContext dbContext;
        private static UserContext userContext;
        private static InterestContext interestContext;

        public static DBContext GetDbContext()
        {
            if (dbContext == null)
            {
                SetDbContext();
            }
            return dbContext;
        }

        public static void SetDbContext()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }

            dbContext = new DBContext();
        }

        public static UserContext GetUserContext()
        {
            if (userContext == null)
            {
                SetUserContext();
            }

            return userContext;
        }

        public static void SetUserContext()
        {
            userContext = new UserContext(GetDbContext());
        }



        public static InterestContext GetInterestContext()
        {
            if (interestContext == null)
            {
                SetUserContext();
            }

            return interestContext;
        }

        public static void SetInterestContext()
        {
            interestContext = new InterestContext(GetDbContext());
        }


    }
}
