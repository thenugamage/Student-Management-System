using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using student_management_system.Models;
using student_management_system.Services;

namespace student_management_system.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly StudentService _studentService;

        public DeleteModel(StudentService studentService)
        {
            _studentService = studentService;
        }

        [BindProperty]
        public Student Student { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
                return NotFound();

            var student = await _studentService.GetAsync(id);

            if (student == null)
                return NotFound();

            Student = student;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Student.Id == null)
                return NotFound();

            await _studentService.DeleteAsync(Student.Id);

            return RedirectToPage("Index");
        }
    }
}
