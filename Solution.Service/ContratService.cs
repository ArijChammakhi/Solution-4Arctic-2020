using Service.Pattern;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class ContratService : Service<Contrat>, IContratService
    {

        private static IDataBaseFactory f = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(f);

        public ContratService() : base(ut) { }

        /*        public IEnumerable<Contrat> mesContrats()
                {
                    string connectionString = @"Data Source =(LocalDb)\MSSQLLocalDB; Initial Catalog=base_Arctic_Dari;  Integrated Security=True";

                }
        */
        public void CreateContrat(Contrat contrat)
        {
            string connectionString = @"Data Source =(LocalDb)\MSSQLLocalDB; Initial Catalog=Base-ArcTic2020;  Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();
                string sql = "INSERT INTO Contrats(ClientID,AnnonceId,DateContrat,DateFinContrat,Description,PrixContrat,motif) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7);";
                using (SqlCommand cmd = new SqlCommand(sql, s))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = contrat.ClientID;
                    cmd.Parameters.Add("@param2", SqlDbType.Int).Value = contrat.AnnonceId;
                    cmd.Parameters.Add("@param3", SqlDbType.DateTime).Value = contrat.DateContrat;
                    cmd.Parameters.Add("@param4", SqlDbType.DateTime).Value = contrat.DateFinContrat;
                    cmd.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = contrat.Description;
                    cmd.Parameters.Add("@param6", SqlDbType.Float).Value = contrat.PrixContrat;
                    cmd.Parameters.Add("@param7", SqlDbType.Int).Value = contrat.motif;

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Contrat GetContrat(string IDClient, int IDAnnonce)
        {
            string connectionString = @"Data Source =(LocalDb)\MSSQLLocalDB; Initial Catalog=Base-ArcTic2020;  Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();
                using (SqlCommand cmdSelect =
                    new SqlCommand($"SELECT ClientID,AnnonceId,DateContrat,DateFinContrat,Description,PrixContrat,motif  from Contrats where ClientID like '{IDClient}' and AnnonceID={IDAnnonce};",
                                   connection: s))
                {
                    cmdSelect.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                    {
                        sqlDataReader.Read();
                        if (sqlDataReader.FieldCount == 0)
                        {
                            return null;
                        }
                        else
                        {
                            Contrat contrat = new Contrat { };

                            contrat.ClientID = sqlDataReader.GetString(0);
                            contrat.AnnonceId = sqlDataReader.GetInt32(1);
                            contrat.DateContrat = sqlDataReader.GetDateTime(2);
                            contrat.DateFinContrat = sqlDataReader.GetDateTime(3);
                            contrat.Description = sqlDataReader.GetString(4);
                            contrat.PrixContrat = sqlDataReader.GetFloat(5);
                            contrat.motif = (Contrat.Motif)sqlDataReader.GetValue(6);

                            sqlDataReader.Close();

                            return contrat;
                        }
                    }
                }
            }
        }

        public Contrat ModContrat(string IDClient, int IDAnnonce, Contrat contrat)
        {
            if (contrat.motif.Equals("Location"))
            {
                contrat.motif = 0;
            }
            else if (contrat.motif.Equals("Vente"))
                contrat.motif = (Contrat.Motif)1;


            string connectionString = @"Data Source =(LocalDb)\MSSQLLocalDB; Initial Catalog=base_Arctic_Dari;  Integrated Security=True";
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();

                using (SqlCommand cmdSelect =
                    new SqlCommand($"UPDATE Contrats SET DateContrat ='{contrat.DateContrat}',DateFinContrat='{contrat.DateFinContrat}',Description='{contrat.Description}',PrixContrat='{contrat.PrixContrat}',motif='{(int)contrat.motif}' where ClientID={IDClient} and AnnonceID={IDAnnonce};", s))
                {
                    cmdSelect.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                    {
                        sqlDataReader.Read();

                        if (sqlDataReader.RecordsAffected == 0)
                        {
                            return null;
                        }
                        else
                        {
                            Contrat contratUpdated = GetContrat(IDClient, IDAnnonce);
                            return contratUpdated;
                        }
                    }
                }
            }

        }

        public bool RemoveContrat(string IDClient, int IDAnnonce)
        {

            Contrat contrat = GetContrat(IDClient, IDAnnonce);
            if (contrat == null) { return false; }
            else
            {
                string connectionString = @"Data Source =(LocalDb)\MSSQLLocalDB; Initial Catalog=base_Arctic_Dari;  Integrated Security=True";
                using (SqlConnection s = new SqlConnection(connectionString))
                {
                    s.Open();

                    using (SqlCommand cmdSelect =
                        new SqlCommand($"DELETE FROM Contrats  where ClientID like '{IDClient}' and AnnonceID={IDAnnonce};", s))
                    {
                        cmdSelect.CommandType = System.Data.CommandType.Text;
                        using (SqlDataReader sqlDataReader = cmdSelect.ExecuteReader())
                        {
                            sqlDataReader.Read();

                            if (sqlDataReader.RecordsAffected == 0)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }




    }
}
