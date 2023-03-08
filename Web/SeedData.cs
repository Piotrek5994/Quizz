using ApplicationCore.Interfaces.Repository;
using BackendLab01;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();

            QuizItem item1 = new QuizItem(1,"Jaka jest stolica Polski?", new List<string>() {"Wrocław","Poznań","Kraków" }, "Warszawa");
            QuizItem item2 = new QuizItem(2,"Największy strong man w Polsce", new List<string>() { "Andrzej Błaszczykowski", "Michał Mazur", "Adam Małysz" }, "Mariusz Pudzianowski");
            QuizItem item3 = new QuizItem(3, "Najwyższy szczyt w tatrach", new List<string>() { "Śnierzka", "Gerlach", "Mnich" }, "Rysy");
            QuizItem item4 = new QuizItem(4, "Najbardziej Poularny Alkohol", new List<string>() { "Śliwowica", "Wódka Czysta", "Cytrynówka" }, "Wiśniówka");
            QuizItem item5 = new QuizItem(5, "Najstarsza uczelnia w Europie w jakim państwie była", new List<string>() { "Budapeszt", "Berlin", "Kraków" }, "Praga");

            quizItemRepo.Add(item1);
            quizItemRepo.Add(item2);
            quizItemRepo.Add(item3);
            quizItemRepo.Add(item4);
            quizItemRepo.Add(item5);

            Quiz quiz1 = new Quiz(1,quizItemRepo.FindAll().Where(i => i.Id >= 1 && i.Id <= 3).ToList<QuizItem>(),"Quiz o Polsce");
            Quiz quiz2 = new Quiz(1,quizItemRepo.FindAll().Where(i => i.Id >= 3 && i.Id <= 5).ToList<QuizItem>(),"Quiz o Europie");

            quizRepo.Add(quiz1);
            quizRepo.Add(quiz2);

        }
    }
}