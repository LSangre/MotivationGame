using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using MotivationGame.Services;

namespace MotivationGame.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Подтвердите email",
                $"Пожалуйста, подтвердите свой email <a href='{HtmlEncoder.Default.Encode(link)}'>нажав на ссылку</a>.");
        }

        public static Task SendResetPasswordAsync(this IEmailSender emailSender, string email, string callbackUrl)
        {
            return emailSender.SendEmailAsync(email, "Сброс пароля",
                $"Пожалуйста, обновите свой пароль <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>нажав на ссылку</a>.");
        }
    }
}
