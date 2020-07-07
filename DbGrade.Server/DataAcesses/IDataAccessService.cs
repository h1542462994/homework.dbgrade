using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.DbGrade.Server.DataAcesses
{
    public abstract class DataAccessServiceBase
    {
        protected virtual void OnConfiguration(DataAccessBuilder builder) { }

    }
}
