﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegetarians_Assistant.Repo.Entity;
using Vegetarians_Assistant.Services.ModelView;

namespace Vegetarians_Assistant.Services.Services.Interface.Admin
{
    public interface ILoginAService
    {
        Task<UserView?> Login(LoginView loginInfo);

        Task<bool> IsExistedEmail(string email);
    }
}
