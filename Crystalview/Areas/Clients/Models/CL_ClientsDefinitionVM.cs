using System;
using System.Data;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Global.Globalization;
using Global;
using Global.Models;
using Global.Services;
using System.ComponentModel;
using FinanceCore;
using System.Collections.Generic;
using System.Threading;
using NLog;
using System.Linq;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using NonFactors.Mvc.Lookup;
using WTEG.Core;
using WTEG.TagHelpers;
using Microsoft.Extensions.Localization;
using LogLevel = NLog.LogLevel;

namespace FinanceCore.DBModels
{
    #region create table  class 
    /// <summary>
    /// class created tblCL_ClientsDefinition 
    /// </summary>
    public class tblCL_ClientsDefinition
    {
        #region base calss definitions
        [Display(Name = "CL_ClientsDefinition-ClientCode", Description = "CL_ClientsDefinition-Client Code.")]
        [Required(ErrorMessage = "ClientCode is required.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int32 ClientCode { get; set; }

        [Display(Name = "CL_ClientsDefinition-ClientNameA", Description = "CL_ClientsDefinition-Client Name A.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "ClientNameA is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String ClientNameA { get; set; }

        [Display(Name = "CL_ClientsDefinition-ClientNameE", Description = "CL_ClientsDefinition-Client Name E.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "ClientNameE is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String ClientNameE { get; set; }

        [Display(Name = "CL_ClientsDefinition-ClientAddressA", Description = "CL_ClientsDefinition-Client Address A.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String ClientAddressA { get; set; }

        [Display(Name = "CL_ClientsDefinition-ClientAddressE", Description = "CL_ClientsDefinition-Client Address E.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String ClientAddressE { get; set; }

        [Display(Name = "CL_ClientsDefinition-PersoninCharge", Description = "CL_ClientsDefinition-Personin Charge.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String PersoninCharge { get; set; }

        [Display(Name = "CL_ClientsDefinition-PersonMobile", Description = "CL_ClientsDefinition-Person Mobile.")]
        [LookupColumn(Hidden = false)]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "InvalidPhone")]
        public String PersonMobile { get; set; }

        // prepare lookup data for the dynamic form part
        //public SelectList lsSalesCode => new CL_SalesDefinitionVM().GetCL_SalesDefinitionForLkp();
        //[ItemsSource(ItemsProperty = nameof(lsSalesCode), ChoicesType = ChoicesTypes.DEFAULT)]
        //[Display(Name = "CL_ClientsDefinition-SalesCode", Description = "CL_ClientsDefinition-Sales Code.")]
        //[LookupColumn(Hidden = false)]
        //[DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        //public Int16 SalesCode { get; set; }

        [Display(Name = "CL_ClientsDefinition-Tel1", Description = "CL_ClientsDefinition-Tel1.")]
        [LookupColumn(Hidden = false)]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String Tel1 { get; set; }

        [Display(Name = "CL_ClientsDefinition-Tel2", Description = "CL_ClientsDefinition-Tel2.")]
        [LookupColumn(Hidden = false)]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String Tel2 { get; set; }

        [Display(Name = "CL_ClientsDefinition-Tel3", Description = "CL_ClientsDefinition-Tel3.")]
        [LookupColumn(Hidden = false)]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String Tel3 { get; set; }

        [Display(Name = "CL_ClientsDefinition-Mobile", Description = "CL_ClientsDefinition-Mobile.")]
        [LookupColumn(Hidden = false)]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "InvalidPhone")]
        public String Mobile { get; set; }

        [Display(Name = "CL_ClientsDefinition-E_Mail", Description = "CL_ClientsDefinition-E_ Mail.")]
        [LookupColumn(Hidden = false)]
        [StringLength(30, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String E_Mail { get; set; }

        [Display(Name = "CL_ClientsDefinition-CollectorCode", Description = "CL_ClientsDefinition-Collector Code.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 CollectorCode { get; set; }

        // prepare lookup data for the dynamic form part
        //public SelectList lsActivityCode => new CL_ActivityDefinitionVM().GetCL_ActivityDefinitionForLkp();
        //[ItemsSource(ItemsProperty = nameof(lsActivityCode), ChoicesType = ChoicesTypes.DEFAULT)]
        [Display(Name = "CL_ClientsDefinition-ActivityCode", Description = "CL_ClientsDefinition-Activity Code.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 ActivityCode { get; set; }

        [Display(Name = "CL_ClientsDefinition-ActivityNameA", Description = "CL_ClientsDefinition-Activity Name A.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "ActivityNameA is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String ActivityNameA { get; set; }

        [Display(Name = "CL_ClientsDefinition-ActivityNameE", Description = "CL_ClientsDefinition-Activity Name E.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "ActivityNameE is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String ActivityNameE { get; set; }

        // prepare lookup data for the dynamic form part
        //public SelectList lsAreaCode => new CL_AreaDefinitionVM().GetCL_AreaDefinitionForLkp();
        //[ItemsSource(ItemsProperty = nameof(lsAreaCode), ChoicesType = ChoicesTypes.DEFAULT)]
        [Display(Name = "CL_ClientsDefinition-AreaCode", Description = "CL_ClientsDefinition-Area Code.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 AreaCode { get; set; }

        [Display(Name = "CL_ClientsDefinition-AreaNameA", Description = "CL_ClientsDefinition-Area Name A.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "AreaNameA is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String AreaNameA { get; set; }

        [Display(Name = "CL_ClientsDefinition-AreaNameE", Description = "CL_ClientsDefinition-Area Name E.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "AreaNameE is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String AreaNameE { get; set; }

        // prepare lookup data for the dynamic form part
        // public SelectList lsKindCode => new CL_ClientsKindVM().GetCL_ClientsKindForLkp();
        //[ItemsSource(ItemsProperty = nameof(lsKindCode), ChoicesType = ChoicesTypes.DEFAULT)]
        [Display(Name = "CL_ClientsDefinition-KindCode", Description = "CL_ClientsDefinition-Kind Code.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 KindCode { get; set; }

        [Display(Name = "CL_ClientsDefinition-KindNameA", Description = "CL_ClientsDefinition-Kind Name A.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "KindNameA is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String KindNameA { get; set; }

        [Display(Name = "CL_ClientsDefinition-KindNameE", Description = "CL_ClientsDefinition-Kind Name E.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "KindNameE is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String KindNameE { get; set; }

        // prepare lookup data for the dynamic form part
        //public SelectList lsTaxCode => new GE_TaxesVM().GetGE_TaxesForLkp();
        //[ItemsSource(ItemsProperty = nameof(lsTaxCode), ChoicesType = ChoicesTypes.DEFAULT)]
        [Display(Name = "CL_ClientsDefinition-TaxCode", Description = "CL_ClientsDefinition-Tax Code.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 TaxCode { get; set; }

        [Display(Name = "CL_ClientsDefinition-TaxMissionA", Description = "CL_ClientsDefinition-Tax Mission A.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String TaxMissionA { get; set; }

        [Display(Name = "CL_ClientsDefinition-TaxMissionE", Description = "CL_ClientsDefinition-Tax Mission E.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String TaxMissionE { get; set; }

        [Display(Name = "CL_ClientsDefinition-TaxAddress", Description = "CL_ClientsDefinition-Tax Address.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String TaxAddress { get; set; }

        [Display(Name = "CL_ClientsDefinition-TaxCardNo", Description = "CL_ClientsDefinition-Tax Card No.")]
        [LookupColumn(Hidden = false)]
        [StringLength(30, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String TaxCardNo { get; set; }

        [Display(Name = "CL_ClientsDefinition-TaxFileNo", Description = "CL_ClientsDefinition-Tax File No.")]
        [LookupColumn(Hidden = false)]
        [StringLength(30, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String TaxFileNo { get; set; }

        [Display(Name = "CL_ClientsDefinition-Exmpted", Description = "CL_ClientsDefinition-Exmpted.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 Exmpted { get; set; }

        [Display(Name = "CL_ClientsDefinition-ExmptedDate", Description = "CL_ClientsDefinition-Exmpted Date.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.Date, ErrorMessage = "InvalidDate")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? ExmptedDate { get; set; }
        // add full date wit hdate and time part to reading 
        public String? FullExmptedDate { get; set; }

        [Display(Name = "CL_ClientsDefinition-SelectPrice", Description = "CL_ClientsDefinition-Select Price.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 SelectPrice { get; set; }

        // prepare lookup data for the dynamic form part
        public SelectList lsPaymentCode => new CL_PaymentConditionVM().GetCL_PaymentConditionForLkp();
        [ItemsSource(ItemsProperty = nameof(lsPaymentCode), ChoicesType = ChoicesTypes.DEFAULT)]
        [Display(Name = "CL_ClientsDefinition-PaymentCode", Description = "CL_ClientsDefinition-Payment Code.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 PaymentCode { get; set; }

        [Display(Name = "CL_ClientsDefinition-PaymentNameA", Description = "CL_ClientsDefinition-Payment Name A.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "PaymentNameA is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String PaymentNameA { get; set; }

        [Display(Name = "CL_ClientsDefinition-PaymentNameE", Description = "CL_ClientsDefinition-Payment Name E.")]
        [LookupColumn(Hidden = false)]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        [Required(ErrorMessage = "PaymentNameE is required.")]
        [RegularExpression(@"^[^<>`~!/@\#}$%:;)(_^{&*=|'+]+$", ErrorMessage = "InvalidCharacters")]
        public String PaymentNameE { get; set; }

        [Display(Name = "CL_ClientsDefinition-CommercialDed", Description = "CL_ClientsDefinition-Commercial Ded.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Decimal CommercialDed { get; set; }

        [Display(Name = "CL_ClientsDefinition-AllowenceDed", Description = "CL_ClientsDefinition-Allowence Ded.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Decimal AllowenceDed { get; set; }

        [Display(Name = "CL_ClientsDefinition-CashDed", Description = "CL_ClientsDefinition-Cash Ded.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Decimal CashDed { get; set; }

        [Display(Name = "CL_ClientsDefinition-CreditLimitPer", Description = "CL_ClientsDefinition-Credit Limit Per.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Decimal CreditLimitPer { get; set; }

        [Display(Name = "CL_ClientsDefinition-CreditLimitValue", Description = "CL_ClientsDefinition-Credit Limit Value.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Decimal CreditLimitValue { get; set; }

        [Display(Name = "CL_ClientsDefinition-LinkWGL", Description = "CL_ClientsDefinition-Link WG L.")]
        [LookupColumn(Hidden = false)]
        [StringLength(36, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String LinkWGL { get; set; }

        [Display(Name = "CL_ClientsDefinition-CostCenter", Description = "CL_ClientsDefinition-Cost Center.")]
        [LookupColumn(Hidden = false)]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String CostCenter { get; set; }

        [Display(Name = "CL_ClientsDefinition-DirectCode", Description = "CL_ClientsDefinition-Direct Code.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 DirectCode { get; set; }

        // prepare lookup data for the dynamic form part
        //public SelectList lsCorporateCode => new CL_ClientsGroupVM().GetCL_ClientsGroupForLkp();
        //[ItemsSource(ItemsProperty = nameof(lsCorporateCode), ChoicesType = ChoicesTypes.DEFAULT)]
        //[Display(Name = "CL_ClientsDefinition-CorporateCode", Description = "CL_ClientsDefinition-Corporate Code.")]
        //[LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 CorporateCode { get; set; }

        [Display(Name = "CL_ClientsDefinition-TargetQty", Description = "CL_ClientsDefinition-Target Qty.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public Decimal TargetQty { get; set; }

        [Display(Name = "CL_ClientsDefinition-ClientNature", Description = "CL_ClientsDefinition-Client Nature.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 ClientNature { get; set; }

        [Display(Name = "CL_ClientsDefinition-OriginCountry", Description = "CL_ClientsDefinition-Origin Country.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 OriginCountry { get; set; }

        [Display(Name = "CL_ClientsDefinition-RegistrationNo", Description = "CL_ClientsDefinition-Registration No.")]
        [LookupColumn(Hidden = false)]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String RegistrationNo { get; set; }

        [Display(Name = "CL_ClientsDefinition-CountryCode", Description = "CL_ClientsDefinition-Country Code.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 CountryCode { get; set; }

        [Display(Name = "CL_ClientsDefinition-r_Country", Description = "CL_ClientsDefinition-r_ Country.")]
        [LookupColumn(Hidden = false)]
        [StringLength(2, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String r_Country { get; set; }

        [Display(Name = "CL_ClientsDefinition-r_Governate", Description = "CL_ClientsDefinition-r_ Governate.")]
        [LookupColumn(Hidden = false)]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "FieldTooLong")]
        public String r_Governate { get; set; }

        [Display(Name = "CL_ClientsDefinition-Status", Description = "CL_ClientsDefinition-Status.")]
        [LookupColumn(Hidden = false)]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public Int16 Status { get; set; }

        [Display(Name = "CL_ClientsDefinition-TimeStamp", Description = "CL_ClientsDefinition-Time Stamp.")]
        [LookupColumn(Hidden = false)]
        [DataType(DataType.Date, ErrorMessage = "InvalidDate")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? TimeStamp { get; set; }
        // add full date wit hdate and time part to reading 
        public String? FullTimeStamp { get; set; }

        #region foreign key child realtions to get parent names
        [Display(Name = "CL_ClientsDefinition-ActivityCode", Description = "CL_ClientsDefinition-Activity Code.")]
        [LookupColumn(Hidden = false)]
        public string? ActivityCodeName { get; set; }
        [Display(Name = "CL_ClientsDefinition-AreaCode", Description = "CL_ClientsDefinition-Area Code.")]
        [LookupColumn(Hidden = false)]
        public string? AreaCodeName { get; set; }
        [Display(Name = "CL_ClientsDefinition-CorporateCode", Description = "CL_ClientsDefinition-Corporate Code.")]
        [LookupColumn(Hidden = false)]
        public string? CorporateCodeName { get; set; }
        [Display(Name = "CL_ClientsDefinition-KindCode", Description = "CL_ClientsDefinition-Kind Code.")]
        [LookupColumn(Hidden = false)]
        public string? KindCodeName { get; set; }
        [Display(Name = "CL_ClientsDefinition-PaymentCode", Description = "CL_ClientsDefinition-Payment Code.")]
        [LookupColumn(Hidden = false)]
        public string? PaymentCodeName { get; set; }
        [Display(Name = "CL_ClientsDefinition-SalesCode", Description = "CL_ClientsDefinition-Sales Code.")]
        [LookupColumn(Hidden = false)]
        public string? SalesCodeName { get; set; }
        [Display(Name = "CL_ClientsDefinition-TaxCode", Description = "CL_ClientsDefinition-Tax Code.")]
        [LookupColumn(Hidden = false)]
        public string? TaxCodeName { get; set; }
        #endregion
        #endregion
        #region lookupname
        public string lookupName
        {
            get
            {
                return ClientCode.ToString();
                //        return LCNumber + "--" + SupplierIDName;
            }
            set { }
        }
        #endregion
    }
    #endregion
    #region create metModelviewa class 
    public class CL_ClientsDefinitionVM : BaseVM
    {
        public tblCL_ClientsDefinition? CL_ClientsDefinition;
        #region helper fill row
        private static tblCL_ClientsDefinition ReadSingleRow(IDataRecord reader)
        {
            var dataRecord = new tblCL_ClientsDefinition
            {
                ClientCode = reader.GetValue<Int32>("ClientCode"),
                ClientNameA = reader.GetValue<string>("ClientNameA"),
                ClientNameE = reader.GetValue<string>("ClientNameE"),
                ClientAddressA = reader.GetValue<string>("ClientAddressA"),
                ClientAddressE = reader.GetValue<string>("ClientAddressE"),
                PersoninCharge = reader.GetValue<string>("PersoninCharge"),
                PersonMobile = reader.GetValue<string>("PersonMobile"),
                //SalesCode = reader.GetValue<Int16>("SalesCode"),
                Tel1 = reader.GetValue<string>("Tel1"),
                Tel2 = reader.GetValue<string>("Tel2"),
                Tel3 = reader.GetValue<string>("Tel3"),
                Mobile = reader.GetValue<string>("Mobile"),
                E_Mail = reader.GetValue<string>("E_Mail"),
                CollectorCode = reader.GetValue<Int16>("CollectorCode"),
                ActivityCode = reader.GetValue<Int16>("ActivityCode"),
                ActivityNameA = reader.GetValue<string>("ActivityNameA"),
                ActivityNameE = reader.GetValue<string>("ActivityNameE"),
                AreaCode = reader.GetValue<Int16>("AreaCode"),
                AreaNameA = reader.GetValue<string>("AreaNameA"),
                AreaNameE = reader.GetValue<string>("AreaNameE"),
                KindCode = reader.GetValue<Int16>("KindCode"),
                KindNameA = reader.GetValue<string>("KindNameA"),
                KindNameE = reader.GetValue<string>("KindNameE"),
                TaxCode = reader.GetValue<Int16>("TaxCode"),
                TaxMissionA = reader.GetValue<string>("TaxMissionA"),
                TaxMissionE = reader.GetValue<string>("TaxMissionE"),
                TaxAddress = reader.GetValue<string>("TaxAddress"),
                TaxCardNo = reader.GetValue<string>("TaxCardNo"),
                TaxFileNo = reader.GetValue<string>("TaxFileNo"),
                Exmpted = reader.GetValue<Int16>("Exmpted"),
                ExmptedDate = DateTime.TryParse(reader.GetValue<string>("ExmptedDate"), out DateTime ExmptedDatedt) ? ExmptedDatedt : null,
                FullExmptedDate = reader.GetValue<string>("FullExmptedDate"),
                SelectPrice = reader.GetValue<Int16>("SelectPrice"),
                PaymentCode = reader.GetValue<Int16>("PaymentCode"),
                PaymentNameA = reader.GetValue<string>("PaymentNameA"),
                PaymentNameE = reader.GetValue<string>("PaymentNameE"),
                CommercialDed = reader.GetValue<decimal>("CommercialDed"),
                AllowenceDed = reader.GetValue<decimal>("AllowenceDed"),
                CashDed = reader.GetValue<decimal>("CashDed"),
                CreditLimitPer = reader.GetValue<decimal>("CreditLimitPer"),
                CreditLimitValue = reader.GetValue<decimal>("CreditLimitValue"),
                LinkWGL = reader.GetValue<string>("LinkWGL"),
                CostCenter = reader.GetValue<string>("CostCenter"),
                DirectCode = reader.GetValue<Int16>("DirectCode"),
                CorporateCode = reader.GetValue<Int16>("CorporateCode"),
                TargetQty = reader.GetValue<decimal>("TargetQty"),
                ClientNature = reader.GetValue<Int16>("ClientNature"),
                OriginCountry = reader.GetValue<Int16>("OriginCountry"),
                RegistrationNo = reader.GetValue<string>("RegistrationNo"),
                CountryCode = reader.GetValue<Int16>("CountryCode"),
                r_Country = reader.GetValue<string>("r_Country"),
                r_Governate = reader.GetValue<string>("r_Governate"),
                Status = reader.GetValue<Int16>("Status"),
                TimeStamp = DateTime.TryParse(reader.GetValue<string>("TimeStamp"), out DateTime TimeStampdt) ? TimeStampdt : null,
                FullTimeStamp = reader.GetValue<string>("FullTimeStamp"),
                #region foreign key child realtions to get parent names
                ActivityCodeName = reader.GetValue<string>("ActivityCodeName"),
                AreaCodeName = reader.GetValue<string>("AreaCodeName"),
                CorporateCodeName = reader.GetValue<string>("CorporateCodeName"),
                KindCodeName = reader.GetValue<string>("KindCodeName"),
                PaymentCodeName = reader.GetValue<string>("PaymentCodeName"),
                SalesCodeName = reader.GetValue<string>("SalesCodeName"),
                TaxCodeName = reader.GetValue<string>("TaxCodeName"),
                #endregion


            };

            return dataRecord;
        }
        #endregion

        #region selection helper functions
        public SelectList GetCL_ClientsDefinitionForLkp()
        {
            var LookupData = GetAll()
                .ToEnumerable()
                ;
            return new SelectList(LookupData, "ID", "lookupName");
        }

        public async Task<IEnumerable<SelectListItem>> GetCL_ClientsDefinitionForLkpAsync()
        {
            List<SelectListItem> LookupData = await GetAll()
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.ClientCode.ToString(),
                        Text = n.lookupName
                    }).ToListAsync();
            return LookupData;
        }
        public async IAsyncEnumerable<tblCL_ClientsDefinition> GetAll()
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspCL_ClientsDefinitionSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        yield return ReadSingleRow((IDataRecord)reader);
                    }
                }
            }
        }


        public async Task<int> GetCount()
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "SELECT IsNull(COUNT(*),1) FROM CL_ClientsDefinition";
                cmd.CommandType = CommandType.Text;
                Int32 count = (int)await cmd.ExecuteScalarAsync();

                return count;


            }
        }
        public async IAsyncEnumerable<tblCL_ClientsDefinition> GetPaged(int Page)
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspCL_ClientsDefinitionPagedSelect";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@Page", Page);
                cmd.Parameters.AddWithValue("@RecsPerPage", 20);
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        yield return ReadSingleRow((IDataRecord)reader);
                    }
                }
            }
        }


        public tblCL_ClientsDefinition GetEmpty()
        {

            return new tblCL_ClientsDefinition
            {
                ClientCode = 0,
                ClientNameA = "",
                ClientNameE = "",
                ClientAddressA = "",
                ClientAddressE = "",
                PersoninCharge = "",
                PersonMobile = "",
                //                SalesCode = 0,
                Tel1 = "",
                Tel2 = "",
                Tel3 = "",
                Mobile = "",
                E_Mail = "",
                CollectorCode = 0,
                ActivityCode = 0,
                ActivityNameA = "",
                ActivityNameE = "",
                AreaCode = 0,
                AreaNameA = "",
                AreaNameE = "",
                KindCode = 0,
                KindNameA = "",
                KindNameE = "",
                TaxCode = 0,
                TaxMissionA = "",
                TaxMissionE = "",
                TaxAddress = "",
                TaxCardNo = "",
                TaxFileNo = "",
                Exmpted = 0,
                ExmptedDate = DateTime.Today,
                SelectPrice = 0,
                PaymentCode = 0,
                PaymentNameA = "",
                PaymentNameE = "",
                CommercialDed = 0,
                AllowenceDed = 0,
                CashDed = 0,
                CreditLimitPer = 0,
                CreditLimitValue = 0,
                LinkWGL = "",
                CostCenter = "",
                DirectCode = 0,
                CorporateCode = 0,
                TargetQty = 0,
                ClientNature = 0,
                OriginCountry = 0,
                RegistrationNo = "",
                CountryCode = 0,
                r_Country = "",
                r_Governate = "",
                Status = 0,
                TimeStamp = DateTime.Today,
            };
        }
        public async Task<string> GetNameByID(int? id)
        {

            var ResultOne = await Find(id);
            if (ResultOne == null)
            {
                return "Unknown";
            }
            return ResultOne.ClientNameA.ToString();
        }
        public async Task<string> GetNameByID(string id)
        {
            return await GetNameByID(int.Parse(id));
        }

        public async Task<tblCL_ClientsDefinition> Find(int? id)
        {

            await using (var conn = new SqlConnection(strConnection))
            await using (var cmd = conn.CreateCommand())
            {
                await conn.OpenAsync();
                cmd.CommandText = "uspCL_ClientsDefinitionSelectSingle";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                cmd.Parameters.AddWithValue("@ID", id);
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return ReadSingleRow((IDataRecord)reader);
                    }
                }
                return GetEmpty();
            }

        }
        #endregion

        #region CRUD
        public async Task<int> Insert()
        {

            try
            {
                await using (var conn = new SqlConnection(strConnection))
                await using (var cmd = conn.CreateCommand())
                {
                    await conn.OpenAsync();
                    cmd.CommandText = "uspCL_ClientsDefinitionEdit";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var ReturnID = new SqlParameter();
                    ReturnID.ParameterName = "@ID";
                    ReturnID.Direction = ParameterDirection.Output;
                    ReturnID.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(ReturnID);

                    cmd.Parameters.AddWithValue("@ClientNameA", CL_ClientsDefinition.ClientNameA);
                    cmd.Parameters.AddWithValue("@ClientNameE", CL_ClientsDefinition.ClientNameE);
                    cmd.Parameters.AddWithValue("@ClientAddressA", CL_ClientsDefinition.ClientAddressA);
                    cmd.Parameters.AddWithValue("@ClientAddressE", CL_ClientsDefinition.ClientAddressE);
                    cmd.Parameters.AddWithValue("@PersoninCharge", CL_ClientsDefinition.PersoninCharge);
                    cmd.Parameters.AddWithValue("@PersonMobile", CL_ClientsDefinition.PersonMobile);
                    //cmd.Parameters.AddWithValue("@SalesCode", CL_ClientsDefinition.SalesCode);
                    cmd.Parameters.AddWithValue("@Tel1", CL_ClientsDefinition.Tel1);
                    cmd.Parameters.AddWithValue("@Tel2", CL_ClientsDefinition.Tel2);
                    cmd.Parameters.AddWithValue("@Tel3", CL_ClientsDefinition.Tel3);
                    cmd.Parameters.AddWithValue("@Mobile", CL_ClientsDefinition.Mobile);
                    cmd.Parameters.AddWithValue("@E_Mail", CL_ClientsDefinition.E_Mail);
                    cmd.Parameters.AddWithValue("@CollectorCode", CL_ClientsDefinition.CollectorCode);
                    cmd.Parameters.AddWithValue("@ActivityCode", CL_ClientsDefinition.ActivityCode);
                    cmd.Parameters.AddWithValue("@ActivityNameA", CL_ClientsDefinition.ActivityNameA);
                    cmd.Parameters.AddWithValue("@ActivityNameE", CL_ClientsDefinition.ActivityNameE);
                    cmd.Parameters.AddWithValue("@AreaCode", CL_ClientsDefinition.AreaCode);
                    cmd.Parameters.AddWithValue("@AreaNameA", CL_ClientsDefinition.AreaNameA);
                    cmd.Parameters.AddWithValue("@AreaNameE", CL_ClientsDefinition.AreaNameE);
                    cmd.Parameters.AddWithValue("@KindCode", CL_ClientsDefinition.KindCode);
                    cmd.Parameters.AddWithValue("@KindNameA", CL_ClientsDefinition.KindNameA);
                    cmd.Parameters.AddWithValue("@KindNameE", CL_ClientsDefinition.KindNameE);
                    cmd.Parameters.AddWithValue("@TaxCode", CL_ClientsDefinition.TaxCode);
                    cmd.Parameters.AddWithValue("@TaxMissionA", CL_ClientsDefinition.TaxMissionA);
                    cmd.Parameters.AddWithValue("@TaxMissionE", CL_ClientsDefinition.TaxMissionE);
                    cmd.Parameters.AddWithValue("@TaxAddress", CL_ClientsDefinition.TaxAddress);
                    cmd.Parameters.AddWithValue("@TaxCardNo", CL_ClientsDefinition.TaxCardNo);
                    cmd.Parameters.AddWithValue("@TaxFileNo", CL_ClientsDefinition.TaxFileNo);
                    cmd.Parameters.AddWithValue("@Exmpted", CL_ClientsDefinition.Exmpted);
                    cmd.Parameters.AddWithValue("@ExmptedDate", CL_ClientsDefinition.ExmptedDate);
                    cmd.Parameters.AddWithValue("@SelectPrice", CL_ClientsDefinition.SelectPrice);
                    cmd.Parameters.AddWithValue("@PaymentCode", CL_ClientsDefinition.PaymentCode);
                    cmd.Parameters.AddWithValue("@PaymentNameA", CL_ClientsDefinition.PaymentNameA);
                    cmd.Parameters.AddWithValue("@PaymentNameE", CL_ClientsDefinition.PaymentNameE);
                    cmd.Parameters.AddWithValue("@CommercialDed", CL_ClientsDefinition.CommercialDed);
                    cmd.Parameters.AddWithValue("@AllowenceDed", CL_ClientsDefinition.AllowenceDed);
                    cmd.Parameters.AddWithValue("@CashDed", CL_ClientsDefinition.CashDed);
                    cmd.Parameters.AddWithValue("@CreditLimitPer", CL_ClientsDefinition.CreditLimitPer);
                    cmd.Parameters.AddWithValue("@CreditLimitValue", CL_ClientsDefinition.CreditLimitValue);
                    cmd.Parameters.AddWithValue("@LinkWGL", CL_ClientsDefinition.LinkWGL);
                    cmd.Parameters.AddWithValue("@CostCenter", CL_ClientsDefinition.CostCenter);
                    cmd.Parameters.AddWithValue("@DirectCode", CL_ClientsDefinition.DirectCode);
                    cmd.Parameters.AddWithValue("@CorporateCode", CL_ClientsDefinition.CorporateCode);
                    cmd.Parameters.AddWithValue("@TargetQty", CL_ClientsDefinition.TargetQty);
                    cmd.Parameters.AddWithValue("@ClientNature", CL_ClientsDefinition.ClientNature);
                    cmd.Parameters.AddWithValue("@OriginCountry", CL_ClientsDefinition.OriginCountry);
                    cmd.Parameters.AddWithValue("@RegistrationNo", CL_ClientsDefinition.RegistrationNo);
                    cmd.Parameters.AddWithValue("@CountryCode", CL_ClientsDefinition.CountryCode);
                    cmd.Parameters.AddWithValue("@r_Country", CL_ClientsDefinition.r_Country);
                    cmd.Parameters.AddWithValue("@r_Governate", CL_ClientsDefinition.r_Governate);
                    cmd.Parameters.AddWithValue("@Status", CL_ClientsDefinition.Status);
                    cmd.Parameters.AddWithValue("@TimeStamp", CL_ClientsDefinition.TimeStamp);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    await cmd.ExecuteNonQueryAsync();

                    CL_ClientsDefinition.ClientCode = (int)ReturnID.Value;

                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Created Scussefully  ", CL_ClientsDefinition.ClientCode);
                    return CL_ClientsDefinition.ClientCode;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", CL_ClientsDefinition.ClientNameA, dex.Message);
                GlobalError = dex.Message;
                return -1;

            }
        }

        public async Task<int> Update()
        {

            try
            {
                await using (var conn = new SqlConnection(strConnection))
                await using (var cmd = conn.CreateCommand())
                {
                    await conn.OpenAsync();
                    cmd.CommandText = "uspCL_ClientsDefinitionEdit";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClientCode", CL_ClientsDefinition.ClientCode);
                    cmd.Parameters.AddWithValue("@ClientNameA", CL_ClientsDefinition.ClientNameA);
                    cmd.Parameters.AddWithValue("@ClientNameE", CL_ClientsDefinition.ClientNameE);
                    cmd.Parameters.AddWithValue("@ClientAddressA", CL_ClientsDefinition.ClientAddressA);
                    cmd.Parameters.AddWithValue("@ClientAddressE", CL_ClientsDefinition.ClientAddressE);
                    cmd.Parameters.AddWithValue("@PersoninCharge", CL_ClientsDefinition.PersoninCharge);
                    cmd.Parameters.AddWithValue("@PersonMobile", CL_ClientsDefinition.PersonMobile);
                    //cmd.Parameters.AddWithValue("@SalesCode", CL_ClientsDefinition.SalesCode);
                    cmd.Parameters.AddWithValue("@Tel1", CL_ClientsDefinition.Tel1);
                    cmd.Parameters.AddWithValue("@Tel2", CL_ClientsDefinition.Tel2);
                    cmd.Parameters.AddWithValue("@Tel3", CL_ClientsDefinition.Tel3);
                    cmd.Parameters.AddWithValue("@Mobile", CL_ClientsDefinition.Mobile);
                    cmd.Parameters.AddWithValue("@E_Mail", CL_ClientsDefinition.E_Mail);
                    cmd.Parameters.AddWithValue("@CollectorCode", CL_ClientsDefinition.CollectorCode);
                    cmd.Parameters.AddWithValue("@ActivityCode", CL_ClientsDefinition.ActivityCode);
                    cmd.Parameters.AddWithValue("@ActivityNameA", CL_ClientsDefinition.ActivityNameA);
                    cmd.Parameters.AddWithValue("@ActivityNameE", CL_ClientsDefinition.ActivityNameE);
                    cmd.Parameters.AddWithValue("@AreaCode", CL_ClientsDefinition.AreaCode);
                    cmd.Parameters.AddWithValue("@AreaNameA", CL_ClientsDefinition.AreaNameA);
                    cmd.Parameters.AddWithValue("@AreaNameE", CL_ClientsDefinition.AreaNameE);
                    cmd.Parameters.AddWithValue("@KindCode", CL_ClientsDefinition.KindCode);
                    cmd.Parameters.AddWithValue("@KindNameA", CL_ClientsDefinition.KindNameA);
                    cmd.Parameters.AddWithValue("@KindNameE", CL_ClientsDefinition.KindNameE);
                    cmd.Parameters.AddWithValue("@TaxCode", CL_ClientsDefinition.TaxCode);
                    cmd.Parameters.AddWithValue("@TaxMissionA", CL_ClientsDefinition.TaxMissionA);
                    cmd.Parameters.AddWithValue("@TaxMissionE", CL_ClientsDefinition.TaxMissionE);
                    cmd.Parameters.AddWithValue("@TaxAddress", CL_ClientsDefinition.TaxAddress);
                    cmd.Parameters.AddWithValue("@TaxCardNo", CL_ClientsDefinition.TaxCardNo);
                    cmd.Parameters.AddWithValue("@TaxFileNo", CL_ClientsDefinition.TaxFileNo);
                    cmd.Parameters.AddWithValue("@Exmpted", CL_ClientsDefinition.Exmpted);
                    cmd.Parameters.AddWithValue("@ExmptedDate", CL_ClientsDefinition.ExmptedDate);
                    cmd.Parameters.AddWithValue("@SelectPrice", CL_ClientsDefinition.SelectPrice);
                    cmd.Parameters.AddWithValue("@PaymentCode", CL_ClientsDefinition.PaymentCode);
                    cmd.Parameters.AddWithValue("@PaymentNameA", CL_ClientsDefinition.PaymentNameA);
                    cmd.Parameters.AddWithValue("@PaymentNameE", CL_ClientsDefinition.PaymentNameE);
                    cmd.Parameters.AddWithValue("@CommercialDed", CL_ClientsDefinition.CommercialDed);
                    cmd.Parameters.AddWithValue("@AllowenceDed", CL_ClientsDefinition.AllowenceDed);
                    cmd.Parameters.AddWithValue("@CashDed", CL_ClientsDefinition.CashDed);
                    cmd.Parameters.AddWithValue("@CreditLimitPer", CL_ClientsDefinition.CreditLimitPer);
                    cmd.Parameters.AddWithValue("@CreditLimitValue", CL_ClientsDefinition.CreditLimitValue);
                    cmd.Parameters.AddWithValue("@LinkWGL", CL_ClientsDefinition.LinkWGL);
                    cmd.Parameters.AddWithValue("@CostCenter", CL_ClientsDefinition.CostCenter);
                    cmd.Parameters.AddWithValue("@DirectCode", CL_ClientsDefinition.DirectCode);
                    cmd.Parameters.AddWithValue("@CorporateCode", CL_ClientsDefinition.CorporateCode);
                    cmd.Parameters.AddWithValue("@TargetQty", CL_ClientsDefinition.TargetQty);
                    cmd.Parameters.AddWithValue("@ClientNature", CL_ClientsDefinition.ClientNature);
                    cmd.Parameters.AddWithValue("@OriginCountry", CL_ClientsDefinition.OriginCountry);
                    cmd.Parameters.AddWithValue("@RegistrationNo", CL_ClientsDefinition.RegistrationNo);
                    cmd.Parameters.AddWithValue("@CountryCode", CL_ClientsDefinition.CountryCode);
                    cmd.Parameters.AddWithValue("@r_Country", CL_ClientsDefinition.r_Country);
                    cmd.Parameters.AddWithValue("@r_Governate", CL_ClientsDefinition.r_Governate);
                    cmd.Parameters.AddWithValue("@Status", CL_ClientsDefinition.Status);
                    cmd.Parameters.AddWithValue("@TimeStamp", CL_ClientsDefinition.TimeStamp);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);

                    await cmd.ExecuteNonQueryAsync();
                    logger.Log(LogLevel.Info, this.GetType().Name + " ID {0} is Updated Scussefully  ", CL_ClientsDefinition.ClientCode);
                    return CL_ClientsDefinition.ClientCode;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + " Name {0} is was not Saved with Error {1}  ", CL_ClientsDefinition.ClientNameA, dex.Message);
                GlobalError = dex.Message;
                return -1;

            }
        }

        public async Task<bool> Delete()
        {

            try
            {
                await using (var conn = new SqlConnection(strConnection))
                await using (var cmd = conn.CreateCommand())
                {
                    await conn.OpenAsync();
                    cmd.CommandText = "uspCL_ClientsDefinitionDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", CL_ClientsDefinition.ClientCode);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);

                    cmd.Parameters.AddWithValue("@LanguageID", CultureInfo.CurrentCulture.Name);
                    await cmd.ExecuteNonQueryAsync();

                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {CL_ClientsDefinition.ClientCode} is Deleted Scussefully  ");
                    return true;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {CL_ClientsDefinition.ClientCode} is was not Deleted with Error {dex.Message}  ");
                GlobalError = dex.Message;
                return false;

            }
        }
        public async Task<bool> Delete(int id)
        {

            try
            {
                await using (var conn = new SqlConnection(strConnection))
                await using (var cmd = conn.CreateCommand())
                {
                    await conn.OpenAsync();
                    cmd.CommandText = "uspCL_ClientsDefinitionDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@UserName", LogonUser ?? "Unknown");
                    cmd.Parameters.AddWithValue("@Source", MethodBaseExtension.GetMethodContextName());
                    cmd.Parameters.AddWithValue("@Subsys", SiteUtils.AppName);


                    await cmd.ExecuteNonQueryAsync();
                    logger.Log(LogLevel.Info, this.GetType().Name + $" ID {id} is Deleted Scussefully  ");
                    return true;

                }
            }
            catch (Exception dex)
            {
                logger.Log(LogLevel.Error, this.GetType().Name + $" Name {id} is was not Deleted with Error {dex.Message}  ");
                GlobalError = dex.Message;
                return false;

            }
        }
        #endregion
    }
    #endregion
    #region Searching and listing class datalist amnd autocomplete
    public class CL_ClientsDefinitionDatalist : ALookup<tblCL_ClientsDefinition>
    {



        public CL_ClientsDefinitionDatalist(Boolean multi = false)
        {

            //Multi = multi;
            Filter.Rows = 5;
            Filter.Sort = "ClientNameA";
            Filter.Order = LookupSortOrder.Asc;
        }

        public override IQueryable<tblCL_ClientsDefinition> GetModels()
        {
            IEnumerable<tblCL_ClientsDefinition> listing = (IEnumerable<tblCL_ClientsDefinition>)new CL_ClientsDefinitionVM().GetAll().ToEnumerable();
            //        int i = listing.Count();

            return listing.AsQueryable();
        }
        public override String GetColumnHeader(System.Reflection.PropertyInfo prop)
        {
            return prop.Name;
        }
    }

    #endregion
}

