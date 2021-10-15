using CariocaMix.Domain.Entities;
using System.Linq;

namespace CariocaMix.Domain.Helpers
{
    public class DeliveryRemoveAreaHelper
    {
        public static bool IsInsideArea(DeliveryRemoveArea[] poly, DeliveryRemoveArea point)
        {
            var coef = poly.Skip(1).Select((p, i) =>
                                            (point.Lng - poly[i].Lng) * (p.Lat - poly[i].Lat)
                                          - (point.Lat - poly[i].Lat) * (p.Lng - poly[i].Lng))
                                    .ToList();

            if (coef.Any(p => p == 0))
            {
                return true;
            }

            for (int i = 1; i < coef.Count(); i++)
            {
                if (coef[i] * coef[i - 1] < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
