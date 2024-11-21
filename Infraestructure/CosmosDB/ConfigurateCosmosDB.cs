using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class ConfigurateCosmosDB : IConfigurateCosmosDB
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IConfigurateCosmosDB
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
