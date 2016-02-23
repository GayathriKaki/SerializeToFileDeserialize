using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeToFileDeserialize
{
    [Serializable()]
    class SerializeForm
    {
        public string username;
        public string password;
        public SerializeForm()
        {

        }
 /// <summary>
    /// Simple constructor to load in values for the fields.
///</summary>
    
        public SerializeForm(string uName, string strPassword)
        {
            this.username = uName;
            this.password = strPassword;
        }
    }
}
