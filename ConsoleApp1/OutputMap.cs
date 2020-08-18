using Microsoft.CognitiveServices.Speech.Audio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OutputMap
{

    public class OutputObject
    {
        public ICollection<ProductList> ProductList { get; set; }
        public string ResponseCode { get; set; }
        public string AccessID { get; set; }
        public string ResponseDescription { get; set; }
        public string RequestUniqueID { get; set; }

        public OutputObject()
        {
            ProductList = new List<ProductList>();
        }
    }

    public class ProductList
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductType { get; set; }
        public string Description { get; set; }
        public object ImageCode { get; set; }
        public string VendorProductID { get; set; }
        public InputMap.Profileinfo ProfileInfo { get; set; }
        public string FieldCount { get; set; }
        public string IsProductActive { get; set; }
        public string SystemServiceID { get; set; }
        public string SystemServiceName { get; set; }
        public string SystemModuleID { get; set; }
        public string SystemModuleName { get; set; }
        public string OperatorID { get; set; }
        public string OperatorName { get; set; }
        public string ServiceOrder { get; set; }
        public string ImageName { get; set; }
        public string ImageType { get; set; }
        public string ImageID { get; set; }
        public string ServiceImage { get; set; }
        public string ServiceIconWeb { get; set; }
        public string ServiceIconMob { get; set; }
        public object CategoryID { get; set; }
        public object CategoryName { get; set; }
        public InputMap.Productdenominationlist[] ProductDenominationList { get; set; }
        public InputMap.Taxinfo TaxInfo { get; set; }
        public string BarCode { get; set; }
    }



    public class TestService
    {
        public OutputObject BuildObject(InputMap.InputObject input)
        {

            var outputObject = new OutputObject()
            {
                AccessID = input.AccessID,
                RequestUniqueID = input.RequestUniqueID,
                ResponseCode = input.ResponseCode,
                ResponseDescription = input.ResponseDescription
            };

            var servicelist = input.ProductList;

            for (int i = 0; i <= 9; i++)
            {
                var newObject = new ProductList
                {
                    BarCode = servicelist.BarCode.Length - 1 >= i ? servicelist.BarCode[i] : null,
                    CategoryID = servicelist.CategoryID.Length - 1 >= i ? servicelist.CategoryID[i] : null,
                    CategoryName = servicelist.CategoryName.Length - 1 >= i ? servicelist.CategoryName[i] : null,
                    Description = servicelist.Description.Length - 1 >= i ? servicelist.Description[i] : null,
                    FieldCount = servicelist.FieldCount.Length - 1 >= i ? servicelist.FieldCount[i] : null,
                    ImageCode = servicelist.ImageCode.Length - 1 >= i ? servicelist.ImageCode[i] : null,
                    ImageID = servicelist.ImageID.Length - 1 >= i ? servicelist.ImageID[i] : null,
                    ImageName = servicelist.ImageName.Length - 1 >= i ? servicelist.ImageName[i] : null,
                    ImageType = servicelist.ImageType.Length - 1 >= i ? servicelist.ImageType[i] : null,
                    IsProductActive = servicelist.IsProductActive.Length - 1 >= i ? servicelist.IsProductActive[i] : null,
                    OperatorID = servicelist.OperatorID.Length - 1 >= i ? servicelist.OperatorID[i] : null,
                    OperatorName = servicelist.OperatorName.Length - 1 >= i ? servicelist.OperatorName[i] : null,
                    ProductCode = servicelist.ProductCode.Length - 1 >= i ? servicelist.ProductCode[i] : null,
                    ProductDenominationList = servicelist.ProductDenominationList.Length - 1 >= i ? servicelist.ProductDenominationList[i] : null,
                    ProductID = servicelist.ProductID.Length - 1 >= i ? servicelist.ProductID[i] : null,
                    ProductName = servicelist.ProductName.Length - 1 >= i ? servicelist.ProductName[i] : null,
                    ProductType = servicelist.ProductType.Length - 1 >= i ? servicelist.ProductType[i] : null,
                    ProfileInfo = servicelist.ProfileInfo.Length - 1 >= i ? servicelist.ProfileInfo[i] : null,
                    ServiceIconMob = servicelist.ServiceIconMob.Length - 1 >= i ? servicelist.ServiceIconMob[i] : null,
                    ServiceIconWeb = servicelist.ServiceIconWeb.Length - 1 >= i ? servicelist.ServiceIconWeb[i] : null,
                    ServiceImage = servicelist.ServiceImage.Length - 1 >= i ? servicelist.ServiceImage[i] : null,
                    ServiceOrder = servicelist.ServiceOrder.Length - 1 >= i ? servicelist.ServiceOrder[i] : null,
                    SystemModuleID = servicelist.SystemModuleID.Length - 1 >= i ? servicelist.SystemModuleID[i] : null,
                    SystemModuleName = servicelist.SystemModuleName.Length - 1 >= i ? servicelist.SystemModuleName[i] : null,
                    SystemServiceID = servicelist.SystemServiceID.Length - 1 >= i ? servicelist.SystemServiceID[i] : null,
                    SystemServiceName = servicelist.SystemServiceName.Length - 1 >= i ? servicelist.SystemServiceName[i] : null,
                    TaxInfo = servicelist.TaxInfo.Length - 1 >= i ? servicelist.TaxInfo[i] : null,
                    VendorProductID = servicelist.VendorProductID.Length - 1 >= i ? servicelist.VendorProductID[i] : null
                };

                outputObject.ProductList.Add(newObject);
            }

            return outputObject;
        }


        public InputMap.InputObject GetData()
        {
            var reader = File.ReadAllText("C:\\Users\\Olanrewaju\\source\\repos\\ConsoleApp1\\ConsoleApp1\\json-data.json");

            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<InputMap.InputObject>(reader);

            return data;
        }


    }
}

