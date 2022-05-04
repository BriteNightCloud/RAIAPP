using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAIAPP.Models
{
    partial class Personal
    {
        public byte[] Photo
        {
            get
            {
                if (File.Exists($"Resources/photo/{LastName} {FirstName} {MiddleName}.jpg"))
                {
                    return File.ReadAllBytes($"Resources/photo/{LastName} {FirstName} {MiddleName}.jpg");
                }
                if (File.Exists($"Resources/photo/{LastName} {FirstName} {MiddleName}.png"))
                {
                    return File.ReadAllBytes($"Resources/photo/{LastName} {FirstName} {MiddleName}.png");
                }
                return null;
            }

        }

        public string FullName
        {
            get
            {
                return $"{LastName} {FirstName} {MiddleName}";
            }
        }

    }
}
