using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Helper.Methods
{
    public abstract class AddProductValidationBase
    {
        public bool IsValid;

        protected AddProductValidationBase NextValidation;

        public void SetNextValidation(AddProductValidationBase validation)
        {
            NextValidation = validation;
        }

        public void Execute(NewProductWM productModel)
        {
            ExecuteProcess(productModel);

            if (NextValidation != null)
            {
                NextValidation.IsValid = IsValid;
                NextValidation.Execute(productModel);
            }
        }

        public abstract void ExecuteProcess(NewProductWM productModel);
    }
}