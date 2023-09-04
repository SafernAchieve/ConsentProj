using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using System.Data;
//using System.Data.SqlClient ;
using System.Threading.Tasks.Dataflow;
using System.Runtime.Intrinsics.Arm;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using Spire.Pdf;
using Spire.Pdf.Security;
using Spire.Pdf.Graphics;
using Spire.Pdf.Widget;
using Spire.Pdf.Fields;
using System.Reflection.Metadata;
using Microsoft.VisualBasic;

namespace ClientDataBase

{


    public class Demographic
    {


        public PdfSignature storedSignature { get; set; }

        public int ClientAge { get; set; }
        public string Initials12 { get; set; }
        public string Initials11 { get; set; }
        public string Initials1 { get; set; }
        public string Initials2 { get; set; }
        public string Initials3 { get; set; }
        public string Initials4 { get; set; }
        public string Initials5 { get; set; }
        public string Initials6 { get; set; }
        public string Initials7 { get; set; }
        public string Initials8 { get; set; }
        public string Initials9 { get; set; }
        public string Initials10 { get; set; }
        public string ConsentToShareInformationWithinBikurCholim { get; set; }
        public string AllInformationRelatedToDiagnosis { get; set; }
        public string Limitationsonwhatcanbeshared { get; set; }
        public string HealthConnectionsOtherNamesUsed { get; set; }
        public string School { get; set; }
        public string QualityAssuranceProgramConsentDeny { get; set; }
        public string HealthConnectionsGiveDenyConsent { get; set; }
        public string PsyckesMedicaidIDNumber { get; set; }
        public string PsyckesGiveDenyConsent { get; set; }
        public string Phone4 { get; set; }
        public string Phone3 { get; set; }
        public string Phone2 { get; set; }
        public string Phone1 { get; set; }
        public string RelationshiptoClient4 { get; set; }
        public string RelationshiptoClient3 { get; set; }
        public string RelationshiptoClient2 { get; set; }
        public string RelationshiptoClient1 { get; set; }
        public string PersonalCollateral4 { get; set; }
        public string PersonalCollateral3 { get; set; }
        public string PersonalCollateral2 { get; set; }
        public string PersonalCollateral1 { get; set; }
        public string RelationshipToInsured1 { get; set; }
        public string InsuranceId1 { get; set; }
        public string InsuranceCompany1 { get; set; }
        public string RelationshipToInsured2 { get; set; }
        public string InsuranceId2 { get; set; }
        public string InsuranceCompany2 { get; set; }
        public string RelationshipToInsured3 { get; set; }
        public string InsuranceId3 { get; set; }
        public string InsuranceCompany3 { get; set; }
        public string ClientName { get; set; }
        public string Initials { get; set; }
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string StreetAddress { get; set; }
        public string DOB { get; set; }

        public string MiddleName { get; set; }
        public string AKA { get; set; }

        public string Gender { get; set; }
        public string Zip { get; set; }

        public string Address { get; set; }
        public string City { get; set; }

        public string State { get; set; }
        public string Relationship { get; set; }

        public string Guardian { get; set; }
        public string HomeNumber { get; set; }

        public string PeopleId { get; set; }

        public string MobileNumber { get; set; }

        public string Name { get; set; }
        public string MaidenName { get; set; }

        public string CanPickUpClient { get; set; }
        public string EmergencyContact { get; set; }

        public string Email { get; set; }

        public string Date { get; set; }


        public void Get(string AgencyId, string documentId, string filePath)
        {
            Date = DateTime.Now.ToString("MM/dd/yyyy");

            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = GetConnectionSetting(" achieveazuresql01.database.windows.net", "netsmart", "consentuser", "1e5kNEqUser3kvikVqKx");
                connection.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                if (AgencyId != "")
                {
                    cmd.CommandText = "SELECT * from people where agency_id_no = @agency_id_no";
                    cmd.Parameters.AddWithValue("@agency_id_no", AgencyId);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        FirstName = dr["first_name"].ToString();
                        LastName = dr["last_name"].ToString();
                        MiddleName = dr["middle_name"].ToString();
                        MaidenName = dr["maiden_name"].ToString();
                        DateTime dobDateTime = (DateTime)dr["dob"];
                        DOB = dobDateTime.ToString("MM/dd/yyyy");
                        AKA = dr["aka"].ToString();
                        Email = dr["middle_name"].ToString();
                        CanPickUpClient = dr["first_name"].ToString();
                        Name = dr["mothers_first_name"].ToString();
                        MobileNumber = dr["mobile_phone"].ToString();
                        HomeNumber = dr["phone_day"].ToString();
                        PeopleId = dr["agency_id_no"].ToString();
                        PersonId = dr["people_id"].ToString();
                        // Relationship = dr["last_name"].ToString();
                        // State = dr["middle_name"].ToString();
                    }

                }
                else
                {
                    string sql = "INSERT ClientDocs (vchDocId, vchPath) VALUES (@vchDocId, @vchPath)";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@vchDocId", documentId);
                    cmd.Parameters.AddWithValue("@vchPath", filePath);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private string GetConnectionSetting(string serverName, string database, string user, string password)
        {
            string connectionString = $"Server={serverName};Database={database};";
            if (string.IsNullOrEmpty(user) && string.IsNullOrEmpty(password))
            {
                connectionString += "Trusted_Connection=True;TrustServerCertificate=True;";
            }
            else
            {
                connectionString += $"User Id={user};Password={password};MultipleActiveResultSets=true;";
            }
            return connectionString;
        }


    }

}
