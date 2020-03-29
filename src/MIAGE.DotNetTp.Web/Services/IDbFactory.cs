using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MIAGE.DotNetTp.Web.Services
{
    public interface IDbFactory
    {
        IMongoDatabase Database { get; }
    }
}
