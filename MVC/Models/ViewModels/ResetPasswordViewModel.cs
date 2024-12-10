using System.ComponentModel.DataAnnotations;

namespace MVC.Models.AccountVM
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Şifre sıfırlama tokeni gereklidir.")]
        public string Token { get; set; } //Şifre sıfırlama işlemi için Identity tarafından oluşturulan token

        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Yeni şifre gereklidir.")]
        [StringLength(100, ErrorMessage = "Şifre en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre (Tekrar) gereklidir.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}
