﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDTO;
using DataDTO.EnumCode;
using DataDTO.Request.Merge;
using DataDTO.Response.Merge;
using EFFramework.Repository;
using EFFramework.Service;
using Models.Entitys;

namespace Service
{
    public class MergeService : BaseService
    {
        public PageResult GetMergePayInfoList(QueryMergePayInfo model)
        {
            int count = 0;
            if (model.page == 0)
            {
                model.page = 1;
            }
            if (model.limit == 0)
            {
                model.limit = 10;
            }
            var where = PredicateBuilder.True<MergePayInfo>();
            if (!string.IsNullOrEmpty(model.Name))
            {
                where = where.And(s => s.Name == model.Name);
            }
            if (!string.IsNullOrEmpty(model.IdentityCardNo))
            {
                where = where.And(s => s.IdentityCardNo == model.IdentityCardNo);
            }
            if (model.StatusList != null && model.StatusList.Any())
            {
                where = where.And(s => model.StatusList.Contains(s.Status));
            }
            var list = uw.GetListByPage<MergePayInfo, DateTime>(ref count, model.page, model.limit, where, by => by.AddTime, true).ToList();
            List<MergeResponseDTO> retlist = new List<MergeResponseDTO>();
            foreach (var m in list)
            {
                MergeResponseDTO merge = new MergeResponseDTO
                {
                    MergeId = m.MergeId,
                    MerchantNo = m.MerchantNo,
                    UserId = m.UserId,
                    OrderCount = m.OrderCount,
                    Amount = m.Amount,
                    Name = m.Name,
                    BankCardNo = m.BankCardNo,
                    IdentityCardNo = m.IdentityCardNo,
                    BankName = m.BankName,
                    IdentityType = BaseEnum.GetEnumDescription(typeof(IdentityTypeEnum), m.IdentityType),
                    PayDate = m.PayDate.Value.ToString(),
                    RepulseRemark = m.RepulseRemark,
                    ImgPath = m.ImgPath,
                    UpdateTime = m.UpdateTime.ToString(),
                    AddTime = m.AddTime,
                    Status = BaseEnum.GetEnumDescription(typeof(MergeStatusEnum), m.Status)
                };
                retlist.Add(merge);
            }
            return new PageResult() { data = retlist, count = count };
        }
    }
}
