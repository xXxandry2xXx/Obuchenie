using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using NPOI.SS.Formula.Functions;
using WebApplication2.Controllers;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class MessegesRepository 
    {

        private readonly IConfiguration _configuration;
        private readonly ApplicationContext _context;


        public MessegesRepository( IConfiguration configuration, ApplicationContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public List<User> GetAllMassages()
        {
            var masages = _context.Users.ToList();
            return masages;
        }
    }
}
