using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.WebUI.Infrastructure.Abstract
{
    public interface I_AuthProvider
    {
        bool Authenticate(string username, string password);
    }
}
