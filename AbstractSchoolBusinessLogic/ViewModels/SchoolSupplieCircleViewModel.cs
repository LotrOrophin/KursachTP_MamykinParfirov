using System.ComponentModel;


namespace AbstractSchoolBusinessLogic.ViewModels
{
    public class SchoolSupplieCircleViewModel
    {
        public int Id { get; set; }
        public int CircleId { get; set; }
        public int SchoolSupplieId { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
