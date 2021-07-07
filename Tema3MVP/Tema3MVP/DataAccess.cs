using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Tema3MVP
{
    public class DataAccess
    {
        public List<Categorie> GetCategorii() 
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Connection("RestaurantDB")))
            {
                var output = connection.Query<Categorie>("dbo.spCategorii").ToList();
                return output;
            }
        }

        public List<Preparat> GetPreparate(string Categorie)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Connection("RestaurantDB")))
            {
                var parameters = new { Categorie = Categorie };
                var output = connection.Query<Preparat>("dbo.spPreparatDinCategorie @Categorie", parameters).ToList();
                return output;
            }
        }

        public List<Alergen> GetAlergeni(int IdPreparat)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Connection("RestaurantDB")))
            {
                var parameters = new { IdPreparat = IdPreparat };
                var output = connection.Query<Alergen>("dbo.spAlergeniDinPreparat @IdPreparat", parameters).ToList();
                return output;
            }
        }

        public bool AddClient(string Email)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.Connection("RestaurantDB")))
            {
                var parameters = new { Email = Email };
                var output = connection.Query<Client>("dbo.spEmailExistent @Email", parameters).ToList();
                if (output.Count == 0)
                    return false;
                return true;
            }
        }
    }
}
