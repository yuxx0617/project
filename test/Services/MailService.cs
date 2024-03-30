using System.Net.Mail;

namespace TEST.Services.MemberDBService
{
    public class MailService
    {
        #region 我的信箱帳號
        private string gmail_account = "yuxx0617@gmail.com";//帳號
        private string gmail_password = "dkigaaolxcwonmma";//密碼 金鑰
        private string gmail_mail = "yuxx0617@gmail.com";//信箱
        #endregion
        #region 取得驗證碼
        public string GetValidateCode()
        {
            string[] Code ={"A", "B", "C", "D", "E", "F", "G", "H", "I","J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
            "a", "b", "c", "d", "e", "f", "g", "h", "i","j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" ,
            "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            string ValidateCode = string.Empty;
            Random rd = new Random();
            for (int i = 0; i < 10; i++)
            {
                ValidateCode += Code[rd.Next(Code.Count())];
            }
            return ValidateCode;
        }
        #endregion
        #region  取得郵件範本
        public string GetMailBody(string TempString, string UserName, string ValidateUrl)
        {
            TempString = TempString.Replace("{{UserName}}", UserName);
            TempString = TempString.Replace("{{ValidateUrl}}", ValidateUrl);
            return TempString;
        }
        #endregion
        #region 寄驗證信
        public void SendValidateMail(string ToMail, string MailBody)
        {
            SmtpClient smtpserver = new SmtpClient("smtp.gnail.com");
            smtpserver.Credentials = new System.Net.NetworkCredential(gmail_account, gmail_password);
            smtpserver.Port = 587;
            smtpserver.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.To.Add(ToMail);
            mail.From = new MailAddress(gmail_mail);
            mail.Subject = "會員驗證信";
            mail.Body = MailBody;
            mail.IsBodyHtml = true;
            smtpserver.Send(mail);
        }
        #endregion
    }
}