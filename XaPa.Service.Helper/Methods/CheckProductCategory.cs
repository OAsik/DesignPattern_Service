using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Helper.Constants;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Helper.Methods
{
    public class CheckProductCategory : AddProductValidationBase
    {
        public override void ExecuteProcess(NewProductWM productModel)
        {
            if (productModel.Product.CategoryID == 0)
            {
                throw new Exception(ErrorMessageConstants.ProductCategoryNotDefined);
            }
            else
            {
                IsValid = true;
            }
        }
    }
}