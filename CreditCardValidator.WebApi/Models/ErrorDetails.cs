using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardValidator.WebApi.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        #region Inf
        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this);
        //}
        #endregion

    }
}
