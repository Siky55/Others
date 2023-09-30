using PVA_project.Data;

namespace PVA_project.Services
{

    public class MasterService
    {
        internal AppDbContext _context;
        public MasterService(AppDbContext context)
        {
            _context = context;
        }
    }
}
