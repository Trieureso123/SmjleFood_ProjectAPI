using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmjleFood_Project.Service.Helpers
{
    public class Enum
    {
        #region ProductEnum
        public enum ProductStatsEnum
        {
            IsAvailable = 1,
            IsAvtive = 1
        }
        #endregion

        #region User
        public enum UserStatsEnum
        {
            IsActive = 1
        }
        #endregion

        #region Store
        public enum StoreTypeEnum
        {
            CoffeeShop = 1,
            ConvenienceStore = 2
        }

        public enum StoreStatEnum
        {
            IsActive = 1,
        }
        #endregion

    }
}
