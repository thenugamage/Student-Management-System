using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using student_management_system.Models;
using student_management_system.Services;

namespace student_management_system.Pages
{
    public class EditModel : PageModel
    {
        private readonly StudentService _studentService;

        public EditModel(StudentService studentService)
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
            if (!ModelState.IsValid)
                return Page();

            var existingStudent = await _studentService.GetAsync(Student.Id!);

            if (existingStudent == null)
                return NotFound();

            await _studentService.UpdateAsync(Student.Id!, Student);

            return RedirectToPage("Index");
        }
    }
}
