using ServiceContract;
namespace Services
{
    public class CitiesService : ICitiesService
    {

        private List<string> _cities;
        private Guid _serviceInstanceId;
        public Guid ServiceInstanceId {
            get 
            {   
                return _serviceInstanceId;
            }
        }
        public CitiesService() 
        {
            _serviceInstanceId = Guid.NewGuid();
            _cities = new List<string>()
            {
                "Cairo",
                "Rebat",
                "Alex",
                "Juresalem"
            };
        }
        public List<string> GetCities()
        {
            return _cities;
        }
    }
}