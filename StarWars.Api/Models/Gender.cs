using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Api
{
    public enum Gender
    {
        Male = 0,
        Female = 1
    }

    public static class GenderExtensions
    {
        public static string ConvertToReadable(this Gender gender)
        {
            return gender switch
            {
                Gender.Male => "Мужской",
                Gender.Female => "Женский",
                _ => throw new NotImplementedException()
            };
        }
    }
}
