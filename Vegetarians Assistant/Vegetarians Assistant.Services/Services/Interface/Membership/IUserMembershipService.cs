﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegetarians_Assistant.Repo.Entity;
using Vegetarians_Assistant.Services.ModelView;

namespace Vegetarians_Assistant.Services.Services.Interface.Membership
{
    public interface IUsermembershipService
    {
        Task<UserMembershipView> getCustomerMembership(int userId);

        Task<ResponseView> insertCustomerMembership(UserMembershipView record);

        Task<UserMembershipView> addPointForMembership(int userId, int points);
    }
}
//