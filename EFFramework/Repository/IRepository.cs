﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFramework.Repository
{
    public interface IRepository
    {
        void Add(object entity);
        void SaveChanges();
        }
}