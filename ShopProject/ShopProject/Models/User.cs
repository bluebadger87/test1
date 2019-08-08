using ShopProject.DataContext;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ShopProject.Models
{
    public class User
    {
        [Key]
        public int UserNo { get; set; }
        [Required]
        [DisplayName("Id")]
        public string UserId { get; set; }
        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string UserPassword1 { get; set; }
        [Required]
        [DisplayName("PasswordConf")]
        [DataType(DataType.Password)]
        [Compare("UserPassword1", ErrorMessage = "Password doesn't match.")]
        public string UserPassword2 { get; set; }
        [Required]
        [DisplayName("Name")]
        public string UserName { get; set; }
        [DisplayName("Address1")]
        public int UserAddress1 { get; set; }
        [DisplayName("Address2")]
        public int UserAddress2 { get; set; }
        [DisplayName("Address3")]
        public int UserAddress3 { get; set; }
        [Required]
        [DisplayName("Tel")]
        public string UserTel { get; set; }
        [Required]
        [DisplayName("Mail")]
        public string UserMail { get; set; }
        [DisplayName("Authority")]
        public string UserAuthority { get; set; }
        [DisplayName("Del")]
        public string UserDel { get; set; }
        [DisplayName("DataInputDate")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime UserInp { get; set; }
        [DisplayName("DataUpdateDate")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime UserUpd { get; set; }

        public static void Initialize(ShopDbContext context)
        {
            var t = context.Set<User>();
            string password = "ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb";
            if (t.Any() == false)
            {
                t.AddRange(
                    new User() { UserId = "admin", UserDel = "1", UserPassword1 = password, UserPassword2 = password, UserName = "Nameadmin", UserAddress1 = 1, UserTel = "01099990011", UserMail = "bluebadger@naver.com", UserInp = DateTime.Now, UserAuthority = "1" },
                    new User() { UserId = "test1", UserDel = "1", UserPassword1 = password, UserPassword2 = password, UserName = "Nametest1", UserAddress1 = 2, UserTel = "01099990002", UserMail = "bluebadger@naver.com", UserInp = DateTime.Now, UserAuthority = "0" },
                    new User() { UserId = "test2", UserDel = "1", UserPassword1 = password, UserPassword2 = password, UserName = "Nametest2", UserAddress1 = 3, UserTel = "01099990003", UserMail = "bluebadger@naver.com", UserInp = DateTime.Now, UserAuthority = "0" },
                    new User() { UserId = "test3", UserDel = "1", UserPassword1 = password, UserPassword2 = password, UserName = "Nametest3", UserAddress1 = 4, UserTel = "01099990004", UserMail = "bluebadger@naver.com", UserInp = DateTime.Now, UserAuthority = "0" },
                    new User() { UserId = "test4", UserDel = "1", UserPassword1 = password, UserPassword2 = password, UserName = "Nametest4", UserAddress1 = 1, UserTel = "01099990005", UserMail = "bluebadger@naver.com", UserInp = DateTime.Now, UserAuthority = "0" },
                    new User() { UserId = "test5", UserDel = "1", UserPassword1 = password, UserPassword2 = password, UserName = "Nametest5", UserAddress1 = 2, UserTel = "01099990006", UserMail = "bluebadger@naver.com", UserInp = DateTime.Now, UserAuthority = "0" },
                    new User() { UserId = "test6", UserDel = "1", UserPassword1 = "a", UserPassword2 = "a", UserName = "Nametest6", UserAddress1 = 3, UserTel = "01099990007", UserMail = "bluebadger@naver.com", UserInp = DateTime.Now, UserAuthority = "0" },
                    new User() { UserId = "test7", UserDel = "1", UserPassword1 = "a", UserPassword2 = "a", UserName = "Nametest7", UserAddress1 = 4, UserTel = "01099990008", UserMail = "bluebadger@naver.com", UserInp = DateTime.Now, UserAuthority = "0" },
                    new User() { UserId = "test8", UserDel = "1", UserPassword1 = "a", UserPassword2 = "a", UserName = "Nametest8", UserAddress1 = 1, UserTel = "01099990009", UserMail = "bluebadger@naver.com", UserInp = DateTime.Now, UserAuthority = "0" });
                context.SaveChanges();
            }
        }
    }
}
