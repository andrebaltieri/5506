using MyStore.Domain.Account.Enums;
using MyStore.Domain.Account.Scopes;
using System;

namespace MyStore.Domain.Account.Entities
{
    public class User
    {
        public User(string email, string username, string password)
        {
            Id = Guid.NewGuid();
            Email = email;
            Username = username;
            Password = password;
            Verified = false;
            Active = false;
            LastLoginDate = DateTime.Now;
            Role = ERole.User;
            VerificationCode = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            ActivationCode = Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
            AuthorizationCode = "";
            LastAuthorizationCodeRequest = DateTime.Now.AddMinutes(5);
        }

        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public bool Verified { get; private set; }
        public bool Active { get; private set; }
        public DateTime LastLoginDate { get; private set; }
        public ERole Role { get; private set; }
        public string VerificationCode { get; private set; }
        public string ActivationCode { get; private set; }
        public string AuthorizationCode { get; private set; }
        public DateTime LastAuthorizationCodeRequest { get; private set; }

        public void Register()
        {
            this.RegisterScopeIsValid();
            Password = EncryptPassword(Password);
        }

        public void Verify(string verificationCode)
        {
            this.VerificationScopeIsValid(verificationCode);
            Verified = (verificationCode == VerificationCode);
        }

        public void Activate(string activationCode)
        {
            this.ActivationScopeIsValid(activationCode);
            Active = (activationCode == ActivationCode);
        }

        public void RequestLogin(string username)
        {
            this.RequestLoginScopeIsValid(username);
            AuthorizationCode = GenerateAutorizationCode();
            LastAuthorizationCodeRequest = DateTime.Now;
        }
        
        public void Authenticate(string authorizationCode, string password)
        {
            this.LoginScopeIsValid(authorizationCode, EncryptPassword(password));
            LastLoginDate = DateTime.Now;
        }

        public void MakeAdmin()
        {
            Role = ERole.Admin;
        }

        public string GenerateAutorizationCode()
        {
            return Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
        }

        public string EncryptPassword(string pass)
        {
            if (!String.IsNullOrEmpty(Password))
            {
                var password = String.Empty;
                password = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(password));
                System.Text.StringBuilder sbString = new System.Text.StringBuilder();
                for (int i = 0; i < data.Length; i++)
                    sbString.Append(data[i].ToString("x2"));

                return sbString.ToString();
            }

            return "";
        }
    }
}
