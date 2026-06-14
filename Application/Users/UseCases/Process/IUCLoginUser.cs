using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.UseCases.Process
{
    public interface IUCLoginUser
    {
        Task<OperationResult> LogInAsync(string user, string pass);
    }
}
