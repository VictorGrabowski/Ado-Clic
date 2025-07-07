using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ado_Clic.Models.Enums;
namespace Ado_Clic.Pages.User;

public class CreateModel : PageModel
{
    private readonly Data.UserDbContext _context;

    public CreateModel(Data.UserDbContext context)
    {
        _context = context;
        UserTypeList = Enum.GetValues(typeof(UserType))
            .Cast<UserType>()
            .Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            }).ToList();
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Models.User? User { get; set; }
 

    public List<SelectListItem> UserTypeList { get; set; }
    
    public static void SendEmailVerificationMessage(Models.User User)
    {
        if (User.Email != null)
        {
            MailAddress to = new MailAddress(User.Email);
            MailAddress from = new MailAddress("ado-clic@gmail.com");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Using the new SMTP client.";
            message.Body = @"Using this new feature, you can send an email message from an application very easily.";
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false; // Utilise les identifiants fournis
            client.Credentials = new NetworkCredential("victorgrabowski33@gmail.com", "zxwsqfyssxojczva");
            client.EnableSsl = true;
            // Credentials are necessary if the server requires the client
            // to authenticate before it will send email on the client's behalf.
            client.UseDefaultCredentials = true;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }
        }
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (User != null) _context.User.Add(User);
        
        await _context.SaveChangesAsync();
        SendEmailVerificationMessage(User);
        return RedirectToPage("./CreationSuccessful");
    }
}