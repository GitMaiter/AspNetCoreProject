using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Models
{
    public class TeaModel : IDrinkPreparation
    {
        public string Preparation()
        {
            return $"Do spmething with tea";
        }
    }
}
