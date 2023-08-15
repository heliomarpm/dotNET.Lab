//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using IBBA.WebRiskV4.Xml;

namespace Sample.Aleatorios
{

    //public class ServiceLoader
    //{
    //    /// <summary>
    //    /// Dados do arquivo de configuração;
    //    /// </summary>
    //    private XmlNodes _xmlNodes;

    //    /// <summary>
    //    /// Método que carrega as configurações;
    //    /// </summary>
    //    /// <param name="fileName">Nome do arquivo</param>
    //    public void LoadFromXap(string fileName)
    //    {
    //        ServiceHelper.ServiceInfoCollection = new List<ServiceInfo>();

    //        _xmlNodes = (new XmlReader()).LoadFromXap(fileName);

    //        LoadConfiguration();

    //        _xmlNodes = null;
    //    }

    //    /// <summary>
    //    /// Método que carrega as configurações;
    //    /// </summary>
    //    /// <param name="xml">Configuração</param>
    //    /// <returns>Configuração</returns>
    //    public List<ServiceInfo> Load(string xml)
    //    {
    //        ServiceHelper.ServiceInfoCollection = new List<ServiceInfo>();

    //        return AppendLoad(xml);
    //    }

    //    /// <summary>
    //    /// Método que carrega as configurações;
    //    /// </summary>
    //    /// <param name="xml">Configuração</param>
    //    /// <returns>Configuração</returns>
    //    public List<ServiceInfo> AppendLoad(string xml)
    //    {
    //        if (ServiceHelper.ServiceInfoCollection == null)
    //            ServiceHelper.ServiceInfoCollection = new List<ServiceInfo>();

    //        _xmlNodes = (new XmlReader()).LoadXml(xml);

    //        LoadConfiguration();

    //        _xmlNodes = null;

    //        return ServiceHelper.ServiceInfoCollection;
    //    }

    //    /// <summary>
    //    /// Método que carrega as configurações;
    //    /// </summary>
    //    private void LoadConfiguration()
    //    {
    //        XmlNode node = _xmlNodes.SelectSingleNode("Configuration");

    //        if (node != null && node.ChildNodes.Count > 0)
    //            LoadApplicationConfiguration(node);
    //    }

    //    /// <summary>
    //    /// Método que carrega as configurações da aplicação;
    //    /// </summary>
    //    /// <param name="node">Configuração</param>
    //    private void LoadApplicationConfiguration(XmlNode node)
    //    {
    //        XmlNodes nodes;

    //        nodes = node.SelectNodes("Application");

    //        if (nodes != null)
    //            foreach (XmlNode n in nodes)
    //                LoadServicesConfiguration(n);
    //    }

    //    /// <summary>
    //    /// Método que carrega as configurações de serviço;
    //    /// </summary>
    //    /// <param name="node">Configuração da aplicação</param>
    //    private void LoadServicesConfiguration(XmlNode node)
    //    {
    //        XmlNode rootService;

    //        rootService = node.SelectSingleNode("Services");

    //        if (rootService != null && rootService.ChildNodes.Count > 0)
    //            LoadServiceConfiguration(rootService);
    //    }

    //    /// <summary>
    //    /// Método que carrega as configurações dos serviços;
    //    /// </summary>
    //    /// <param name="node">Configuração do serviço</param>
    //    private void LoadServiceConfiguration(XmlNode node)
    //    {
    //        XmlNodes serviceCollection;

    //        serviceCollection = node.SelectNodes("Service");

    //        if (serviceCollection != null && serviceCollection.Count > 0)
    //        {
    //            foreach (XmlNode serviceItem in serviceCollection)
    //                LoadHostConfiguration(serviceItem);
    //        }
    //    }

    //    /// <summary>
    //    /// Método que carrega as configurações dos servidores;
    //    /// </summary>
    //    /// <param name="node">Configuração do serviço</param>
    //    private void LoadHostConfiguration(XmlNode node)
    //    {
    //        XmlAttribute attribute;
    //        ServiceInfo serviceInfo;
    //        XmlNodes hostCollection;

    //        attribute = node.Attributes.Count > 0 ? node.GetAttribute("Name") : null;

    //        serviceInfo = new ServiceInfo()
    //        {
    //            Name = (attribute != null) ? attribute.Value : "",
    //            HostInfoCollection = new List<ServiceHostInfo>()
    //        };

    //        hostCollection = node.SelectNodes("Host");

    //        foreach (XmlNode hostItem in hostCollection)
    //        {
    //            serviceInfo.HostInfoCollection.Add(new ServiceHostInfo()
    //            {
    //                HostName = hostItem.GetAttribute("Name").Value,
    //                Partial = hostItem.GetAttribute("PartialName").Value == "1" ? true : false,
    //                Address = hostItem.GetAttribute("Address").Value,
    //                DefaultForRelease = hostItem.GetAttribute("DefaultRelease").Value == "1" ? true : false,
    //                DefaultForDebug = hostItem.GetAttribute("DefaultForDebug").Value == "1" ? true : false
    //            });
    //        }

    //        ServiceHelper.ServiceInfoCollection.Add(serviceInfo);
    //    }
    //}
}
