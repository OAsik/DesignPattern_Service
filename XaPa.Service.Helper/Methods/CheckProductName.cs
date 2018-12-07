using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Helper.Constants;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Helper.Methods
{
    public class CheckProductName : AddProductValidationBase
    {
        public override void ExecuteProcess(NewProductWM productModel)
        {
            IsValid = string.IsNullOrEmpty(productModel.Product.ProductName) ? throw new Exception(ErrorMessageConstants.ProductNameNotDefined) : true;
        }
    }
}