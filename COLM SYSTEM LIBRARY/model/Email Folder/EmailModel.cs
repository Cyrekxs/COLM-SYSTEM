using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.IO;

//need to allow 
////https://www.google.com/settings/u/1/security/lesssecureapps
namespace COLM_SYSTEM_LIBRARY.model
{
    public class EmailModel
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<Attachment> attachments = new List<Attachment>();

        public static bool SendMail(EmailModel model, EmailCredential credential)
        {
            try
            {
                MailMessage mm = new MailMessage(credential.Email, model.To);
                mm.Subject = model.Subject;
                mm.Body = model.Body;
                mm.IsBodyHtml = false;
                foreach (var item in model.attachments)
                {
                    mm.Attachments.Add(item);
                }

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;


                NetworkCredential nc = new NetworkCredential(credential.Email, credential.Password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Send(mm);

                smtp.Dispose();
                mm.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch (Exception ex)
            {
                string result = ex.Message;
                return false;
            }
        }

        private static byte[] BytesFromString(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        private static int GetResponseCode(string ResponseString)
        {
            return int.Parse(ResponseString.Substring(0, 3));
        }
    }
}
