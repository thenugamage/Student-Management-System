using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using student_management_system.Models;
using student_management_system.Services;

namespace student_management_system.Pages
{
    public class CreateModel : PageModel
    {
        private readonly StudentService _studentService;

        public CreateModel(StudentService studentService)
        {
            _studentService = studentService;
        }

        [BindProperty]
        public Student Student { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _studentService.CreateAsync(Student);
            return RedirectToPage("Index");
        }
    }
}
