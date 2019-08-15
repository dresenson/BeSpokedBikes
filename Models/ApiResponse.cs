using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BeSpokedBikes.Models
{
    public class ApiResponse<T>
    {
        public bool Status { get; set; }
        public T Entity { get; set; }
        public ModelStateDictionary ModelState { get; set; }
    }
}
