using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiscaWebApiRestService.Results
{
    public class ResponseApi<T> where T : class
    {
        public ResponseApi(bool ok, String message = null, T data = null)
        {
            this.ok = ok;
            this.data = data;
            this.message = message;
        }
        public bool ok { get; set; }
        public String message { get; set; }
        public T data { get; set; }
       

    }
}