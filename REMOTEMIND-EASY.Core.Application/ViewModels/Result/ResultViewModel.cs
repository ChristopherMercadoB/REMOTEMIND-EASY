namespace REMOTEMIND_EASY.Core.Application.ViewModels.Result
{
    public class ResultViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalValue { get; set; }
        public int UserId { get; set; }
        public string Recomendation { get; set; }
        public int? EnterpriseId { get; set; }
        public DateTime Date { get; set; }
    }
}
