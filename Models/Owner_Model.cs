using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudCore.Models
{
    public class Owner_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        Owner_Model()
        {

        }
        Owner_Model(System.Data.IDataRecord dr)
        {
            Id = (int)dr["Id"];
            Name = (string)dr["Name"];
            Adress = (string)dr["Adress"];
            Email = (string)dr["Email"];
            Tel = (string)dr["Tel"];
        }
    }
}
