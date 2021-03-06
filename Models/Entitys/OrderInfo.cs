//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using EFFramework.Models;
using System.Collections.Generic;
namespace Models.Entitys
{   
    /// <summary>
    /// 实体-OrderInfo 
    /// </summary>
	public class OrderInfo :  IBaseEntity
	{
   
			/// <summary>
        /// 
        /// </summary>
         public int OrderId{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string OrderNo{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string Category{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public short? InsurerType{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string ProvinceCode{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string CityCode{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string InsurerName{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string OrderSourceOrganization{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string SettlementOrganization{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public DateTime? OrderSourceDate{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string PolicyNo{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string EndorsementsNo{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public DateTime? InsuranceStartDate{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string ApplicantName{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string Insured{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public short? IsLicence{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string LicenceNo{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string VehicleFrameNo{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string EngineNo{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public DateTime? DebutDate{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public decimal? PremiumAmount{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public decimal? VehicleAndVesselTaxAmount{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public decimal? ProcedureFeeRate{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public short? ProcedureFeeClearingForm{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public decimal? ProcedureFeeClearingFee{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public decimal? CommissionRate{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public short? CommissionClearingForm{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public decimal? CommissionClearingFee{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public short Status{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public DateTime AddTime{ get; set; }
 

	}
}
