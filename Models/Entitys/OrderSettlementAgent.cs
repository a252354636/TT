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
    /// 实体-OrderSettlementAgent 
    /// </summary>
	public class OrderSettlementAgent :  IBaseEntity
	{
   
			/// <summary>
        /// 
        /// </summary>
         public int Id{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string MerchantNo{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string UserId{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string OrderNo{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string PolicyNo{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string Name{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string BankCardNo{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string IdentityCardNo{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public string BankName{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public decimal Amount{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public short IdentityType{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public int Status{ get; set; }
        /// <summary>
        /// 
        /// </summary>
         public DateTime AddTime{ get; set; }
 

	}
}
