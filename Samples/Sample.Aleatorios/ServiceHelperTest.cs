using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Sample.Aleatorios
{

    public class ServiceHostInfo
    {
        /// <summary>
        /// Nome do servidor;
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// Aceita o nome parcial do servidor;
        /// </summary>
        public bool Partial { get; set; }
        /// <summary>
        /// Endereço do serviço;
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Indica se a configuração é padrão em modo RELEASE;
        /// </summary>
        public bool DefaultForRelease { get; set; }
        /// <summary>
        /// Indica se a configuração é padrão em modo DEBUG;
        /// </summary>
        public bool DefaultForDebug { get; set; }
    }

    public class ServiceInfo
    {
        /// <summary>
        /// Nome;
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Lista de configuração por servidor;
        /// </summary>
        public List<ServiceHostInfo> HostInfoCollection { get; set; }

        /// <summary>
        /// Método que retorna a configuração ideal para o serviço/servidor;
        /// </summary>
        /// <param name="hostName">Nome do servidor</param>
        /// <returns>Configuração</returns>
        public string GetEndPointAddress(string hostName)
        {
            return GetEndPointAddress(hostName, false);
        }

        /// <summary>
        /// Método que retorna a configuração ideal para o serviço/servidor;
        /// </summary>
        /// <param name="hostName">Nome do servidor</param>
        /// <param name="debug">Módo DEBUG</param>
        /// <returns>Configuração</returns>
        public string GetEndPointAddress(string hostName, bool debug)
        {
            ServiceHostInfo host = null;

            if (HostInfoCollection != null && HostInfoCollection.Count > 0)
            {

                host = (from c in HostInfoCollection
                        where c.HostName.ToLower() == hostName.ToLower()
                        select c).FirstOrDefault();

                if (host == null)
                {
                    host = (from c in HostInfoCollection
                            where hostName.ToLower().Contains(c.HostName.ToLower()) && c.Partial.Equals(true)
                            orderby c.HostName descending
                            select c).FirstOrDefault();

                    host = (from c in HostInfoCollection
                            where string.Concat("//", hostName.ToLower()).Contains(string.Concat("//", c.HostName.ToLower())) && c.Partial.Equals(true)
                            orderby c.HostName descending
                            select c).FirstOrDefault();


                    host = (from c in HostInfoCollection
                            where hostName.ToLower().Contains(c.HostName.ToLower()) && c.Partial.Equals(true)
                            select c).ToList().OrderByDescending(o => o.HostName).FirstOrDefault();



                    var lhost = (from c in HostInfoCollection
                                 where hostName.ToLower().Contains(c.HostName.ToLower()) && c.Partial.Equals(true)
                                 orderby c.HostName descending
                                 select c).ToList();

                    if (lhost.Count > 0)
                        host = lhost[0];
                }

                if (host == null && debug.Equals(false))
                    host = (from c in HostInfoCollection
                            where c.DefaultForRelease == true
                            select c).FirstOrDefault();

                if (host == null && debug.Equals(true))
                    host = (from c in HostInfoCollection
                            where c.DefaultForDebug == true
                            select c).FirstOrDefault();
            }

            return host != null ? host.Address : "";
        }
    }

    public class ServiceHelper
    {
        /// <summary>
        /// Código do sistema;
        /// </summary>
        private string _applicationName;
        /// <summary>
        /// Dados do arquivo de configuração;
        /// </summary>
        private XmlDocument _xmlDocument;
        /// <summary>
        /// Coleção de configurações de serviço;
        /// </summary>
        private List<ServiceInfo> _serviceInfoCollection;
        /// <summary>
        /// Coleção de configurações de serviço;
        /// </summary>
        public List<ServiceInfo> ServiceInfoCollection
        {
            get
            {
                Load(_fileName);

                return _serviceInfoCollection;
            }
        }
        /// <summary>
        /// Nome do arquivo de configuração;
        /// </summary>
        private string _fileName = "";
        /// <summary>
        /// Informação de data e hora do arquivo de configuração;
        /// </summary>
        private DateTime _fileDate = DateTime.Now;

        /// <summary>
        /// Classe auxiliar para leitura do arquivo de configuração;
        /// </summary>
        /// <param name="applicationName">Código do sistema</param>
        public ServiceHelper(string applicationName) :
            this(applicationName, "")
        {
        }

        /// <summary>
        /// Classe auxiliar para leitura do arquivo de configuração;
        /// </summary>
        /// <param name="applicationName">Código do sistema</param>
        /// <param name="fileName">Nome do arquivo</param>
        public ServiceHelper(string applicationName, string fileName)
        {
            _applicationName = applicationName;

            if (fileName.Length > 0)
                Load(fileName);
        }

        /// <summary>
        /// Método para obter a configuração do serviço;
        /// </summary>
        /// <returns>Configuração do serviço</returns>
        public ServiceInfo GetServiceInfo()
        {
            Load(_fileName);

            if (_serviceInfoCollection.Count == 1)
                return _serviceInfoCollection[0];
            else
                return null;
        }

        /// <summary>
        /// Método para obter a configuração do serviço;
        /// </summary>
        /// <param name="serviceName">Nome do serviço</param>
        /// <returns>Configuração do serviço</returns>
        public ServiceInfo GetServiceInfo(string serviceName)
        {
            Load(_fileName);

            if (_serviceInfoCollection.Count > 0)
                return (from c in _serviceInfoCollection
                        where c.Name.ToLower() == serviceName.ToLower()
                        select c).FirstOrDefault();
            else
                return null;
        }

        /// <summary>
        /// Método que carrega as configurações;
        /// </summary>
        /// <param name="fileName">Nome do arquivo</param>
        public void Load(string fileName)
        {
            _fileName = fileName;

            if (UpdateConfiguration().Equals(true))
            {
                _xmlDocument = new XmlDocument();
                _xmlDocument.Load(_fileName);

                LoadConfiguration();

                _xmlDocument = null;
            }
        }

        /// <summary>
        /// Método que carrega as configurações;
        /// </summary>
        private void LoadConfiguration()
        {
            XmlNodeList serviceCollection = _xmlDocument.SelectNodes(string.Concat("Configuration/Application[@Name='", _applicationName, "']/Services/Service"));
            XmlAttribute attribute = null;
            ServiceInfo serviceInfo;
            XmlNodeList hostCollection;

            if (serviceCollection != null && serviceCollection.Count > 0)
            {
                _serviceInfoCollection = new List<ServiceInfo>();

                foreach (XmlNode serviceItem in serviceCollection)
                {
                    attribute = serviceItem.Attributes.Count > 0 ? GetAttribute(serviceItem, "Name") : null;
                    serviceInfo = new ServiceInfo()
                    {
                        Name = (attribute != null) ? attribute.Value : "",
                        HostInfoCollection = new List<ServiceHostInfo>()
                    };

                    hostCollection = serviceItem.SelectNodes("Host");

                    foreach (XmlNode hostItem in hostCollection)
                    {
                        serviceInfo.HostInfoCollection.Add(new ServiceHostInfo()
                        {
                            HostName = GetAttribute(hostItem, "Name").Value,
                            Partial = GetAttribute(hostItem, "PartialName").Value == "1" ? true : false,
                            Address = GetAttribute(hostItem, "Address").Value,
                            DefaultForRelease = GetAttribute(hostItem, "DefaultRelease").Value == "1" ? true : false,
                            DefaultForDebug = GetAttribute(hostItem, "DefaultForDebug").Value == "1" ? true : false
                        });
                    }

                    _serviceInfoCollection.Add(serviceInfo);
                }
            }
        }

        /// <summary>
        /// Método para retornar um atributo do elemento;
        /// </summary>
        /// <param name="node">Elemento</param>
        /// <param name="attributeName">Nome do atributo</param>
        /// <returns>Atributo</returns>
        private System.Xml.XmlAttribute GetAttribute(System.Xml.XmlNode node, string attributeName)
        {
            XmlAttribute attribute = null;

            if (node != null && node.Attributes.Count > 0)
                attribute = node.Attributes[attributeName];

            return attribute;
        }

        /// <summary>
        /// Método para verificar se houve uma alteração no arquivo de configuração;
        /// </summary>
        /// <returns>Indica se o as informações devem ser atualizadas</returns>
        private bool UpdateConfiguration()
        {
            bool update = false;

            try
            {
                if (System.IO.File.Exists(_fileName).Equals(true))
                    if (_fileDate != System.IO.File.GetLastWriteTime(_fileName))
                    {
                        _fileDate = System.IO.File.GetLastWriteTime(_fileName);
                        update = true;
                    }
            }
            catch (Exception)
            {
            }

            return update;
        }
    }

    public class ServiceHelpTest
    {

        public static void Run()
        {
            ServiceInfo si = new ServiceInfo();
            ServiceHelper sh = new ServiceHelper("NORISKSITE");

            si.HostInfoCollection = new List<ServiceHostInfo>();

            //sh.Load(@"C:\Inetpub\wwwroot\NORISKSITE\config\norisksite\service.config");
            si.HostInfoCollection.Add(new ServiceHostInfo()
            {
                HostName = "BBAWEB",
                Partial = true,
                Address = "end: bbaweb",
                DefaultForRelease = true,
                DefaultForDebug = true
            });
            si.HostInfoCollection.Add(new ServiceHostInfo()
            {
                HostName = "MV",
                Partial = true,
                Address = "end: mv",
                DefaultForRelease = true,
                DefaultForDebug = true
            });
            si.HostInfoCollection.Add(new ServiceHostInfo()
            {
                HostName = "BBAWEBN1ATS",
                Partial = true,
                Address = "end: BBAWEBN1ATS",
                DefaultForRelease = true,
                DefaultForDebug = true
            });
            si.HostInfoCollection.Add(new ServiceHostInfo()
            {
                HostName = "localhost",
                Partial = false,
                Address = "end: localhost",
                DefaultForRelease = true,
                DefaultForDebug = true
            });

            Console.WriteLine(si.GetEndPointAddress("BBAWEBN1ATS1S"));
            Console.WriteLine(si.GetEndPointAddress("BBAWEBN1AT"));
            Console.WriteLine(si.GetEndPointAddress("BBAWEBLB-ATS-S"));

            Console.WriteLine(si.GetEndPointAddress(System.Net.Dns.GetHostName()));
            //CustomBinding_ISearch

            Console.Read();
        }

    }
}
