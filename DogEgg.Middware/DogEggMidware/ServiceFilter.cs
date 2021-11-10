using DogEgg.Core.DogEggInterface;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogEgg.Middware.DogEggMidware
{
    public static class ServiceFilter
    {
        public static void ServiceFilterImpl(this IApplicationBuilder app,IEnumerable<DogEggServiceInterface> servicelist)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            try
            {
                foreach (var item in servicelist)
                {
                    item.Start();
                }


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
