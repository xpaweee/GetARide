using System;

namespace GetARide.Core.Domain
{
    public class DomainException : GetARideException
    {
          protected DomainException()
        {
            
        }
        public DomainException(string code) : base(code)
        {
            Code = code;
        }

        public DomainException(string messager, params object[] args) : base(string.Empty,messager,args)
        {
            
        }
        public DomainException(string code,string messager, params object[] args) : base(null,code,messager,args)
        {
            
        }

        public DomainException(Exception innerException,string messager, params object[] args) : base(innerException,string.Empty,messager,args)
        {
            
        }
         public DomainException(Exception innerException,string code,string messager, params object[] args) : base(code,string.Format(messager,args),innerException)
        {
            Code = code;
        }
    }
}