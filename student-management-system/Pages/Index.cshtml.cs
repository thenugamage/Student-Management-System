using Microsoft.AspNetCore.Mvc.RazorPages;
using student_management_system.Models;
using student_management_system.Services;

namespace student_management_system.Pages
{
    public class IndexModel : PageModel
    {
        private readonly StudentService _studentService;

        public IndexModel(StudentService studentService)
        {
            _studentService = studentService;
        }

        public List<Student> Students { get; set; } = new();

        public async Task OnGetAsync()
        {
            Students = await _studentService.GetAsync();
        }
    }
}
