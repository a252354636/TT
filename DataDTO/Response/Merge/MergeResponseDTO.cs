using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDTO.Response.Merge
{
  public  class MergeResponseDTO
    {

        /// <summary>
        /// 
        /// </summary>
        public int MergeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MerchantNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OrderCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BankCardNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IdentityCardNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IdentityType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PayDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RepulseRemark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ImgPath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UpdateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}
