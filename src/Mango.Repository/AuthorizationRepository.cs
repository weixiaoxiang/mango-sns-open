﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Mango.Framework.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
namespace Mango.Repository
{
    public class AuthorizationRepository
    {
        /// <summary>
        /// 根据用户组获取权限
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        public List<Models.UserGroupPowerModel> GetPowerData(int groupId)
        {
            EFDbContext dbContext = new EFDbContext();

            var query = from ugp in dbContext.m_UserGroupPower
                        join ugm in dbContext.m_UserGroupMenu
                        on ugp.MId equals ugm.MId
                        where ugp.GroupId == groupId
                        select new Models.UserGroupPowerModel()
                        {
                            GroupId=ugp.GroupId.Value,
                            MId=ugm.MId.Value,
                            MName=ugm.MName,
                            AreaName=ugm.AreaName,
                            ControllerName=ugm.ControllerName,
                            ActionName=ugm.ActionName
                        };
            return query.ToList();
        }
    }
}
