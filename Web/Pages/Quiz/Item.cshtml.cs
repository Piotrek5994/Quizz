using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace BackendLab01.Pages
{
    
    public class QuizModel : PageModel
    {
        private User _user = new User() { Id = 1, Username = "Testowy" };//przyda siê
        private readonly IQuizUserService _userService;

        private readonly ILogger _logger;
        public QuizModel(IQuizUserService userService, ILogger<QuizModel> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        [BindProperty]
        public string Question { get; set; }
        [BindProperty]
        public List<string> Answers { get; set; }
        
        [BindProperty]
        public String UserAnswer { get; set; }
        
        [BindProperty]
        public int QuizId { get; set; }
        
        [BindProperty]
        public int ItemId { get; set; }
        
        public void OnGet(int quizId, int itemId)
        {
            QuizId = quizId;
            ItemId = itemId;
            var quiz = _userService.FindQuizById(quizId);
            if(quiz?.Items.Count <= itemId)
            {
                RedirectToPage("Summary");
            }
            var quizItem = quiz?.Items[itemId - 1];
            Question = quizItem?.Question;
            Answers = new List<string>();
            if (quizItem is not null)
            {
                Answers.AddRange(quizItem?.IncorrectAnswers);
                Answers.Add(quizItem?.CorrectAnswer);
            }
        }

        public IActionResult OnPost()
        {
            // tutaj jeszcze zapisywa³em odpowiedŸ u¿ytkownika do repo (poparz do klasy userService)
            _userService.SaveUserAnswerForQuiz(QuizId,_user.Id,ItemId,UserAnswer); //id quizu, id usera, id pytania(itemu), odpowiedz usera
            var quiz = _userService.FindQuizById(QuizId);
            if(quiz?.Items.Count <= ItemId)
            {
               return RedirectToPage("Summary",new {quizId = QuizId});
            }
            //tutaj to robisz
            // potrzba obiekt quiz ( tak jak w 36 lnijce)
            // if ( to co pisa³em na mess)
             // return redirect to page summary
            return RedirectToPage("Item", new {quizId = QuizId, itemId = ItemId + 1});
        }
    }
}
