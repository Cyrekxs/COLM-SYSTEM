using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

//need to allow 
////https://www.google.com/settings/u/1/security/lesssecureapps
namespace COLM_SYSTEM_LIBRARY.model
{
    public class EmailModel
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public async static Task<int> SendMailAsync(EmailModel model, EmailCredential credential)
        {
            try
            {
                MailMessage mm = new MailMessage(credential.Email, model.To);
                mm.Subject = model.Subject;
                mm.Body = model.Body;
                mm.IsBodyHtml = false;
                Attachment attachment = new Attachment(@"C:\Users\COLM\Documents\Assessment Attachment\TESDA-FORM-9-EPAS-NC-II-1.docx");
                mm.Attachments.Add(attachment);


                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                NetworkCredential nc = new NetworkCredential(credential.Email, credential.Password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                await smtp.SendMailAsync(mm);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
