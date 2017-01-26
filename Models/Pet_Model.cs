using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CrudCore.Models
{
    public class Pet_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name ="Date of birth")]
        public DateTime DateOfBirth { get; set; }
        public string Type { get; set; }
        public Pet_Model() { }
        public Pet_Model(SqlDataReader dr)
        {
            Id =Convert.ToInt16( dr["Id"]);
            Name =dr["Name"].ToString();
            DateOfBirth =Convert.ToDateTime( dr["DateOfBirth"]);
            Type = dr["Type"].ToString();


        }

        
    }
}
