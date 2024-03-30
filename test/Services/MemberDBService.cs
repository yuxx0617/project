using System.Text;
using TEST.Models.Members;

namespace TEST.Services.MemberDBService
{

    public class MemberDBService
    {
        #region  註冊
        #region 註冊方法
        public void Register(Members newmember)
        {
            string sql = $@"INSERT INTO Members (Account,Password,Email,AuthCode,Role,IsDelete) VALUES ('{newmember.Account}','{newmember.Password}','{newmember.Email}','{newmember.AuthCode}','{newmember.Role}','0')";
            newmember.Password = HashPassword(newmember.Password);
        }
        #endregion
        #region Hash密碼
        public string HashPassword(string Password)
        {
            string salt = "y783hrhfg78i12oi";
            string saltandpassword = string.Concat(salt, Password);
            Sha2566CryptoServiceProvider sha256hasher = new Sha2566CryptoServiceProvider();
            byte[] PasswordData = Encoding.Default.GetBytes(saltandpassword);
            byte[] HashData = sha256hasher.ComputeHash(PasswordData);
            string Hashresult = Convert.ToBase64String(HashData);
            return Hashresult;
        }
        #endregion
        #region 查帳號
        public Members GetDataByAccount(string Account)
        {
            Members Data = new Members();
            string sql = $@"SELECT * FROm Members WHERE Account = '{Account}'";
            return Data;
        }
        #endregion
        #region  帳號註冊重複
        public bool AccountCheck(string Account)
        {
            Members Data = GetDataByAccount(Account);
            bool result = (Data == null);
            return result;
        }
        #endregion
        #region  信箱驗證
        public string EmailValidate(string Account, string AuthCode)
        {
            Members validatemember = GetDataByAccount(Account);
            string ValidateStr = string.Empty;
            if (validatemember != null)
            {
                if (validatemember.AuthCode == AuthCode)
                {
                    string sql = $@"UPDATE Members SET AuthCode = {string.Empty} WHERE Account = '{Account}'";
                    ValidateStr = "信箱驗證成功可以登入了";
                }
                else
                {
                    ValidateStr = "信箱驗證失敗請重新驗證或註冊";
                }
            }
            else
            {
                ValidateStr = "沒有此會員帳號請去註冊";
            }
            return ValidateStr;
        }
        #endregion
        #region 取得身分
        public string GetRole(string Account)
        {
            Members rolemember = GetDataByAccount(Account);
            string User = string.Empty;
            if (rolemember.Role == 1)
            {
                User = "Student";
            }
            else if (rolemember.Role == 2)
            {
                User = "Teacher";
            }
            else
            {
                User = "Admin";
            }
            return User;
        }
        #endregion
        #endregion
        #region 登入
        #region 登入確認
        public string LoginCheck(string Account, string Password)
        {
            Members loginmember = GetDataByAccount(Account);
            if (loginmember != null)
            {
                if (string.IsNullOrWhiteSpace(loginmember.AuthCode))
                {
                    if (PasswordCheck(loginmember, Password))
                    {
                        return "";
                    }
                    else
                    {
                        return "密碼輸入錯誤";
                    }
                }
                else
                {
                    return "信箱尚未驗證";
                }
            }
            else
            {
                return "尚未註冊帳號";
            }
        }
        #endregion
        #region 密碼確認
        public bool PasswordCheck(Members checkmember, string Password)
        {
            bool result = checkmember.Password.Equals(HashPassword(Password));
            return result;
        }
        #endregion
        #endregion
    }
}