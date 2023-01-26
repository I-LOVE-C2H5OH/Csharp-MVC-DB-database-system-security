namespace Web_api_tour.Data
{
    public class Contract
    {
        public int contractID { get; set; }
        public int tourID { get; set; }
        public DateTime? date_of_issue { get; set; }
        public DateTime? date_of_signing { get; set; }
        public string? tourName { get; set; }
        public int cost { get; set; }
        public List<Client>? client { get; set; }
        public List<Excursion>? excursions { get; set; }
        public int duration { get; set; }
    }

    class ContractOrder
    {
        public string? tourID { get; set; }
        public string? date_of_issue { get; set; }
        public string? cost { get; set; }
        public List<string>? clientID { get; set; }
    }

    public class Tour
    {
        public int id { get; set; }

        public string? tourName { get; set; }

        public int duration { get; set; }

        public int cost { get; set; }
        public List<Excursion>? excursions { get; set; }
    }

    public class Client
    {
        public int id { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? phone { get; set; }
        public string? passport { get; set; }
        public string? mail { get; set; }
    }

    public class Excursion
    {
        public int id { get; set; }
        public int tourId { get; set; }
        public string? excursionName { get; set; }
        public List<ExcursionShedule>? shedule { get; set; }
    }

    public class ExcursionShedule
    {
        public int sheduleID { get; set; }
        public int excursionId { get; set; }
        public string? dayWeek { get; set; }

        public DateTime date { get; set; }
    }
}
