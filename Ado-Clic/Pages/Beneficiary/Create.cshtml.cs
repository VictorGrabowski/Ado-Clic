using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ado_Clic.Pages.Beneficiary;

public class CreateModel : PageModel
{
    private readonly Data.BeneficiaryDbContext _context;

    public CreateModel(Data.BeneficiaryDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Models.Beneficiary? Beneficiary { get; set; }
    public static void CreateTestMessage2(Models.Beneficiary beneficiary)
    {
        if (beneficiary.Email != null)
        {
            MailAddress to = new MailAddress(beneficiary.Email);
            MailAddress from = new MailAddress("ado-clic@gmail.com");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Using the new SMTP client.";
            message.Body = @"Using this new feature, you can send an email message from an application very easily.";
            SmtpClient client = new SmtpClient();
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

        if (Beneficiary != null) _context.Beneficiary.Add(Beneficiary);
        
        await _context.SaveChangesAsync();
        CreateTestMessage2(Beneficiary);
        return RedirectToPage("./CreationSuccessful");
    }
}