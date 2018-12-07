using System;

namespace XaPa.Service.Helper.Constants
{
    public static class ErrorMessageConstants
    {
        public static string UserNameNotFound = "Please enter a user name.";
        public static string UserPasswordNotFound = "Please enter your password.";
        public static string UserNotFound = "User not found.";
        public static string MinusUnitsOnOrder = "Product stock level cannot be reduced under 0.";
        public static string UsersOrderDetailIDNotFound = "Please specify an order number.";
        public static string StockAmountEmpty = "Please provide a stock control level.";
        public static string ProductImagesPathNotFound = "Please provide a file path for the picture of the product.";
        public static string ProductCategoryNotDefined = "Product's category number should be defined.";
        public static string ProductNameNotDefined = "Product's name should be given.";
        public static string ProductUnitPriceNotDefined = "Product's unit price should be defined.";
        public static string ProductNotFound = "Requested product cannot be found.";
        public static string ProductIDNotDefined = "Please provide a product number.";
    }
}