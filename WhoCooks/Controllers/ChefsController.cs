namespace WhoCooks.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WhoCooks.Data;
    using Microsoft.AspNetCore.Identity;


    public class ChefsController: Controller
    {
        private readonly WhoCooksDbContext _data;
        private UserManager<Chef> _user;

        public ChefsController(UserManager<Chef> user, WhoCooksDbContext data)
        {
            this._user = user;
            this._data = data;
        }
    }
}
