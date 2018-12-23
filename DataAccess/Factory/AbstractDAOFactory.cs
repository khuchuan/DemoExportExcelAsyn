using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.DAO;

namespace DataAccess.Factory
{
    public abstract class AbstractDAOFactory
    {
        public static AbstractDAOFactory Instance()
        {
            try
            {
                return (AbstractDAOFactory)new ADODAOFactory();
            }
            catch (Exception ex)
            {
                Paygate.Utility.NLogLogger.PublishException(ex);
                throw new Exception("Couldn't create AbstractDAOFactory: ");
            }
        }

        public abstract IExportSearchDAO CreateExportSearchDAO();

    }
}
