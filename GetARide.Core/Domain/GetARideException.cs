using System;

namespace GetARide.Core.Domain
{
    public abstract class GetARideException : Exception
    {
        public string Code {get;set;}

        protected GetARideException()
        {
            
        }
        public GetARideException(string code)
        {
            Code = code;
        }

        public GetARideException(string messager, params object[] args) : this(string.Empty,messager,args)
        {
            
        }
        public GetARideException(string code,string messager, params object[] args) : this(null,code,messager,args)
        {
            
        }

        public GetARideException(Exception innerException,string messager, params object[] args) : this(innerException,string.Empty,messager,args)
        {
            
        }
         public GetARideException(Exception innerException,string code,string messager, params object[] args) : base(string.Format(messager,args),innerException)
        {
            Code = code;
        }
        

    }
}