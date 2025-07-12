using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignCakesApp.Core.Entities
{
    public  class LovedOnes
    {
        
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Relationship { get; set; }

        public string? Contact { get; set; } = "111";
        public string DOB { get; set; }

        public int CustomerId { get; set; }

        public string? gender { get; set; }


    }
}
