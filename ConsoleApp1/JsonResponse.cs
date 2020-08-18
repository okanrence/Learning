using DataStructuresAndAlgos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgos
{

    public class JsonObject
    {
        public string ResponseCode { get; set; }
        public string AccessID { get; set; }
        public Servicelist ServiceList { get; set; }
        public string ResponseDescription { get; set; }
        public string RequestUniqueID { get; set; }
    }

    public class Servicelist
    {
        public string[] ServiceID { get; set; }
        public string[] ServiceName { get; set; }
        public string[] ServiceCode { get; set; }
        public string[] ServiceType { get; set; }
        public string[] ServiceDenominationID { get; set; }
        public string[] MinAmount { get; set; }
        public string[] MaxAmount { get; set; }
        public string[] IsActive { get; set; }
        public string[] InternalModuleID { get; set; }
        public string[] ModuleName { get; set; }
        public string[] ServiceImage { get; set; }
        public string[] ServiceIconWeb { get; set; }
        public string[] ServiceIconMob { get; set; }
    }
    public class ServiceObject
    {
        public string ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceType { get; set; }
        public string ServiceDenominationID { get; set; }
        public string MinAmount { get; set; }
        public string MaxAmount { get; set; }
        public string IsActive { get; set; }
        public string InternalModuleID { get; set; }
        public string ModuleName { get; set; }
        public string ServiceImage { get; set; }
        public string ServiceIconWeb { get; set; }
        public string ServiceIconMob { get; set; }
    }

    public class TestService
    {
        public List<ServiceObject> BuildObject(Servicelist servicelist)
        {
            var newList = new List<ServiceObject>();
            int count = servicelist.GetType().GetProperties().Count();


            for (int i = 0; i <= 7; i++)
            {
                var newObject = new ServiceObject();
                newObject.InternalModuleID = servicelist.InternalModuleID[i];
                newObject.IsActive = servicelist.IsActive[i];
                newObject.MaxAmount = servicelist.MaxAmount[i];
                newObject.MinAmount = servicelist.MinAmount[i];
                newObject.ModuleName = servicelist.ModuleName[i];
                newObject.ServiceCode = servicelist.ServiceCode[i];
                newObject.ServiceDenominationID = servicelist.ServiceDenominationID[i];
                newObject.ServiceIconMob = servicelist.ServiceIconMob[i];
                newObject.ServiceIconWeb = servicelist.ServiceIconWeb[i];
                newObject.ServiceID = servicelist.ServiceID[i];
                newObject.ServiceImage = servicelist.ServiceImage[i];
                newObject.ServiceName = servicelist.ServiceName[i];
                newObject.ServiceType = servicelist.ServiceType[i];
                newList.Add(newObject);
            }
            return newList;
        }
           

        
    }
}


