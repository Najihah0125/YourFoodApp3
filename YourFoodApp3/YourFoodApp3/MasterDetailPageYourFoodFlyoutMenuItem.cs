using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourFoodApp3
{
    public class MasterDetailPageYourFoodFlyoutMenuItem
    {
        public MasterDetailPageYourFoodFlyoutMenuItem()
        {
            TargetType = typeof(MasterDetailPageYourFoodFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}