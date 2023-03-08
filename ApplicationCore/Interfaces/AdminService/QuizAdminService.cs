using ApplicationCore.Interfaces.Repository;

namespace BackendLab01;

public class QuizAdminService:IQuizAdminService
{
    private IGenericRepository<Quizz, int> quizRepository;
    private IGenericRepository<QuizItem, int> itemRepository;

    public QuizAdminService(IGenericRepository<Quizz, int> quizRepository, IGenericRepository<QuizItem, int> itemRepository)
    {
        this.quizRepository = quizRepository;
        this.itemRepository = itemRepository;
    }

    public QuizItem AddQuizItem(string question, List<string> incorrectAnswers, string correctAnswer, int points)
    {
        return itemRepository.Add(new QuizItem(question: question, incorrectAnswers: incorrectAnswers, correctAnswer: correctAnswer, id: 0));
    }

    public void UpdateQuizItem(int id, string question, List<string> incorrectAnswers, string correctAnswer, int points)
    {
        var quizItem = new QuizItem(id: id, question: question, incorrectAnswers: incorrectAnswers, correctAnswer: correctAnswer);
        itemRepository.Update(id, quizItem);
    }

    public Quizz AddQuiz(string title, List<QuizItem> items)
    {
        return quizRepository.Add(new Quizz( 0, title: title, items: items));
    }

    public List<QuizItem> FindAllQuizItems()
    {
        return itemRepository.FindAll();
    }

    public List<Quizz> FindAllQuizzes()
    { return quizRepository.FindAll();
    }
}