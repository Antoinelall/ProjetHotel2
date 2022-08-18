using Newtonsoft.Json;
using ProjetHotel.Models;

namespace ProjetHotel.Infrastructure
{
    public class SessionManager
    {
        public class UserSession
        {
            public int IdClient { get; set; }
            public string Pseudo { get; set; }
        }


        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            ArgumentNullException.ThrowIfNull(httpContextAccessor.HttpContext);
            _session = httpContextAccessor.HttpContext.Session;
        }

        public void Login(Client client)
        {
            User = new UserSession()
            {
                IdClient = client.IdClient,
                Pseudo = client.Pseudo
            };
        }

        public void Logout()
        {
            _session.Clear();
        }


        public UserSession? User
        {
            get
            {
                if (!_session.Keys.Contains(nameof(User)))
                {
                    return null;
                }

                string json = _session.GetString(nameof(User))!;
                return JsonConvert.DeserializeObject<UserSession>(json)!;
            }

            private set
            {
                _session.SetString(nameof(User), JsonConvert.SerializeObject(value));
            }
        }



        //public string? Pseudo
        //{
        //    get { return _session.GetString(nameof(Pseudo)); }
        //    private set
        //    {
        //        if (value is null)
        //            return;

        //        _session.SetString(nameof(Pseudo), value);
        //    }
        //}

        // Objet dynamique/temporaire uniquement => Exemple panier de course


        //public List<string> Sejour
        //{
        //    get
        //    {
        //        List<string> sejour;
        //        if (!_session.Keys.Contains(nameof(Sejour)))
        //        {
        //            sejour = new List<string>();
        //            _session.SetString(nameof(Sejour), JsonConvert.SerializeObject(sejour));
        //        }
        //        else
        //        {
        //            string json = _session.GetString(nameof(Sejour))!;
        //            sejour = JsonConvert.DeserializeObject<List<string>>(json)!;
        //        }
        //        return sejour;
        //    }

        //    private set
        //    {
        //        _session.SetString(nameof(Sejour), JsonConvert.SerializeObject(value));
        //    }
        //}
    }
}
