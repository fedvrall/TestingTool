using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Data;
using Test_Management_System.Entities;

namespace Test_Management_System.Classes
{
    public class PriorityColorConverter : IValueConverter
    {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return GetPriorityColorKey(value as Testing_ToolEntities);
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }

            private string GetPriorityColorKey(Testing_ToolEntities entity)
            {
                var prior = entity.TestCasePriority.Select(c => c.TCPriorityDescriptionTranslation).ToList();
                string priority = prior.ToString();
                if (entity != null)
                {
                    if (priority == "Low")
                        return "Blue";
                    else if (priority == "Medium")
                        return "Yellow";
                    else if (priority == "High")
                        return "Red";
                }
                return "Black";
            }
    }
}
