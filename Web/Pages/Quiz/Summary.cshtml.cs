using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages;

public class Summary : PageModel
{
    private User _user = new User() { Id = 1, Username = "Testowy" };
    private readonly IQuizUserService _userService;

    // KONSTRUKTOR
    public Summary(IQuizUserService userService)
    {
        _userService = userService;
    }

    // model w razor pages to ta klasa
    // jak masz tutaj zmienną publiczna to bedzie ona widoczna w widoku
    // musisz zrobic sobie tutaj listę odpowiedzi usera

    public List<QuizItemUserAnswer> listaOdpowiedziUsera { get; set; } = new List<QuizItemUserAnswer>();
    public void OnGet(int quizId)
    {
        // pobierasz za pomocą userService
        // ale nie masz narazie userService
        // popatrz skąd go miałeś w klasie item i zrób to samo
        listaOdpowiedziUsera = _userService.GetUserAnswersForQuiz(quizId, _user.Id);
    }
}