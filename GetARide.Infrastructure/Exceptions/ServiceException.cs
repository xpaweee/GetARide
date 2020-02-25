using System;
using GetARide.Core.Domain;

namespace GetARide.Infrastructure.Exceptions
{
    public class ServiceException: GetARideException
    {
          protected ServiceException()
        {
            
        }
        public ServiceException(string code) : base(code)
        {
            Code = code;
        }

        public ServiceException(string messager, params object[] args) : base(string.Empty,messager,args)
        {
            
        }
        public ServiceException(string code,string messager, params object[] args) : base(null,code,messager,args)
        {
            
        }

        public ServiceException(Exception innerException,string messager, params object[] args) : base(innerException,string.Empty,messager,args)
        {
            
        }
         public ServiceException(Exception innerException,string code,string messager, params object[] args) : base(code,string.Format(messager,args),innerException)
        {
            Code = code;
        }
        
    }
}