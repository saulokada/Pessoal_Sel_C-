using System.IO;
using System.Configuration;

namespace Selenium.Utils
{
    public static class CaminhoDoBrowser
    {

        //Diretório de drivers fica 3 níveis abaixo do diretório da solution
        //..\..\..\Drivers\DriverName
        public static string PegaCaminho(string browser)
        {
            string _caminhoDaSolution = System.AppDomain.CurrentDomain.BaseDirectory;
            string _caminhoRelativoDriver = string.Empty;
            string _caminhoDriver = string.Empty;

            if (System.Configuration.ConfigurationManager.AppSettings[browser] != null)
                _caminhoRelativoDriver = ConfigurationManager.AppSettings[browser];

            _caminhoDriver = Path.GetFullPath(Path.Combine(_caminhoDaSolution, _caminhoRelativoDriver));

            return _caminhoDriver;
        }
    }
}
