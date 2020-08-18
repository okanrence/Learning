using System;
using System.Collections.Generic;
using System.Text;

namespace InputMap
{



    public class InputObject
    {
        public Productlist ProductList { get; set; }
        public string ResponseCode { get; set; }
        public string AccessID { get; set; }
        public string ResponseDescription { get; set; }
        public string RequestUniqueID { get; set; }
    }

    public class Productlist
    {
        public string[] ProductID { get; set; }
        public string[] ProductName { get; set; }
        public string[] ProductCode { get; set; }
        public string[] ProductType { get; set; }
        public string[] Description { get; set; }
        public object[] ImageCode { get; set; }
        public string[] VendorProductID { get; set; }
        public Profileinfo[] ProfileInfo { get; set; }
        public string[] FieldCount { get; set; }
        public string[] IsProductActive { get; set; }
        public string[] SystemServiceID { get; set; }
        public string[] SystemServiceName { get; set; }
        public string[] SystemModuleID { get; set; }
        public string[] SystemModuleName { get; set; }
        public string[] OperatorID { get; set; }
        public string[] OperatorName { get; set; }
        public string[] ServiceOrder { get; set; }
        public string[] ImageName { get; set; }
        public string[] ImageType { get; set; }
        public string[] ImageID { get; set; }
        public string[] ServiceImage { get; set; }
        public string[] ServiceIconWeb { get; set; }
        public string[] ServiceIconMob { get; set; }
        public string[] CategoryID { get; set; }
        public string[] CategoryName { get; set; }
        public Productdenominationlist[][] ProductDenominationList { get; set; }
        public Taxinfo[] TaxInfo { get; set; }
        public string[] BarCode { get; set; }
    }

    public class Profileinfo
    {
        public Fieldinfo FieldInfo { get; set; }
        public string MinorCurrency { get; set; }
        public Notificationinfo NotificationInfo { get; set; }
        public Refundinfo RefundInfo { get; set; }
    }

    public class Fieldinfo
    {
        public Field1 Field1 { get; set; }
        public Field2 Field2 { get; set; }
    }

    public class Field1
    {
        public string Values { get; set; }
        public string FieldKey { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public Validation Validation { get; set; }
        public string TxReference { get; set; }
        public string ResponseDescription { get; set; }
    }

    public class Validation
    {
        public string Required { get; set; }
        public string MaxLength { get; set; }
        public string MinLength { get; set; }
        public string Content { get; set; }
        public string RegularExpression { get; set; }
    }

    public class Field2
    {
        public string Values { get; set; }
        public string FieldKey { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public Validation1 Validation { get; set; }
        public string TxReference { get; set; }
        public string ResponseDescription { get; set; }
    }

    public class Validation1
    {
        public string Required { get; set; }
        public string MaxLength { get; set; }
        public string MinLength { get; set; }
        public string Content { get; set; }
        public string RegularExpression { get; set; }
    }

    public class Notificationinfo
    {
        public Email Email { get; set; }
        public Phone Phone { get; set; }
        public Fcm Fcm { get; set; }
    }

    public class Email
    {
    }

    public class Phone
    {
        public string Pattern { get; set; }
        public string Title { get; set; }
        public Validation2 Validation { get; set; }
        public string ResponseDescription { get; set; }
    }

    public class Validation2
    {
        public string Required { get; set; }
        public string MaxLength { get; set; }
        public string MinLength { get; set; }
    }

    public class Fcm
    {
    }

    public class Refundinfo
    {
    }

    public class Productdenominationlist
    {
        public string ProductID { get; set; }
        public string ProductDenominationID { get; set; }
        public string Description { get; set; }
        public string MinAmount { get; set; }
        public string MaxAmount { get; set; }
        public string IsProductDenominationActive { get; set; }
        public Feecommission FeeCommission { get; set; }
    }

    public class Feecommission
    {
        public string commissionTypeEnum { get; set; }
        public int surchargeValueAsBigDecimal { get; set; }
        public int CommissionType { get; set; }
        public string SurchargeType { get; set; }
        public string SurchargeValue { get; set; }
        public string Level1 { get; set; }
    }

    public class Taxinfo
    {
    }

}
