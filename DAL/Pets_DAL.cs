using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudCore.Models;
using CrudCore.ConnectionFolder;
using System.Data.SqlClient;
using System.Data;

namespace CrudCore.DAL
{
    public class Pets_DAL
    {
        public static List<Pet_Model> GetAll()
        {
            List<Pet_Model> pets = new List<Pet_Model>();
            CodeDb.Open();
            string req = "SELECT * FROM [Pets]";
            SqlCommand commande = new SqlCommand(req, CodeDb.Open());
            SqlDataReader reader = commande.ExecuteReader();
            while(reader.Read())
            {
                Pet_Model p = new Pet_Model(reader);
                pets.Add(p);
            }
            CodeDb.Close();
            return pets;     
        }
        public static void Create(Pet_Model b)
        {
            CodeDb.Open();
            string req = "INSERT INTO [Pets] (Name,DateOfBirth,Type) Values (@Name,@DateOfBirth,@Type)";
            SqlCommand cmd = new SqlCommand(req, CodeDb.Open());
            //declaration des prarmetre
            SqlParameter Name = new SqlParameter("Name", DbType.String);
            SqlParameter DateOfBirth = new SqlParameter("DateOfBirth", DbType.DateTime);
            SqlParameter Type = new SqlParameter("Type", DbType.String);
            //Remplissage des es param
            Name.Value = b.Name;
            DateOfBirth.Value = b.DateOfBirth;
            Type.Value = b.Type;
            //Ajouter les parametre
            cmd.Parameters.Add(Name);
            cmd.Parameters.Add(DateOfBirth);
            cmd.Parameters.Add(Type);
            //excuter la requette 
            cmd.ExecuteNonQuery();
            CodeDb.Close();
        }
        public static void Delete(int id)
        {
            CodeDb.Open();
            string req = "DELETE From [Pets] WHERE id =@id";
            //declaration des prarmetre
            SqlCommand getcom = new SqlCommand(req, CodeDb.Open());
            SqlParameter ty = new SqlParameter("id", DbType.Int16);
            ty.Value = id;
            getcom.Parameters.Add(ty);
            //excuter la requette 
            getcom.ExecuteNonQuery();
            CodeDb.Close();
        }
        public static void Update(Pet_Model p )
        {
            CodeDb.Open();
            string req = "UPDATE [Pets] SET Name=@Name,DateOfBirth=@DateOfBirth,Type=@Type WHERE ID=@Id";
            SqlCommand cmd = new SqlCommand(req, CodeDb.Open());
            //declaration des prarmetre
            SqlParameter Name = new SqlParameter("Name", DbType.String);
            SqlParameter DateOfBirth = new SqlParameter("DateOfBirth", DbType.Date);
            SqlParameter Type = new SqlParameter("Type", DbType.String);
            SqlParameter Id = new SqlParameter("Id", DbType.Int16);
            Id.Value = p.Id;
            //Remplissage des es param
            Name.Value = p.Name;
            DateOfBirth.Value = p.DateOfBirth;
            Type.Value = p.Type;
            //Ajouter les parametre
            cmd.Parameters.Add(Name);
            cmd.Parameters.Add(DateOfBirth);
            cmd.Parameters.Add(Type);
            cmd.Parameters.Add(Id);
            //excuter la requette 
            cmd.ExecuteNonQuery();
            CodeDb.Close();
        }
        public static Pet_Model GetPetById(int id)
        {
            CodeDb.Open();
            String req = "SELECT * FROM [Pets] WHERE Id=@id";
            SqlCommand commande = new SqlCommand(req, CodeDb.Open());
            SqlParameter idp = new SqlParameter("id", DbType.Int16);
            idp.Value = id;
            commande.Parameters.Add(idp);
            SqlDataReader reader = commande.ExecuteReader();
            if(reader.FieldCount!=0)
            {
                while (reader.Read())
                {
                    return new Pet_Model(reader);
                }
                
            }
            CodeDb.Close();
            return null;
        }

    }
}
