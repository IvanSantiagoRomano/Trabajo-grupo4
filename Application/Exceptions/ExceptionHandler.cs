using Domain.Exceptions;
using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public static class ExceptionHandler
    {
        
        public static void Handle(this DomainException ex) 
        {
            switch (ex) 
            {
                case AlreadyDeletedException ade:  break;



                case InvalidCredentialsException ice: break;



                case NotFoundException nfe: break;
            }


        }
    }
}
