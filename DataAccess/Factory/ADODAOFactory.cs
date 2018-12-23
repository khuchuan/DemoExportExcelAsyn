using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.DAO;
using DataAccess.DAOImpl;
using DataAccess.DTO;

namespace DataAccess.Factory
{
    public class ADODAOFactory : AbstractDAOFactory
    {
        public override IExportSearchDAO CreateExportSearchDAO()
        {
            return (IExportSearchDAO)new ExportSearchDAOImpl();
        }


    }
}
