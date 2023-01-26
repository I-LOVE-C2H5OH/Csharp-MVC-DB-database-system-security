using Web_api_tour.Data;

namespace Web_api_tour.SQL
{
    public interface SQL
    {
        public Task<List<Contract>> allOrders();

        public Task<List<Tour>> allTours();

        public bool execute(string Command);
        public Task<List<Client>> allclients(string Command);

        public Task<bool> addNewRecord<T>(T data);
    }
}
