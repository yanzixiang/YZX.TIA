using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.DomainServices.ConnectionService;

namespace YZX.Tia.Extensions.OnlineService
{
  class ConnectorBaseExtensions
  {
    internal ConnectorBase GetConnector(
      ConnectionServiceProvider csp,
      string connectionType)
    {
      return csp.GetConnector(connectionType);
    }
  }
}
