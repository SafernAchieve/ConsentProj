using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using ClientDataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Graphics;
using Spire.Pdf.Graphics.Fonts;
using Spire.Pdf.Security;
using Spire.Pdf.Tables;
using Spire.Pdf.Widget;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Uno.UI.Helpers;
using Spire.Pdf.Conversion.Compression;
using Windows.Storage.Compression;

namespace ABAConsents
{
    public class Function1
    {
        int age = 0;
        Demographic dem = new Demographic();

        [FunctionName("GetDoc")]
        public IActionResult GetDoc(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "GetDoc/GetFilledPdf")] HttpRequest req,
        ILogger log)
        {
            //Spire.License.LicenseProvider.SetLicenseKey("EfCFjH8BAHAExmR/dYS4CCb87/h55LBNHhiZ9e4ZRuR0u38ru+BUQnzS6ha9QV8ycydISwEVtPwfi54AMnRXgu+MgsqTFUSc0weGNBM9eKfXyaT5FR2myN4wHjkZa4R6ZY68gPIqjsVmjXWL2U7le+0SSHyPyggOHKWkG7OM4/PNjqaTEJHV9CTB9pddTDO44zZ0IIL0+UcdP+DotIjmjK/GDU4oOg9gOA5ZEW9QUfyREKqrLRtCu1bGgPOG/uKrB3j8UYpl+hGPO9TJZGTnqOUD8VOIzpM52Z8R0kyOhvrejfk5h8WNHYn2rMF99gxNB+vUD0r+NHff0QBaM2XPw8iL2DtAnd7fn7E8Lglo/gjrBB9/r1rJ29PslcoavJGAqOX8yjvjhEY01pKxv5kD0yIysmdUeRJNzfUbYQTNNEhPTsMqVowf9ZkbxnxvGHgyyS3EKNmwayqldzbVryrFpD/Z/g3TsxrbfHdnUhysLiVXkY00dfqwgIwRrcXrw1mLklPKESlSe6MV1a64K+QDtyEy9yAVdDsIu4Ds03BPHNMmspbR29OnB8t8btBK/adpWdyrab7b1dPeoi2T/nkYYnKAFJebsJPaNw0XAXQK8wuFyrMm1Bm4J3NsKGdKqTw67UyxkmstC1ZF9p5cTAnQh0M5X5GEG7U6eHzc9LuNwLzWgFu3zhmu084urFhxRjS/da8oZK7EBOuhLxG5+ZKruaWKvbOSpZPXaSTLzKEZs8us3DPUANvwOEJVFgD20aUL+FeB0fCwYDMHhW2le5ufrKLNpFvZGsC+/DQjinuQMMUgJY+vB/ZG+6COW9ttJl+lDTYnw8blUI0GLK3acwOXY1jflrZ4Ij/oSthUTOgfZsRjX0VE/22vK79O1lIPmybBZRVrSPnnGgnQRsEI+nJu9yqbIjbywz6NRZbZanIyL3IeN8AKdQ1q84SHxvVODJVgdInh5LWP4ErJx0e+HSf5Sf/f6yNQMCHg4Anf39Zr6Of++jdHENr0QtHiRVYU+vibR9j8o54H+vIzZGiehkTvd9neOTpxIJj5FElZ2TY3W6KK79hfuN7d1PkC317EOD8rN27w/VrnYxZt7RicirrqMp7onWOS/CkuN0gxuzhTD6+yNSRW88lGz+lpyOXsgaQkXHfQvs6uo8rmaRFYDdakYDR/5Ya4S7pL58B3P1D3jlIrzTWkwcAhYxvZqdDkSOeATpiuwyyzPrAJCTAIopCZs1mHi1Nzhz/AbfMFEMk8Oeevk1IyDYhE2GfQVKffByVMrm0wrNivURK6vgmukijyFWGXGSBF2/DEUIUsqRJsGz5e+v2M10SxE3kv0O3QC8dgTBlxJBxfKQ/03NyFQQzmKC5iTdB1jKzDm2VaoC0/oQMAstMaqNtudlpPO556DOnJE4UGHqWuFQt0e4g6W88aaPDgJpikseIoBI/2GJfLJOcJ62b7PHA/vSaAZno36bvDIj5FlYuINaZg55zV8Mni4BNrBkV0uyI7joxz0nRtihHV2Ifs9VYFNtNbmH7SwoaBqYTUpjJ0IlntuRAA1Nmq7A==" );

            Spire.Pdf.License.LicenseProvider.SetLicenseKey("EfCFjH8BAHAExmR/dYS4CCb87/h55LBNHhiZ9e4ZRuR0u38ru+BUQnzS6ha9QV8ycydISwEVtPwfi54AMnRXgu+MgsqTFUSc0weGNBM9eKfXyaT5FR2myN4wHjkZa4R6ZY68gPIqjsVmjXWL2U7le+0SSHyPyggOHKWkG7OM4/PNjqaTEJHV9CTB9pddTDO44zZ0IIL0+UcdP+DotIjmjK/GDU4oOg9gOA5ZEW9QUfyREKqrLRtCu1bGgPOG/uKrB3j8UYpl+hGPO9TJZGTnqOUD8VOIzpM52Z8R0kyOhvrejfk5h8WNHYn2rMF99gxNB+vUD0r+NHff0QBaM2XPw8iL2DtAnd7fn7E8Lglo/gjrBB9/r1rJ29PslcoavJGAqOX8yjvjhEY01pKxv5kD0yIysmdUeRJNzfUbYQTNNEhPTsMqVowf9ZkbxnxvGHgyyS3EKNmwayqldzbVryrFpD/Z/g3TsxrbfHdnUhysLiVXkY00dfqwgIwRrcXrw1mLklPKESlSe6MV1a64K+QDtyEy9yAVdDsIu4Ds03BPHNMmspbR29OnB8t8btBK/adpWdyrab7b1dPeoi2T/nkYYnKAFJebsJPaNw0XAXQK8wuFyrMm1Bm4J3NsKGdKqTw67UyxkmstC1ZF9p5cTAnQh0M5X5GEG7U6eHzc9LuNwLzWgFu3zhmu084urFhxRjS/da8oZK7EBOuhLxG5+ZKruaWKvbOSpZPXaSTLzKEZs8us3DPUANvwOEJVFgD20aUL+FeB0fCwYDMHhW2le5ufrKLNpFvZGsC+/DQjinuQMMUgJY+vB/ZG+6COW9ttJl+lDTYnw8blUI0GLK3acwOXY1jflrZ4Ij/oSthUTOgfZsRjX0VE/22vK79O1lIPmybBZRVrSPnnGgnQRsEI+nJu9yqbIjbywz6NRZbZanIyL3IeN8AKdQ1q84SHxvVODJVgdInh5LWP4ErJx0e+HSf5Sf/f6yNQMCHg4Anf39Zr6Of++jdHENr0QtHiRVYU+vibR9j8o54H+vIzZGiehkTvd9neOTpxIJj5FElZ2TY3W6KK79hfuN7d1PkC317EOD8rN27w/VrnYxZt7RicirrqMp7onWOS/CkuN0gxuzhTD6+yNSRW88lGz+lpyOXsgaQkXHfQvs6uo8rmaRFYDdakYDR/5Ya4S7pL58B3P1D3jlIrzTWkwcAhYxvZqdDkSOeATpiuwyyzPrAJCTAIopCZs1mHi1Nzhz/AbfMFEMk8Oeevk1IyDYhE2GfQVKffByVMrm0wrNivURK6vgmukijyFWGXGSBF2/DEUIUsqRJsGz5e+v2M10SxE3kv0O3QC8dgTBlxJBxfKQ/03NyFQQzmKC5iTdB1jKzDm2VaoC0/oQMAstMaqNtudlpPO556DOnJE4UGHqWuFQt0e4g6W88aaPDgJpikseIoBI/2GJfLJOcJ62b7PHA/vSaAZno36bvDIj5FlYuINaZg55zV8Mni4BNrBkV0uyI7joxz0nRtihHV2Ifs9VYFNtNbmH7SwoaBqYTUpjJ0IlntuRAA1Nmq7A==");


            return GetFilledPdf(req, log);

        }



        [FunctionName("ReturnSignedFile")]

        public IActionResult ReturnSigned([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "ReturnSignedFile/GetAzureFileReturn")] HttpRequest httpRequest)
        {
            // Fetch the file content using the provided file URL
            byte[] fileContent = GetAzureFileReturn(httpRequest);

            if (fileContent != null)
            {
                // Return the file content as a response
                return new FileContentResult(fileContent, "application/pdf");
            }

            // File not found or an error occurred
            return new NotFoundResult();
        }



        [FunctionName("GetFilledPdf")]
        private IActionResult GetFilledPdf(HttpRequest req, ILogger log)
        {
            string clientId = req.Query["ClientId"];

            // Return the filled PDF
            PdfDocument filledPdf = ReturnFilledPdf(clientId);

            if (filledPdf != null)
            {
                // Create a MemoryStream to hold the PDF data
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Save the filled PDF to the MemoryStream
                    filledPdf.SaveToStream(memoryStream);

                    // Set the position of the MemoryStream back to the beginning
                    memoryStream.Position = 0;
                    byte[] pdfBytes = memoryStream.ToArray();

                    // Return the filled PDF byte array as a response
                    return new FileContentResult(pdfBytes, "application/pdf")
                    {
                        FileDownloadName = "filled.pdf" // Optionally set the download file name
                    };
                }
            }

            // File not found or an error occurred
            return new NotFoundResult();
        }


















        private PdfDocument ReturnFilledPdf(string ClientId)
        {
            dem.Get(ClientId, "", "");
            //}
            string fileName = "";
            try
            {
                string connectionString = "DefaultEndpointsProtocol=https;AccountName=storageaccountachie8588;AccountKey=Nri9w6zeoJy3T/2yqf2bKrYARTPnzT0ZDhmMwrNHxrvtJMcML+m9VO3HLHpajkRqcYRkz3lWGDnU+AStxj0dpw==;EndpointSuffix=core.windows.net";
                ShareClient share = new ShareClient(connectionString, "consents");
                // ShareClient share = new ShareClient(connectionString, "filetestaccount");

                // Ensure that the share exists
                if (share.Exists())
                {
                    // Get a reference to the sample directory
                    ShareDirectoryClient directory = share.GetDirectoryClient("ConsentFiles");

                    // Ensure that the directory exists
                    if (directory.Exists())
                    {
                        string dobString = dem.DOB;
                        DateTime dob;

                        if (DateTime.TryParseExact(dobString, "MM/dd/yyyy", null, DateTimeStyles.None, out dob))
                        {
                            DateTime currentDate = DateTime.Now;
                            age = currentDate.Year - dob.Year;

                            dem.ClientAge = age;

                            if (dob.Month > currentDate.Month || (dob.Month == currentDate.Month && dob.Day > currentDate.Day))
                            {
                                age = age + 1;

                                if (age < 18)
                                {
                                    fileName = "6-27-23.pdf";
                                }
                                else
                                {
                                    fileName = "6-27-23 Above 18.pdf";
                                }
                            }


                            // Get a reference to a file object
                            ShareFileClient file = directory.GetFileClient(fileName);

                            // Ensure that the file exists
                            if (file.Exists())
                            {
                                // Download the file
                                ShareFileDownloadInfo download = file.Download();

                                // Create a new PdfDocument
                                PdfDocument pdfDocument = new PdfDocument();
                                pdfDocument.FileInfo.IncrementalUpdate = false;


                                if (download.Content != null)
                                {

                                    using (MemoryStream memoryStream = new MemoryStream())
                                    {
                                        download.Content.CopyTo(memoryStream);
                                        memoryStream.Position = 0;



                                        try
                                        {
                                            pdfDocument.LoadFromStream(memoryStream);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("Exception while loading PDF document: " + ex.Message);
                                            // Handle the exception or log the error message
                                            return null;
                                        }


                                    }
                                }
                                else
                                {
                                    // Handle the case when the stream is null or empty
                                }


                                // Call the FillDoc method to populate the fields
                                FillDoc1(pdfDocument, ClientId);

                                return pdfDocument;
                            }
                        }
                    }
                }
            catch (Exception)
            {

            }
            return null;
        }


        private async void FillDoc1(PdfDocument doc, string ClientId)
        {

            Demographic dem = new Demographic();
            dem.Get(ClientId, "", "");

            PdfFormWidget formWidget = doc.Form as PdfFormWidget;
            foreach (PdfField field in formWidget.FieldsWidget.List)
            {
                if (field is PdfTextBoxFieldWidget)
                {
                    PdfTextBoxFieldWidget textBoxField = field as PdfTextBoxFieldWidget;
                    textBoxField.Font = new PdfTrueTypeFont(new Font("TimesRoman", 10), false);

                    switch (textBoxField.Name)
                    {
                        case "ClientName":
                            textBoxField.Text = dem.FirstName + " " + dem.LastName ?? "";
                            break;
                        case "HomePhone":
                            string formattedHomePhone = FormatPhoneNumber(dem.HomeNumber);
                            textBoxField.Text = formattedHomePhone ?? "";
                            break;
                        case "PrintNameOfSigner":
                            textBoxField.Text = dem.FirstName + " " + dem.LastName ?? "";
                            break;
                        case "FirstName":
                            textBoxField.Text = dem.FirstName ?? "";
                            break;
                        case "DOB":
                            textBoxField.Text = dem.DOB ?? "";
                            break;
                        case "Email":
                            textBoxField.Text = dem.Email ?? "";
                            break;

                        case "LastName":
                            textBoxField.Text = dem.LastName ?? "";
                            break;
                        case "MiddleName":
                            textBoxField.Text = dem.MiddleName ?? "";
                            break;
                        case "GenderAtBirth":
                            textBoxField.Text = dem.Gender ?? "";
                            break;

                        case "AKA":
                            textBoxField.Text = dem.AKA ?? "";
                            break;
                        case "Gender":
                            textBoxField.Text = dem.Gender ?? "";
                            break;
                        case "Type":
                            textBoxField.Text = "Test";
                            break;
                        case "Zip":
                            textBoxField.Text = dem.Zip ?? "";
                            break;
                        case "Address":
                            textBoxField.Text = dem.StreetAddress ?? "";
                            break;
                        case "City":
                            textBoxField.Text = dem.City ?? "";
                            break;
                        case "State":
                            textBoxField.Text = dem.State ?? "";
                            break;
                        case "RelationshipToClient":
                            textBoxField.Text = dem.Relationship ?? "";
                            break;
                        case "Guardian":
                            textBoxField.Text = dem.Guardian ?? "";
                            break;
                        case "Home":
                            textBoxField.Text = dem.HomeNumber ?? "";
                            break;
                        case "Mobile":
                            textBoxField.Text = dem.MobileNumber ?? "";
                            break;
                        case "Name":
                            textBoxField.Text = dem.Name ?? "";
                            break;
                        case "MaidenName":
                            textBoxField.Text = dem.MaidenName ?? "";
                            break;
                        case "CanPickUpClient":
                            textBoxField.Text = dem.CanPickUpClient ?? "";
                            break;
                        case "EmergencyContact":
                            textBoxField.Text = dem.EmergencyContact ?? "";
                            break;
                        case "Date":
                            textBoxField.Text = dem.Date;
                            break;
                        default:
                            textBoxField.Text = ""; // Set other fields to blank
                            break;
                    }
                }
            }


        }


        private string FormatPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return "";
            }

            // Remove any non-numeric characters from the phone number
            string numericPhoneNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());

            // Check if the numeric phone number is at least 10 digits long
            if (numericPhoneNumber.Length >= 7)
            {
                // Format the numeric phone number as (###)###-####
                string formattedPhoneNumber = string.Format("({0}){1}-{2}",
                    numericPhoneNumber.Substring(0, 3),
                    numericPhoneNumber.Substring(3, 3),
                    numericPhoneNumber.Substring(6));

                return formattedPhoneNumber;
            }

            // If the numeric phone number is not at least 10 digits, return the original phone number
            return phoneNumber;
        }










        // private void ApplySignatureSettings(PdfFormWidget form, PdfDocument doc, PdfCertificate cert, Demographic dem, int fieldIndex)
        //{

        //    if (form.FieldsWidget != null && form.FieldsWidget.Count > fieldIndex && form.FieldsWidget[fieldIndex] is PdfSignatureFieldWidget)
        //    {

        //        var field = form.FieldsWidget[fieldIndex] as PdfSignatureFieldWidget;
        //        PdfSignature signature = new PdfSignature(doc, doc.Pages[0], cert, field.Name, field);
        //        signature.Certificated = true;
        //        signature.GraphicsMode = GraphicMode.SignDetail;
        //        signature.NameLabel = "Signer";
        //        signature.Name = dem.FirstName;
        //        signature.ContactInfoLabel = "Phone:";
        //        signature.ContactInfo = dem.HomeNumber;
        //        signature.DateLabel = "Date:";
        //        signature.Date = DateTime.Now;
        //        signature.LocationInfoLabel = "Location:";
        //        signature.LocationInfo = "Pomona USA";
        //        signature.ReasonLabel = "Reason:";
        //        signature.Reason = "Consent";
        //        signature.DistinguishedNameLabel = "DN:Achieve Behavioral Health";
        //        signature.DistinguishedName = signature.Certificate.IssuerName.Name;
        //        signature.SignDetailsFont = new PdfTrueTypeFont(new Font("Arial Unicode MS", 5f, FontStyle.Regular));
        //        signature.DocumentPermissions = PdfCertificationFlags.ForbidChanges | PdfCertificationFlags.AllowFormFill;
        //    }

        //}

        private PdfSignature ApplySignatureSettings(PdfFormWidget form, PdfDocument doc, PdfCertificate cert, Demographic dem, int fieldIndex)
        {

            PdfSignature signature = null;

            if (form.FieldsWidget != null && form.FieldsWidget.Count > fieldIndex && form.FieldsWidget[fieldIndex] is PdfSignatureFieldWidget)
            {
                var field = form.FieldsWidget[fieldIndex] as PdfSignatureFieldWidget;
                signature = new PdfSignature(doc, doc.Pages[0], cert, field.Name, field);
                signature.Certificated = true;
                signature.GraphicsMode = GraphicMode.SignDetail;
                signature.NameLabel = "Signer";
                signature.Name = dem.FirstName;
                signature.ContactInfoLabel = "Phone:";
                signature.ContactInfo = dem.HomeNumber;
                signature.DateLabel = "Date:";
                signature.Date = DateTime.Now;
                signature.LocationInfoLabel = "Location:";
                signature.LocationInfo = "Pomona USA";
                signature.ReasonLabel = "Reason:";
                signature.Reason = "Consent";
                signature.DistinguishedNameLabel = "DN:Achieve Behavioral Health";
                signature.DistinguishedName = signature.Certificate.IssuerName.Name;
                signature.SignDetailsFont = new PdfTrueTypeFont(new Font("Arial Unicode MS", 5f, FontStyle.Regular));
                signature.DocumentPermissions = PdfCertificationFlags.ForbidChanges | PdfCertificationFlags.AllowFormFill;
                dem.storedSignature = signature;

            }

            return signature;

        }




        [FunctionName("Sign")]
        public async Task<HttpResponseMessage> Sign33(
    [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Sign")] HttpRequest req,
    ILogger log)
        {
            try
            {



                var file = req.Form.Files["pdfFile"];
                string clientId = req.Query["ClientId"];
                string FileName = req.Query["FileName"];
                if (file == null || file.Length == 0)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("No file uploaded.")
                    };
                }

                PdfDocument doc;
                Demographic dem = new Demographic();
                using (var stream = file.OpenReadStream())
                {
                    doc = new PdfDocument(stream);
                }

                PdfFormWidget formWidget = doc.Form as PdfFormWidget;

                foreach (PdfStyledFieldWidget fieldWidget in formWidget.FieldsWidget.List)
                {
                    if (fieldWidget is PdfTextBoxFieldWidget)
                    {
                        PdfTextBoxFieldWidget textboxField = (PdfTextBoxFieldWidget)fieldWidget;
                        string value = textboxField.Text;

                        switch (textboxField.Name)
                        {
                            case "Gender":
                                dem.Gender = textboxField.Text;
                                break;
                            case "Address":
                                dem.Address = textboxField.Text;
                                break;
                            case "Initials1":
                                dem.Initials1 = textboxField.Text;
                                break;
                            case "Initials2":
                                dem.Initials2 = textboxField.Text;
                                break;
                            case "Initials3":
                                dem.Initials3 = textboxField.Text;
                                break;
                            case "Initials4":
                                dem.Initials4 = textboxField.Text;
                                break;
                            case "Initials5":
                                dem.Initials5 = textboxField.Text;
                                break;
                            case "Initials6":
                                dem.Initials6 = textboxField.Text;
                                break;
                            case "Initials7":
                                dem.Initials7 = textboxField.Text;
                                break;
                            case "Initials8":
                                dem.Initials8 = textboxField.Text;
                                break;
                            case "Initials9":
                                dem.Initials9 = textboxField.Text;
                                break;
                            case "Initials10":
                                dem.Initials10 = textboxField.Text;
                                break;
                            case "Initials11":
                                dem.Initials11 = textboxField.Text;
                                break;
                            case "Initials12":
                                dem.Initials12 = textboxField.Text;
                                break;
                            case "ConsentToShareInformationWithinBikurCholim":
                                dem.ConsentToShareInformationWithinBikurCholim = textboxField.Text;
                                break;


                            case "HealthConnectionsOtherNamesUsed":
                                dem.HealthConnectionsOtherNamesUsed = textboxField.Text;
                                break;

                            case "AllInformationRelatedToDiagnosis":
                                dem.AllInformationRelatedToDiagnosis = textboxField.Text;
                                break;

                            case "Limitationsonwhatcanbeshared":
                                dem.Limitationsonwhatcanbeshared = textboxField.Text;
                                break;

                            case "School":
                                dem.School = textboxField.Text;
                                break;
                            case "QualityAssuranceProgramConsentDeny":
                                dem.QualityAssuranceProgramConsentDeny = textboxField.Text;
                                break;
                            case "HealthConnectionsGiveDenyConsent":
                                dem.HealthConnectionsGiveDenyConsent = textboxField.Text;
                                break;
                            case "Patient’s Medicaid ID Number":
                                dem.PsyckesMedicaidIDNumber = textboxField.Text;
                                break;
                            case "GiveConsentDeny":
                                dem.PsyckesGiveDenyConsent = textboxField.Text;
                                break;
                            case "Phone4":
                                dem.Phone4 = textboxField.Text;
                                break;
                            case "Phone3":
                                dem.Phone3 = textboxField.Text;
                                break;
                            case "Phone2":
                                dem.Phone2 = textboxField.Text;
                                break;
                            case "Phone1":
                                dem.Phone1 = textboxField.Text;
                                break;
                            case "Relationship to Client4":
                                dem.RelationshiptoClient4 = textboxField.Text;
                                break;
                            case "Relationship to Client3":
                                dem.RelationshiptoClient3 = textboxField.Text;
                                break;
                            case "Relationship to Client2":
                                dem.RelationshiptoClient2 = textboxField.Text;
                                break;
                            case "Relationship to Client1":
                                dem.RelationshiptoClient1 = textboxField.Text;
                                break;
                            case "Personal Collateral1":
                                dem.PersonalCollateral1 = textboxField.Text;
                                break;
                            case "Personal Collateral2":
                                dem.PersonalCollateral2 = textboxField.Text;
                                break;
                            case "Personal Collateral3":
                                dem.PersonalCollateral3 = textboxField.Text;
                                break;
                            case "Personal Collateral4":
                                dem.PersonalCollateral4 = textboxField.Text;
                                break;
                            case "Relationship To Insured1":
                                dem.RelationshipToInsured1 = textboxField.Text;
                                break;
                            case "Relationship To Insured2":
                                dem.RelationshipToInsured2 = textboxField.Text;
                                break;
                            case "Relationship To Insured3":
                                dem.RelationshipToInsured3 = textboxField.Text;
                                break;
                            case "InsuranceId1":
                                dem.InsuranceId1 = textboxField.Text;
                                break;
                            case "InsuranceId2":
                                dem.InsuranceId2 = textboxField.Text;
                                break;
                            case "InsuranceId3":
                                dem.InsuranceId3 = textboxField.Text;
                                break;
                            case "Insurance Company1":
                                dem.InsuranceCompany1 = textboxField.Text;
                                break;
                            case "Insurance Company2":
                                dem.InsuranceCompany2 = textboxField.Text;
                                break;
                            case "Insurance Company3":
                                dem.InsuranceCompany3 = textboxField.Text;
                                break;
                            case "ClientName":
                                dem.ClientName = textboxField.Text;
                                break;
                            case "FirstName":
                                dem.FirstName = textboxField.Text;
                                break;
                            case "LastName":
                                dem.LastName = textboxField.Text;
                                break;
                            case "AKA":
                                dem.AKA = textboxField.Text;
                                break;
                            case "State":
                                dem.State = textboxField.Text;
                                break;
                            case "RelationshipToClient":
                                dem.Relationship = textboxField.Text;
                                break;
                            case "HomePhone":
                                dem.HomeNumber = textboxField.Text;
                                break;
                            case "DOB":
                                dem.DOB = textboxField.Text;
                                break;
                            case "Initials":
                                dem.Initials = textboxField.Text;
                                break;
                            case "Date":
                                dem.Date = textboxField.Text;
                                break;
                        }
                    }
                }


                var form = (PdfFormWidget)doc.Form;
                PdfCertificate cert = new PdfCertificate(GetCert());



                foreach (PdfStyledFieldWidget fieldWidget in formWidget.FieldsWidget.List)
                {
                    if (fieldWidget is PdfTextBoxFieldWidget)
                    {
                        PdfTextBoxFieldWidget textboxField = (PdfTextBoxFieldWidget)fieldWidget;
                        string value = textboxField.Text;

                        switch (textboxField.Name)
                        {
                            case "Gender":
                                textboxField.Text = dem.Gender ?? "";
                                break;
                            case "Address":
                                textboxField.Text = dem.Address ?? "";
                                break;
                            case "Initials1":
                                textboxField.Text = dem.Initials1 ?? "";
                                break;
                            case "Initials2":
                                textboxField.Text = dem.Initials2 ?? "";
                                break;
                            case "Initials3":
                                textboxField.Text = dem.Initials3 ?? "";
                                break;
                            case "Initials4":
                                textboxField.Text = dem.Initials4 ?? "";
                                break;
                            case "Initials5":
                                textboxField.Text = dem.Initials5 ?? "";
                                break;
                            case "Initials6":
                                textboxField.Text = dem.Initials6 ?? "";
                                break;
                            case "Initials7":
                                textboxField.Text = dem.Initials7 ?? "";
                                break;
                            case "Initials8":
                                textboxField.Text = dem.Initials8 ?? "";
                                break;
                            case "Initials9":
                                textboxField.Text = dem.Initials9 ?? "";
                                break;
                            case "Initials10":
                                textboxField.Text = dem.Initials10 ?? "";
                                break;
                            case "Initials11":
                                textboxField.Text = dem.Initials11 ?? "";
                                break;
                            case "Initials12":
                                textboxField.Text = dem.Initials12 ?? "";
                                break;
                            case "ConsentToShareInformationWithinBikurCholim":
                                textboxField.Text = dem.ConsentToShareInformationWithinBikurCholim ?? "";
                                break;
                            case "HealthConnectionsOtherNamesUsed":
                                textboxField.Text = dem.HealthConnectionsOtherNamesUsed ?? "";
                                break;
                            case "AllInformationRelatedToDiagnosis":
                                textboxField.Text = dem.AllInformationRelatedToDiagnosis ?? "";
                                break;
                            case "Limitationsonwhatcanbeshared":
                                textboxField.Text = dem.Limitationsonwhatcanbeshared ?? "";
                                break;
                            case "School":
                                textboxField.Text = dem.School ?? "";
                                break;
                            case "QualityAssuranceProgramConsentDeny":
                                textboxField.Text = dem.QualityAssuranceProgramConsentDeny ?? "";
                                break;
                            case "HealthConnectionsGiveDenyConsent":
                                textboxField.Text = dem.HealthConnectionsGiveDenyConsent ?? "";
                                break;
                            case "Patient’s Medicaid ID Number":
                                textboxField.Text = dem.PsyckesMedicaidIDNumber ?? "";
                                break;
                            case "GiveConsentDeny":
                                textboxField.Text = dem.PsyckesGiveDenyConsent ?? "";
                                break;
                            case "Phone4":
                                textboxField.Text = dem.Phone4 ?? "";
                                break;
                            case "Phone3":
                                textboxField.Text = dem.Phone3 ?? "";
                                break;
                            case "Phone2":
                                textboxField.Text = dem.Phone2 ?? "";
                                break;
                            case "Phone1":
                                textboxField.Text = dem.Phone1 ?? "";
                                break;
                            case "Relationship to Client4":
                                textboxField.Text = dem.RelationshiptoClient4 ?? "";
                                break;
                            case "Relationship to Client3":
                                textboxField.Text = dem.RelationshiptoClient3 ?? "";
                                break;
                            case "Relationship to Client2":
                                textboxField.Text = dem.RelationshiptoClient2 ?? "";
                                break;
                            case "Relationship to Client1":
                                textboxField.Text = dem.RelationshiptoClient1 ?? "";
                                break;
                            case "Personal Collateral1":
                                textboxField.Text = dem.PersonalCollateral1 ?? "";
                                break;
                            case "Personal Collateral2":
                                textboxField.Text = dem.PersonalCollateral2 ?? "";
                                break;
                            case "Personal Collateral3":
                                textboxField.Text = dem.PersonalCollateral3 ?? "";
                                break;
                            case "Personal Collateral4":
                                textboxField.Text = dem.PersonalCollateral4 ?? "";
                                break;
                            case "Relationship To Insured1":
                                textboxField.Text = dem.RelationshipToInsured1 ?? "";
                                break;
                            case "Relationship To Insured2":
                                textboxField.Text = dem.RelationshipToInsured2 ?? "";
                                break;
                            case "Relationship To Insured3":
                                textboxField.Text = dem.RelationshipToInsured3 ?? "";
                                break;
                            case "InsuranceId1":
                                textboxField.Text = dem.InsuranceId1 ?? "";
                                break;
                            case "InsuranceId2":
                                textboxField.Text = dem.InsuranceId2 ?? "";
                                break;
                            case "InsuranceId3":
                                textboxField.Text = dem.InsuranceId3 ?? "";
                                break;
                            case "Insurance Company1":
                                textboxField.Text = dem.InsuranceCompany1 ?? "";
                                break;
                            case "Insurance Company2":
                                textboxField.Text = dem.InsuranceCompany2 ?? "";
                                break;
                            case "Insurance Company3":
                                textboxField.Text = dem.InsuranceCompany3 ?? "";
                                break;
                            case "ClientName":
                                textboxField.Text = dem.ClientName ?? "";
                                break;
                            case "FirstName":
                                textboxField.Text = dem.FirstName ?? "";
                                break;
                            case "LastName":
                                textboxField.Text = dem.LastName ?? "";
                                break;
                            case "GenderAtBirth":
                                textboxField.Text = dem.Gender ?? "";
                                break;
                            case "AKA":
                                textboxField.Text = dem.AKA ?? "";
                                break;
                            case "State":
                                textboxField.Text = dem.State ?? "";
                                break;
                            case "RelationshipToClient":
                                textboxField.Text = dem.Relationship ?? "";
                                break;
                            case "HomePhone":
                                textboxField.Text = dem.HomeNumber ?? "";
                                break;
                            case "DOB":
                                textboxField.Text = dem.DOB ?? "";
                                break;
                            case "PrintNameOfSigner":
                                textboxField.Text = dem.ClientName;
                                break;
                            case "Date":
                                textboxField.Text = dem.Date ?? "";
                                break;
                            default:
                                textboxField.Text = "";
                                break;
                        }

                    }
                }

                foreach (PdfStyledFieldWidget fieldWidget in formWidget.FieldsWidget.List)
                {
                    if (fieldWidget is PdfTextBoxFieldWidget)
                    {
                        PdfTextBoxFieldWidget textboxField = (PdfTextBoxFieldWidget)fieldWidget;
                        string value = textboxField.Text;
                        //ApplySignatureSettings(form, doc, cert, dem, 0);
                        switch (textboxField.Name)
                        {
                            case "Initials1":
                                if (textboxField.Text != null && !string.IsNullOrWhiteSpace(textboxField.Text))
                                {
                                    if (doc != null && formWidget != null)
                                    {
                                        ApplySignatureSettings(form, doc, cert, dem, 14);
                                    }
                                }
                                break;
                            case "Initials2":
                                if (textboxField.Text != null && !string.IsNullOrWhiteSpace(textboxField.Text))
                                {
                                    ApplySignatureSettings(form, doc, cert, dem, 15);
                                }
                                break;
                            case "Initials3":
                                if (textboxField.Text != null && !string.IsNullOrWhiteSpace(textboxField.Text))
                                {
                                    ApplySignatureSettings(form, doc, cert, dem, 16);
                                }
                                break;
                            case "Initials4":
                                if (textboxField.Text != null && !string.IsNullOrWhiteSpace(textboxField.Text))
                                {
                                    ApplySignatureSettings(form, doc, cert, dem, 17);
                                }
                                break;
                            case "Initials5":
                                if (textboxField.Text != null && !string.IsNullOrWhiteSpace(textboxField.Text))
                                {
                                    ApplySignatureSettings(form, doc, cert, dem, 40);
                                }
                                break;
                            case "Initials6":
                                if (textboxField.Text != null && !string.IsNullOrWhiteSpace(textboxField.Text))
                                {
                                    ApplySignatureSettings(form, doc, cert, dem, 18);
                                }
                                break;
                            case "Initials7":
                                if (textboxField.Text != null && !string.IsNullOrWhiteSpace(textboxField.Text))
                                {
                                    ApplySignatureSettings(form, doc, cert, dem, 19);
                                }
                                break;
                            case "Initials8":
                                if (textboxField.Text != null && !string.IsNullOrWhiteSpace(textboxField.Text))
                                {
                                    ApplySignatureSettings(form, doc, cert, dem, 39);
                                }
                                break;
                            case "Initials9":
                                if (textboxField.Text != null && !string.IsNullOrWhiteSpace(textboxField.Text))
                                {
                                    ApplySignatureSettings(form, doc, cert, dem, 38);
                                }
                                break;
                            case "Initials10":
                                if (textboxField.Text != null && !string.IsNullOrWhiteSpace(textboxField.Text))
                                {
                                    ApplySignatureSettings(form, doc, cert, dem, 20);
                                }
                                break;
                            case "Initials11":
                                if (textboxField.Text != null && !string.IsNullOrWhiteSpace(textboxField.Text))
                                {
                                    ApplySignatureSettings(form, doc, cert, dem, 21);
                                }
                                break;
                            case "Initials12":
                                if (textboxField.Text != null && !string.IsNullOrWhiteSpace(textboxField.Text))
                                {
                                    ApplySignatureSettings(form, doc, cert, dem, 62);
                                }
                                break;
                        }
                    }
                }
                //AddSignatureFiels(doc, clientId);

                dem.Get(clientId, "", "");
                await UploadFile(doc, FileName, clientId);



                MemoryStream memoryStream = new MemoryStream();
                doc.SaveToStream(memoryStream);
                memoryStream.Position = 0;

                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(memoryStream);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline")
                {
                    FileName = "signed.pdf"
                };

                response.Headers.CacheControl = new CacheControlHeaderValue
                {
                    NoCache = true,
                    NoStore = true,
                    MustRevalidate = true
                };

                return response;
            }
            catch (Exception ex)
            {
                log.LogError(ex, "An error occurred");

                // Return an error response
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("An error occurred while processing the request.")
                };

            }
        }








        public void AddSignatureFiels(PdfDocument pdfdoc, string ClientId)
        {
            Demographic dem = new Demographic();

            PdfDocument pdfDocument = new PdfDocument();
            using (var stream = new MemoryStream())
            {
                try
                {
                    pdfdoc.SaveToStream(stream);
                    stream.Position = 0;

                    pdfDocument.LoadFromStream(stream);
                }
                catch (Exception ex)
                {
                    // Handle any exceptions here
                }
            }



            dem.Get(ClientId, "", "");
            PdfPageBase page = pdfdoc.Pages[22];
            PdfCertificate cert = new PdfCertificate(GetCert());
            PdfSignature signature = new PdfSignature(pdfDocument, page, cert, "Demo");
            signature.Bounds = new RectangleF(50, 600, 200, 200);
            signature.GraphicsMode = GraphicMode.SignDetail;
            signature.NameLabel = "Signer";
            signature.Name = dem.FirstName;
            signature.ContactInfoLabel = "Phone:";
            signature.ContactInfo = dem.HomeNumber;
            signature.DateLabel = "Date:";
            signature.Date = DateTime.Now;
            signature.LocationInfoLabel = "Location:";
            signature.LocationInfo = "Pomona USA";
            signature.ReasonLabel = "Reason:";
            signature.Reason = "Consent";
            signature.DistinguishedNameLabel = "DN:Achieve Behavioral Health";
            signature.DistinguishedName = signature.Certificate.IssuerName.Name;
            signature.SignDetailsFont = new PdfTrueTypeFont(new Font("Arial Unicode MS", 5f, FontStyle.Regular));
            signature.DocumentPermissions = PdfCertificationFlags.ForbidChanges | PdfCertificationFlags.AllowFormFill;
            dem.storedSignature = signature;

        }


        public void Compress(MemoryStream stream)
        {

            //PdfCompressor compressor = new PdfCompressor(stream);
            //TextCompressionOptions textCompression = compressor.Options.TextCompressionOptions;
            //textCompression.CompressFonts = true;
            //ImageCompressionOptions imageCompression = compressor.Options.ImageCompressionOptions;
            //imageCompression.ImageQuality = ImageQuality.High;
            //imageCompression.ResizeImages = true;
            //imageCompression.CompressImage = true;

            using (MemoryStream stream1 = new MemoryStream())
            {
                PdfCompressor compressor = new PdfCompressor(stream);
                compressor.CompressToStream(stream);
                stream1.Flush();
                stream1.Close();
            }




        }




        private async Task UploadFile(PdfDocument doc, string newFileName, string clientId)
        {
            try
            {



                Demographic dem = new Demographic();
                dem.Get(clientId, "", "");
                string PeopleId = dem.PersonId;
                string connectionString = "DefaultEndpointsProtocol=https;AccountName=storageaccountachie8588;AccountKey=Nri9w6zeoJy3T/2yqf2bKrYARTPnzT0ZDhmMwrNHxrvtJMcML+m9VO3HLHpajkRqcYRkz3lWGDnU+AStxj0dpw==;EndpointSuffix=core.windows.net";
                string fileShareName = "consents";
                string folderName = "ConsentFiles";

                // Create a ShareServiceClient using the connection string
                ShareServiceClient serviceClient = new ShareServiceClient(connectionString);

                // Get a reference to the file share
                ShareClient share = serviceClient.GetShareClient(fileShareName);

                // Ensure that the share exists
                if (share.Exists())
                {
                    // Get a reference to the directory
                    ShareDirectoryClient directory = share.GetDirectoryClient(folderName);

                    // Create the directory if it doesn't exist
                    if (!directory.Exists())
                    {
                        directory.Create();
                    }



                    // Generate a unique file name based on the new file name
                    string uniqueFileNameFullConsent = newFileName; // Use the desired file name directly







                    string FileName = $"{newFileName}";
                    string AutomationName = "ABH_CNS_V1";




                    // Get a reference to the file
                    ShareFileClient fileFullConsent = directory.GetFileClient(FileName);
                    long maxFileSizeFullConsent = 10995116;

                    if (!fileFullConsent.Exists())
                    {
                        fileFullConsent.Create(maxFileSizeFullConsent);
                    }

                    using (var stream = new MemoryStream())
                    {
                        // Save the filled PDF document to the stream
                        doc.SaveToStream(stream);
                        stream.Position = 0;

                        try
                        {
                            //Compress(stream);
                            await fileFullConsent.UploadAsync(stream);
                        }
                        catch (Exception ex)
                        {
                            // Handle any exceptions here
                        }


                    }



                    string api = "https://abhmyevolvapi.azurewebsites.net/api/consentFile";
                    string Code = "rzG63kK9xlHeCJkiFFSTLWYyw5eBf7Jw80RHtW2TNzAWAzFuPka-eA==";
                    string Url = $"{api}?code={Code}&automationKey={AutomationName}&ClientId={PeopleId}&filename={FileName}";
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(Url);
                        if (response.IsSuccessStatusCode)
                        {

                        }
                        else
                        {

                        }
                    }


                    string dobString = dem.DOB;
                    DateTime dob;

                    if (DateTime.TryParseExact(dobString, "yyyy/MM/dd", null, DateTimeStyles.None, out dob))
                    {
                        DateTime currentDate = DateTime.Now;
                        age = currentDate.Year - dob.Year;

                        dem.ClientAge = age;
                    }


                    string AutomationKeyName = "";
                    string uniqueFileName = "";
                    PdfDocument pdf1 = new PdfDocument();
                    PdfDocument pdf2 = new PdfDocument();
                    PdfDocument pdf3 = new PdfDocument();
                    PdfDocument pdf4 = new PdfDocument();
                    if (age < 18)
                    {
                        for (int i = 22; i < 38; i++)
                        {
                            PdfDocument pdf = new PdfDocument();
                            PdfPageBase page = pdf.Pages.Add(doc.Pages[i].Size, new Spire.Pdf.Graphics.PdfMargins(0));
                            doc.Pages[i].CreateTemplate().Draw(page, new System.Drawing.PointF(0, 0));


                            switch (i)
                            {
                                case 22:
                                    uniqueFileName = $"Consent For Treatment_{newFileName}.pdf";
                                    AutomationKeyName = "ABH_CN_TRM";

                                    PdfFormWidget formWidget = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox = formWidget.FieldsWidget["Initials1"] as PdfTextBoxFieldWidget;
                                    if (textbox.Text != "")
                                    {
                                        await HttpR(clientId, AutomationKeyName, pdf, directory, PeopleId, i);
                                    }


                                    break;

                                case 25:
                                    uniqueFileName = $"CONSENT TO RELEASE INFORMATION_{newFileName}.pdf";
                                    AutomationKeyName = "ABH_CN_TRI";


                                    PdfFormWidget formWidget2 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox2 = formWidget2.FieldsWidget["Initials2"] as PdfTextBoxFieldWidget;
                                    if (textbox2.Text != "")
                                    {
                                        await HttpR(clientId, AutomationKeyName, pdf, directory, PeopleId, i);
                                    }



                                    break;
                                case 26:
                                    uniqueFileName = $"Acknowledgment Receipt of Policies_{newFileName}.pdf";
                                    AutomationKeyName = "ABH_CN_ARP";

                                    PdfFormWidget formWidget3 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox3 = formWidget3.FieldsWidget["Initials3"] as PdfTextBoxFieldWidget;
                                    if (textbox3.Text != "")
                                    {
                                        await HttpR(clientId, AutomationKeyName, pdf, directory, PeopleId, i);
                                    }





                                    break;
                                case 27:
                                    uniqueFileName = $"Acknowledgment of Notice of Privacy Practices_{newFileName}.pdf";
                                    AutomationKeyName = "ABH_CN_PP";

                                    PdfFormWidget formWidget4 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox4 = formWidget4.FieldsWidget["Initials4"] as PdfTextBoxFieldWidget;
                                    if (textbox4.Text != "")
                                    {
                                        await HttpR(clientId, AutomationKeyName, pdf, directory, PeopleId, i);
                                    }


                                    break;
                                case 28:
                                    uniqueFileName = $"CONSENT TO SHARE INFORMATION WITHIN BIKUR CHOLIM, INC AND ACHIEVE BEHAVIORAL HEALTH_{newFileName}.pdf";
                                    AutomationKeyName = "ABH_CN_SIA";

                                    PdfFormWidget formWidget5 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox5 = formWidget5.FieldsWidget["Initials5"] as PdfTextBoxFieldWidget;
                                    if (textbox5.Text != "")
                                    {
                                        await HttpR(clientId, AutomationKeyName, pdf, directory, PeopleId, i);
                                    }


                                    break;
                                case 29:
                                    uniqueFileName = $"PROTECTED HEALTH INFORMATION_{newFileName}.pdf";
                                    AutomationKeyName = "ABH_CN_PHI";

                                    PdfFormWidget formWidget6 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox6 = formWidget6.FieldsWidget["Initials6"] as PdfTextBoxFieldWidget;
                                    if (textbox6.Text != "")
                                    {
                                        await HttpR(clientId, AutomationKeyName, pdf, directory, PeopleId, i);
                                    }




                                    break;
                                case 30:
                                    uniqueFileName = $"PROTECTED HEALTH INFORMATION-School_{newFileName}.pdf";
                                    AutomationKeyName = "ABH_CN_PHS";

                                    PdfFormWidget formWidget7 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox7 = formWidget7.FieldsWidget["Initials7"] as PdfTextBoxFieldWidget;
                                    if (textbox7.Text != "")
                                    {
                                        await HttpR(clientId, AutomationKeyName, pdf, directory, PeopleId, i);
                                    }

                                    break;

                                case 37:
                                    uniqueFileName = $"Quality Assurance Program Session Recording Consent Form_{newFileName}.pdf";
                                    AutomationKeyName = "ABH_CN_QAP";

                                    PdfFormWidget formWidget11 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox11 = formWidget11.FieldsWidget["Initials11"] as PdfTextBoxFieldWidget;
                                    if (textbox11.Text != "")
                                    {
                                        await HttpR(clientId, AutomationKeyName, pdf, directory, PeopleId, i);
                                    }



                                    break;
                            }


                        }




                        for (int I = 23; I < 37; I++)
                        {

                            string Automation = "";
                            string UniqueFileName = "";
                            switch (I)
                            {

                                case 23:
                                case 24:



                                    UniqueFileName = $"CFTSS_{newFileName}.pdf";
                                    Automation = "ABH_CN_CFT";

                                    PdfPageBase page = pdf1.Pages.Add(doc.Pages[I].Size, new Spire.Pdf.Graphics.PdfMargins(0));
                                    doc.Pages[I].CreateTemplate().Draw(page, new System.Drawing.PointF(0, 0));


                                    PdfFormWidget formWidget1 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox12 = formWidget1.FieldsWidget["Initials12"] as PdfTextBoxFieldWidget;
                                    if (textbox12.Text != "")
                                    {
                                        if (I == 23 || I == 24)
                                        {
                                            await HttpR(clientId, Automation, pdf1, directory, PeopleId, I);
                                        }
                                    }


                                    break;

                                case 31:
                                case 32:

                                    UniqueFileName = $"PSYCKES Consent Form_{newFileName}.pdf";
                                    Automation = "ABH_CN_PCF";

                                    PdfPageBase page1 = pdf2.Pages.Add(doc.Pages[I].Size, new Spire.Pdf.Graphics.PdfMargins(0));
                                    doc.Pages[I].CreateTemplate().Draw(page1, new System.Drawing.PointF(0, 0));


                                    PdfFormWidget formWidget2 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox8 = formWidget2.FieldsWidget["Initials8"] as PdfTextBoxFieldWidget;
                                    if (textbox8.Text != "")
                                    {
                                        if (I == 31 || I == 32)
                                        {
                                            await HttpR(clientId, Automation, pdf2, directory, PeopleId, I);
                                        }
                                    }


                                    break;
                                case 33:
                                case 34:

                                    PdfPageBase page2 = pdf3.Pages.Add(doc.Pages[I].Size, new Spire.Pdf.Graphics.PdfMargins(0));
                                    doc.Pages[I].CreateTemplate().Draw(page2, new System.Drawing.PointF(0, 0));
                                    UniqueFileName = $"Authorization for Access to Patient Information_{newFileName}.pdf";
                                    Automation = "ABH_CN_API";

                                    PdfFormWidget formWidget9 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox9 = formWidget9.FieldsWidget["Initials9"] as PdfTextBoxFieldWidget;
                                    if (textbox9.Text != "")
                                    {
                                        if (I == 33 || I == 34)
                                        {
                                            await HttpR(clientId, Automation, pdf3, directory, PeopleId, I);
                                        }
                                    }


                                    break;

                                case 35:
                                case 36:
                                    UniqueFileName = $"Telehealth Services Client Consent Form_{newFileName}.pdf";
                                    Automation = "ABH_CN_TSC";
                                    PdfPageBase page3 = pdf4.Pages.Add(doc.Pages[I].Size, new Spire.Pdf.Graphics.PdfMargins(0));
                                    doc.Pages[I].CreateTemplate().Draw(page3, new System.Drawing.PointF(0, 0));


                                    PdfFormWidget formWidget10 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox10 = formWidget10.FieldsWidget["Initials10"] as PdfTextBoxFieldWidget;
                                    if (textbox10.Text != "")
                                    {
                                        if (I == 35 || I == 36)
                                        {
                                            await HttpR(clientId, Automation, pdf4, directory, PeopleId, I);
                                        }
                                    }











                                    break;
                            }



                        }
                    }
                    else
                    {

                        for (int i = 22; i < 36; i++)
                        {
                            PdfDocument pdf = new PdfDocument();
                            PdfPageBase page = pdf.Pages.Add(doc.Pages[i].Size, new Spire.Pdf.Graphics.PdfMargins(0));
                            doc.Pages[i].CreateTemplate().Draw(page, new System.Drawing.PointF(0, 0));


                            switch (i)
                            {
                                case 22:
                                    uniqueFileName = $"Consent For Treatment_{newFileName}.pdf";
                                    AutomationKeyName = "ABH_CN_TRM";

                                    PdfFormWidget formWidget = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox = formWidget.FieldsWidget["Initials1"] as PdfTextBoxFieldWidget;
                                    if (textbox.Text != "")
                                    {
                                        await HttpR(clientId, AutomationKeyName, pdf, directory, PeopleId, i);
                                    }


                                    break;

                                case 23:
                                    uniqueFileName = $"CONSENT TO RELEASE INFORMATION_{newFileName}.pdf";
                                    AutomationKeyName = "ABH_CN_TRI";


                                    PdfFormWidget formWidget2 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox2 = formWidget2.FieldsWidget["Initials2"] as PdfTextBoxFieldWidget;
                                    if (textbox2.Text != "")
                                    {
                                        await HttpR(clientId, AutomationKeyName, pdf, directory, PeopleId, i);
                                    }



                                    break;
                                case 24:
                                    uniqueFileName = $"Acknowledgment Receipt of Policies_{newFileName}.pdf";
                                    AutomationKeyName = "ABH_CN_ARP";

                                    PdfFormWidget formWidget3 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox3 = formWidget3.FieldsWidget["Initials3"] as PdfTextBoxFieldWidget;
                                    if (textbox3.Text != "")
                                    {
                                        await HttpR(clientId, AutomationKeyName, pdf, directory, PeopleId, i);
                                    }





                                    break;
                                case 25:
                                    uniqueFileName = $"Acknowledgment of Notice of Privacy Practices_{newFileName}.pdf";
                                    AutomationKeyName = "ABH_CN_PP";

                                    PdfFormWidget formWidget4 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox4 = formWidget4.FieldsWidget["Initials4"] as PdfTextBoxFieldWidget;
                                    if (textbox4.Text != "")
                                    {
                                        await HttpR(clientId, AutomationKeyName, pdf, directory, PeopleId, i);
                                    }


                                    break;
                                case 26:
                                    uniqueFileName = $"CONSENT TO SHARE INFORMATION WITHIN BIKUR CHOLIM, INC AND ACHIEVE BEHAVIORAL HEALTH_{newFileName}.pdf";
                                    AutomationKeyName = "ABH_CN_SIA";

                                    PdfFormWidget formWidget5 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox5 = formWidget5.FieldsWidget["Initials5"] as PdfTextBoxFieldWidget;
                                    if (textbox5.Text != "")
                                    {
                                        await HttpR(clientId, AutomationKeyName, pdf, directory, PeopleId, i);
                                    }


                                    break;
                                case 27:
                                    uniqueFileName = $"PROTECTED HEALTH INFORMATION_{newFileName}.pdf";
                                    AutomationKeyName = "ABH_CN_PHI";

                                    PdfFormWidget formWidget6 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox6 = formWidget6.FieldsWidget["Initials6"] as PdfTextBoxFieldWidget;
                                    if (textbox6.Text != "")
                                    {
                                        await HttpR(clientId, AutomationKeyName, pdf, directory, PeopleId, i);
                                    }




                                    break;
                                case 28:
                                    uniqueFileName = $"PROTECTED HEALTH INFORMATION-School_{newFileName}.pdf";
                                    AutomationKeyName = "ABH_CN_PHS";

                                    PdfFormWidget formWidget7 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox7 = formWidget7.FieldsWidget["Initials7"] as PdfTextBoxFieldWidget;
                                    if (textbox7.Text != "")
                                    {
                                        await HttpR(clientId, AutomationKeyName, pdf, directory, PeopleId, i);
                                    }

                                    break;

                                case 35:
                                    uniqueFileName = $"Quality Assurance Program Session Recording Consent Form_{newFileName}.pdf";
                                    AutomationKeyName = "ABH_CN_QAP";

                                    PdfFormWidget formWidget11 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox11 = formWidget11.FieldsWidget["Initials11"] as PdfTextBoxFieldWidget;
                                    if (textbox11.Text != "")
                                    {
                                        await HttpR(clientId, AutomationKeyName, pdf, directory, PeopleId, i);
                                    }



                                    break;
                            }


                        }


                        for (int I = 28; I < 36; I++)
                        {

                            string Automation = "";
                            string UniqueFileName = "";
                            switch (I)
                            {



                                case 29:
                                case 30:

                                    UniqueFileName = $"PSYCKES Consent Form_{newFileName}.pdf";
                                    Automation = "ABH_CN_PCF";

                                    PdfPageBase page1 = pdf1.Pages.Add(doc.Pages[I].Size, new Spire.Pdf.Graphics.PdfMargins(0));
                                    doc.Pages[I].CreateTemplate().Draw(page1, new System.Drawing.PointF(0, 0));


                                    PdfFormWidget formWidget2 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox8 = formWidget2.FieldsWidget["Initials8"] as PdfTextBoxFieldWidget;
                                    if (textbox8.Text != "")
                                    {
                                        if (I == 29 || I == 30)
                                        {
                                            await HttpR(clientId, Automation, pdf1, directory, PeopleId, I);
                                        }
                                    }


                                    break;
                                case 31:
                                case 32:

                                    PdfPageBase page2 = pdf2.Pages.Add(doc.Pages[I].Size, new Spire.Pdf.Graphics.PdfMargins(0));
                                    doc.Pages[I].CreateTemplate().Draw(page2, new System.Drawing.PointF(0, 0));
                                    UniqueFileName = $"Authorization for Access to Patient Information_{newFileName}.pdf";
                                    Automation = "ABH_CN_API";

                                    PdfFormWidget formWidget9 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox9 = formWidget9.FieldsWidget["Initials9"] as PdfTextBoxFieldWidget;
                                    if (textbox9.Text != "")
                                    {
                                        if (I == 31 || I == 32)
                                        {
                                            await HttpR(clientId, Automation, pdf2, directory, PeopleId, I);
                                        }
                                    }


                                    break;

                                case 33:
                                case 34:
                                    UniqueFileName = $"Telehealth Services Client Consent Form_{newFileName}.pdf";
                                    Automation = "ABH_CN_TSC";
                                    PdfPageBase page3 = pdf3.Pages.Add(doc.Pages[I].Size, new Spire.Pdf.Graphics.PdfMargins(0));
                                    doc.Pages[I].CreateTemplate().Draw(page3, new System.Drawing.PointF(0, 0));


                                    PdfFormWidget formWidget10 = doc.Form as PdfFormWidget;
                                    PdfTextBoxFieldWidget textbox10 = formWidget10.FieldsWidget["Initials10"] as PdfTextBoxFieldWidget;
                                    if (textbox10.Text != "")
                                    {
                                        if (I == 33 || I == 34)
                                        {
                                            await HttpR(clientId, Automation, pdf3, directory, PeopleId, I);
                                        }
                                    }

                                    break;
                            }



                        }


                    }
                }

            }
            catch (Exception ex)
            {


                // Handle the error and perform appropriate actions (e.g., logging, cleanup, etc.)

                throw;
            }
        }




        public void SearchFieldsOnPage(PdfDocument doc, PdfPageBase page)
        {
            PdfFormWidget formWidget = doc.Form as PdfFormWidget;

            foreach (PdfStyledFieldWidget fieldWidget in formWidget.FieldsWidget.List)
            {
                if (fieldWidget is PdfTextBoxFieldWidget)
                {
                    PdfTextBoxFieldWidget textboxField = (PdfTextBoxFieldWidget)fieldWidget;


                    if (textboxField.Name.Equals("initials", StringComparison.OrdinalIgnoreCase))
                    {
                        string value = textboxField.Text;

                        // Perform actions specific to the "initials" field
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            // Do something with the initials field value
                            // For example, print it to the console
                            Console.WriteLine($"Initials Field Value: {value}");
                        }
                    }
                }
            }
        }



        public async Task HttpR(string clientId, string AutomationKeyName, PdfDocument pdf, ShareDirectoryClient directory, string PeopleId, int I)
        {
            string dt = DateTime.Now.ToString("MMddyyyy");
            string FormName = clientId + "_" + AutomationKeyName + "_" + dt + ".pdf";

            ShareFileClient file = directory.GetFileClient(FormName);
            long maxFileSize = 10995116;
            try
            {
                if (!file.Exists())
                {
                    file.Create(maxFileSize);
                }
            }
            catch (Exception ex)
            {

            }

            if (I == 24 || I == 30 || I == 32 || I == 34 || I == 36)
            {
                using (var stream = new MemoryStream())
                {
                    try
                    {
                        pdf.SaveToStream(stream);

                        stream.Position = 0;
                        await file.UploadAsync(stream);
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions here
                    }
                }

                string uri = file.Uri.ToString();
                string apiUrl = "https://abhmyevolvapi.azurewebsites.net/api/consentFile";
                string apiCode = "rzG63kK9xlHeCJkiFFSTLWYyw5eBf7Jw80RHtW2TNzAWAzFuPka-eA==";

                string fullUrl = $"{apiUrl}?code={apiCode}&automationKey={AutomationKeyName}&ClientId={PeopleId}&filename={FormName}";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(fullUrl);
                    if (response.IsSuccessStatusCode)
                    {

                    }
                };
            }
            else if ((I < 29 || I > 36) && I != 23 && I != 24)
            {

                using (var stream = new MemoryStream())
                {
                    try
                    {
                        pdf.SaveToStream(stream);
                        stream.Position = 0;

                        await file.UploadAsync(stream);
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions here
                    }
                }

                string Uri = file.Uri.ToString();
                string ApiUrl = "https://abhmyevolvapi.azurewebsites.net/api/consentFile";
                string ApiCode = "rzG63kK9xlHeCJkiFFSTLWYyw5eBf7Jw80RHtW2TNzAWAzFuPka-eA==";

                string FullUrl = $"{ApiUrl}?code={ApiCode}&automationKey={AutomationKeyName}&ClientId={PeopleId}&filename={FormName}";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(FullUrl);
                    if (response.IsSuccessStatusCode)
                    {

                    }
                    else
                    {

                    }
                }
            }


        }








        [FunctionName("RetrieveFromAzure")]
        public static byte[] GetAzureFileReturn(HttpRequest req)
        {
            string pdfname = req.Query["pdfName"];
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=storageaccountachie8588;AccountKey=Nri9w6zeoJy3T/2yqf2bKrYARTPnzT0ZDhmMwrNHxrvtJMcML+m9VO3HLHpajkRqcYRkz3lWGDnU+AStxj0dpw==;EndpointSuffix=core.windows.net";
            string fileShareName = "consents";
            string folderName = "ConsentFiles";

            // Instantiate a ShareClient which will be used to create and manipulate the file share
            ShareClient share = new ShareClient(connectionString, fileShareName);

            // Ensure that the share exists
            if (share.Exists())
            {
                // Get a reference to the sample directory
                ShareDirectoryClient directory = share.GetDirectoryClient("ConsentFiles");

                // Ensure that the directory exists
                if (directory.Exists())
                {

                    string fileName = Path.GetFileName(pdfname);

                    // Get a reference to a file object
                    ShareFileClient file = directory.GetFileClient(fileName);

                    // Ensure that the file exists
                    if (file.Exists())
                    {
                        // Download the file
                        ShareFileDownloadInfo download = file.Download();

                        // Read the file content into a byte array
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            download.Content.CopyTo(memoryStream);
                            return memoryStream.ToArray();
                        }
                    }
                }
            }

            // Return null if the file was not found or an error occurred
            return null;
        }











        public X509Certificate2 GetCert()
        {
            X509Certificate2 AbhCert;
            using (System.Security.Cryptography.RSA parent = System.Security.Cryptography.RSA.Create(4096))
            {
                using (System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create(2048))
                {
                    System.Security.Cryptography.X509Certificates.CertificateRequest parentReq = new System.Security.Cryptography.X509Certificates.CertificateRequest("CN=Experimental Issuing Authority", parent, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                    parentReq.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));

                    parentReq.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(parentReq.PublicKey, false));

                    using (X509Certificate2 parentCert = parentReq.CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-45), DateTimeOffset.UtcNow.AddDays(365)))
                    {
                        System.Security.Cryptography.X509Certificates.CertificateRequest req = new System.Security.Cryptography.X509Certificates.CertificateRequest("CN=Valid-Looking Timestamp Authority", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                        req.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, false));

                        req.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.NonRepudiation, false));

                        req.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(new OidCollection { new Oid("1.3.6.1.5.5.7.3.8") }, true));

                        req.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(req.PublicKey, false));

                        using (X509Certificate2 cert = req.Create(parentCert, DateTimeOffset.UtcNow.AddDays(-1),
                            DateTimeOffset.UtcNow.AddDays(90), new byte[] { 1, 2, 3, 4 }))
                        {
                            AbhCert = RSACertificateExtensions.CopyWithPrivateKey(cert, rsa);
                        }

                        return AbhCert;
                    }
                }
            }

        }

        private async Task UploadFile2(PdfDocument doc, string newFileName, string ClientId, ILogger log)
        {
            Demographic dem = new Demographic();

            dem.Get(ClientId, "", "");
            string PeopleId = dem.PersonId;
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=esaferntestaccount;AccountKey=5GeXc9lUB5LWUPrjuf8aI+lj5vGxoPKgidp+MqGOSzqIT6h9E75/Qp0GE6HsPldvRyhC4NVjzFi8+AStC3sIVQ==;EndpointSuffix=core.windows.net";
            string fileShareName = "filetestaccount";
            string folderName = "ConsentFiles";

            // Create a ShareServiceClient using the connection string
            ShareServiceClient serviceClient = new ShareServiceClient(connectionString);

            // Get a reference to the file share
            ShareClient share = serviceClient.GetShareClient(fileShareName);

            // Ensure that the share exists
            if (share.Exists())
            {
                // Get a reference to the directory
                ShareDirectoryClient directory = share.GetDirectoryClient(folderName);

                // Create the directory if it doesn't exist
                if (!directory.Exists())
                {
                    directory.Create();
                }

                // Generate a unique file name based on the new file name
                string uniqueFileName = newFileName; // Use the desired file name directly

                // Get a reference to the file
                ShareFileClient file = directory.GetFileClient(uniqueFileName);
                long maxFileSize = 109951160;


                if (!file.Exists())
                {
                    file.Create(maxFileSize);
                }


                using (var stream = new MemoryStream())
                {
                    // Save the filled PDF document to the stream
                    doc.SaveToStream(stream);
                    stream.Position = 0;
                    string fileContent = Encoding.UTF8.GetString(stream.ToArray());
                    log.LogInformation("File content: " + fileContent);

                    try
                    {
                        await file.UploadAsync(stream);
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions here
                    }
                }

                string uri = file.Uri.ToString();
                string apiUrl = "https://abhmyevolvapi.azurewebsites.net/api/consentFile";
                string apiCode = "rzG63kK9xlHeCJkiFFSTLWYyw5eBf7Jw80RHtW2TNzAWAzFuPka-eA==";

                string FullUrl = $"{apiUrl}?code={apiCode}&ClientId={PeopleId}&filename={uniqueFileName}";
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.PostAsync(FullUrl, null);
                        // Rest of the code

                        if (response.IsSuccessStatusCode)
                        {

                        }
                        else
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        // Log or display the exception details
                        log.LogError(ex, "Error occurred during PostAsync");
                    }
                }
            }
        }







        private void SetFont(PdfDocument doc)
        {
            PdfUsedFont[] fonts = doc.UsedFonts;
            PdfFont newfont = new PdfFont(PdfFontFamily.TimesRoman, 12f, PdfFontStyle.Regular | PdfFontStyle.Bold);
            foreach (PdfUsedFont font in fonts)
            {
                font.Replace(newfont);
            }
        }


        private void GetDocId()
        {

            // Method saves doc in a file and stores file guid in table

            Demographic dem = new Demographic();

            string directoryPath = "C:\\Users\\esafern\\Documents\\Save";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string fileName = "your_pdf_file_name_here.pdf";
            string filePath = Path.Combine(directoryPath, fileName);
            byte[] fileBytes = File.ReadAllBytes("C:\\Users\\esafern\\Downloads\\Sample test.pdf");
            File.WriteAllBytes(filePath, fileBytes);

            string documentId = Guid.NewGuid().ToString();

            dem.Get("", documentId, filePath);


            Console.WriteLine("Document ID: " + documentId);
            Console.WriteLine("File path: " + filePath);
        }




    }









}




















