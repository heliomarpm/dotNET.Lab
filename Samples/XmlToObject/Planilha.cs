using System;
using System.Xml.Serialization;

namespace XmlToObject
{
    [Serializable, XmlRoot("PlanilhasCollection")]
    public class PlanilhasCollection
    {
        [XmlArray("Planilhas"), XmlArrayItem("Planilha", type: typeof(Planilha))]
        //[XmlArrayItem("Planilha", type: typeof(Planilha))]
        public Planilha[] Planilha { get; set; }
    }

    public class Planilha
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlAttribute]
        public string Titulo { get; set; }

        [XmlAttribute]
        public bool Ativo { get; set; }

        [XmlAttribute]
        public string ProcedureValidacao { get; set; }

        [XmlAttribute]
        public string ProcedureAlteracao { get; set; }

        [XmlArray("Colunas"), XmlArrayItem("Coluna", type: typeof(Coluna))]
        public Coluna[] Coluna;
    }

    public class Coluna
    {
        //[XmlAttribute]
        [XmlAttribute]
        public string HeaderColuna { get; set; }

        [XmlAttribute]
        public string NomeCampo { get; set; }

        [XmlAttribute]
        public string TipoCampo { get; set; }

        [XmlAttribute]
        public int TamanhoCampo { get; set; }

        [XmlAttribute]
        public bool ColunaChave { get; set; }
    }

}
