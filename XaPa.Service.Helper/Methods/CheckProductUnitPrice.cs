using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Helper.Constants;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Helper.Methods
{
    public class CheckProductUnitPrice : AddProductValidationBase
    {
        public override void ExecuteProcess(NewProductWM productModel)
        {
            if (productModel.Product.UnitPrice == 0)
            {
                throw new Exception(ErrorMessageConstants.ProductUnitPriceNotDefined);
            }
            else
            {
                IsValid = true;
            }            
        }
    }
}