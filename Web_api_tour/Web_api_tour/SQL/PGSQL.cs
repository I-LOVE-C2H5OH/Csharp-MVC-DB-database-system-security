using Npgsql;
using Web_api_tour.Data;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Web_api_tour.SQL
{
    public class PGSQL :SQL
    {
        NpgsqlConnection conn = new NpgsqlConnection();

        string connConnection = "";

        static Semaphore sem = new Semaphore(1, 1);

        bool isOpen = false;

        public PGSQL(string host, string username, string password, string database, string port = "5432")
        {
            var connString = $"Host={host}:{port};Username={username};Password={password};Database={database}";

            connConnection = connString;
            conn = new NpgsqlConnection(connString);
        }

        public bool execute(string Command)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tour>> allTours()
        {
            List<Tour> tours = await gettours();

            foreach (var tour in tours)
            {
                tour.excursions = await GetExcursionFromTourID(tour.id);
            }
            return tours;
        }

        public async Task<List<Contract>> allOrders()
        {
            
            var contracts = await GetContracts();

            foreach (var contract in contracts)
            {
                contract.client = await GetClientsfromContracvtID(contract.contractID);
                contract.excursions = await GetExcursionFromTourID(contract.tourID);
                
                foreach (var excursion in contract.excursions)
                {
                    excursion.shedule = await GetExcursionShedulesFromExcurionIDAndDayOfWeekAndDayCount(excursion.id, contract.date_of_signing.Value, contract.duration);
                }
            }
            return contracts;
        }

        private async Task<List<Contract>> GetContracts()
        {
            sem.WaitOne();
            List<Contract> contracts = new List<Contract>();
            try
            {
                await Open();
                using (NpgsqlCommand command = conn.CreateCommand())
                {

                    command.CommandText = $"SELECT * FROM allcontractInfo;";
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Contract contract = new Contract
                            {
                                contractID = reader.GetInt32(0),
                                tourID = reader.GetInt32(1),
                                date_of_issue = reader.GetDateTime(2),
                                date_of_signing = reader.GetDateTime(3),
                                tourName = reader.GetString(4),
                                cost = reader.GetInt32(5),
                                duration = reader.GetInt32(6)
                            };

                            contracts.Add(contract);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            await Close();
            sem.Release();
            return contracts;
        }

        private async Task<List<Client>> GetClientsfromContracvtID(int contractID)
        {
            sem.WaitOne();
            List <Client> clients = new List<Client>();

            try
            {
                await Open();
                using (NpgsqlCommand command = conn.CreateCommand())
                {

                    command.CommandText = $"SELECT * FROM allclienttocontractInfo where contract_id = {contractID};";
                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {

                        while (await reader.ReadAsync())
                        {
                            Client client = new Client
                            {
                                id = reader.GetInt32(0),
                                Fname = reader.GetString(2),
                                Lname = reader.GetString(3),
                                phone = reader.GetString(4),
                                mail = reader.GetString(5)
                            };

                            clients.Add(client);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            await Close();
            sem.Release();
            return clients;
        }

        private async Task<List<Excursion>> GetExcursionFromTourID(int tourID)
        {
            sem.WaitOne();
            List<Excursion> excursions = new List<Excursion>();

            try
            {
                using (NpgsqlCommand command = conn.CreateCommand())
                {

                    command.CommandText = $"SELECT * FROM excursion where tour_id = {tourID};";

                    await Open();
                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {

                        while (reader.Read())
                        {
                            Excursion excursion = new Excursion
                            {
                                id = reader.GetInt32(0),
                                excursionName = reader.GetString(2)
                            };

                            excursions.Add(excursion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            await Close();
            sem.Release();
            return excursions;
        }

        private async Task<List<ExcursionShedule>> GetExcursionShedulesFromExcurionIDAndDayOfWeekAndDayCount(int excurionID, DateTime date, int dayCount)
        {
            sem.WaitOne();
            List<ExcursionShedule> excursionShedules = new List<ExcursionShedule>();

            try
            {
                await Open();
                using (NpgsqlCommand command = conn.CreateCommand())
                {

                    command.CommandText = $"select * from excursionshedule where excursion_id = {excurionID};";
                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {

                        while (await reader.ReadAsync())
                        {
                            for (int i = 0; i < dayCount; i++)
                            {
                                var datee = date.AddDays(i);

                                var dayweek = datee.DayOfWeek.ToString();

                                ExcursionShedule excursionShedule = new ExcursionShedule
                                {
                                    sheduleID = reader.GetInt32(0),
                                    dayWeek = reader.GetString(2),
                                    date = datee.Date
                                };


                                if (dayweek == excursionShedule.dayWeek && !excursionShedules.Contains(excursionShedule))
                                    excursionShedules.Add(excursionShedule);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            await Close();
            sem.Release();
            return excursionShedules;
        }

        private async Task<List<Tour>> gettours()
        {
            sem.WaitOne();
            List<Tour> tours = new List<Tour>();
            try
            {
                using (NpgsqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM tour;";
                    await Open();
                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {

                        while (await reader.ReadAsync())
                        {
                            Tour tour = new Tour
                            {
                                id = reader.GetInt32(0),
                                tourName = reader.GetString(1),
                                duration = reader.GetInt32(2),
                                cost = reader.GetInt32(3)
                            };

                            tours.Add(tour);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            await Close();

            sem.Release();
            return tours;
        }

        public async Task<bool> addNewRecord<T>(T data)
        {

            Type typeParameterType = typeof(T);

            bool returned = false;

            switch (typeParameterType.Name)
            {
                case "Client":
                    returned = await addnewClient(data as Client);
                    break;
                case "ContractOrder":
                    returned = await addnewContract(data as ContractOrder);
                    break;
            }

            return returned;
        }
        private async Task<bool> addnewContract(ContractOrder? cl)
        {
            sem.WaitOne();

            try
            {
                await Open();

                int tourCount = 1;

                using (NpgsqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = $"select count(*) from contract;";
                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {

                        while (await reader.ReadAsync())
                        {
                            tourCount += reader.GetInt32(0);
                        }
                    }
                }

                var date = DateTime.ParseExact(cl.date_of_issue, "yyyy-MM-dd", null);


                DateOnly s = DateOnly.ParseExact(cl.date_of_issue, "yyyy-MM-dd");

                using var cmd = new NpgsqlCommand("call addNewContract(($1), ($2));", conn)
                {
                    Parameters =
                {
                    new() { Value = int.Parse(cl.tourID)},
                    new() { Value = s}
                }
                };
                cmd.ExecuteNonQuery();

                foreach (var client in cl.clientID)
                {
                    using var cmd1 = new NpgsqlCommand("call addNewboundle(($1), ($2));", conn)
                    {
                        Parameters =
                {
                    new() { Value = tourCount },
                    new() { Value = int.Parse(client) },
                }
                    };
                    cmd1.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            await Close();
            sem.Release();
            return false;
        }

        private async Task<bool> addnewClient(Client? cl)
        {
            //firstname VARCHAR(50), lastname VARCHAR(50), phon VARCHAR(15), emai VARCHAR(100), passpor VARCHAR(100)

            // call addNewClient('John', 'Doe', '+123456789', 'jon@example.com', 'ABCDEFGHIJKLMNOPQRSTUVWXYS');

            sem.WaitOne();

            try
            {
                await Open();

                using var cmd = new NpgsqlCommand("call addNewClient(($1), ($2), ($3), ($4), ($5));", conn)
                {
                    Parameters =
                {
                    new() { Value = cl.Fname },
                    new() { Value = cl.Lname },
                    new() { Value = cl.phone },
                    new() { Value = cl.mail },
                    new() { Value = cl.passport },
                }
                };
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            await Close();
            sem.Release();
            return false;
        }

        public async Task<List<Client>> allclients(string Command)
        {
            sem.WaitOne();
            List<Client> clients = new List<Client>();
            
            try
            {
                using (NpgsqlCommand command = conn.CreateCommand())
                {

                    command.CommandText = $"SELECT * FROM allclienttoInfo;";

                    await Open();
                    using (var reader = await command.ExecuteReaderAsync())
                    {

                        while (await reader.ReadAsync())
                        {
                            Client client = new Client
                            {
                                id = reader.GetInt32(0),
                                Fname = reader.GetString(1),
                                Lname = reader.GetString(2),
                                phone = reader.GetString(3),
                                mail = reader.GetString(4),
                            };

                            clients.Add(client);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            await Close();
            sem.Release();
            return clients;
        }

        bool isClose()
        {
            while (isOpen)
            {
                Thread.Sleep(15);
            }
            return true;
        }

        async Task<bool> Open()
        {
            try
            {
                await Task.Delay(25);
                await Task.Run(isClose);
                if (!isOpen)
                {
                    isOpen = true;
                    await conn.OpenAsync();
                    return true;
                }

            }
            catch
            {

            }
            return false;
        }

        async Task<bool> Close()
        {
            try
            {
                if (isOpen)
                {
                    await conn.CloseAsync();
                    isOpen = false;
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }
    }
}
