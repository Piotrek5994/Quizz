using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BackendLab01.Pages.Quiz
{
    public class RazorPageModel : PageModel
    {
        private readonly IQuizUserService _userService;
        private readonly IQuizAdminService _adminService;
        public RazorPageModel(IQuizUserService userService , IQuizAdminService adminService)
        {
            _userService = userService;
            _adminService = adminService;
        }

        public List<Quizz> listaQuizz�w { get; set; } = new List<Quizz>();
        public void OnGet()
        {
            listaQuizz�w = _adminService.FindAllQuizzes();
        }
        public void OnPost(int quizId)
        {
            var Quizz = _userService.FindQuizById(quizId);
        }
    }
}
