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
            return emailSender.SendEmailAsync(email, "����������� email",
                $"����������, ����������� ���� email <a href='{HtmlEncoder.Default.Encode(link)}'>����� �� ������</a>.");
        }

        public static Task SendResetPasswordAsync(this IEmailSender emailSender, string email, string callbackUrl)
        {
            return emailSender.SendEmailAsync(email, "����� ������",
                $"����������, �������� ���� ������ <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>����� �� ������</a>.");
        }
    }
}
