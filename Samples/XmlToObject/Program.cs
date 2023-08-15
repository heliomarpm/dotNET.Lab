using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace XmlToObject
{
    [Serializable()]
    public class Pessoa
    {
        //[XmlElementAttribute("StockNumber")]
        public string Nome { get; set; }

        //[XmlElementAttribute("Make")]
        public int Idade { get; set; }

        public string SobreNome { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //string file = File.ReadAllText("Planilhas.xml");
            //using (var fs = XmlReader.Create(new StringReader(file)))
            //{
            //    fs.MoveToElement();
            //    var xs = new XmlSerializer(typeof(PlanilhasCollection));
            //    var pc = (PlanilhasCollection)xs.Deserialize(fs);
            //    Console.WriteLine(pc.Planilha.Count());
            //}

            using (var fs = new FileStream("Planilhas.xml", FileMode.Open))
            {
                var xs = new XmlSerializer(typeof(PlanilhasCollection));
                var pc = (PlanilhasCollection)xs.Deserialize(fs);
                Console.WriteLine(pc.Planilha.Count());
            }

            string sXML = "<Pessoa><Nome>Heliomar</Nome><Idade>35</Idade></Pessoa>";

            var sr = new StringReader(sXML);
            Pessoa pessoa;

            using (var xr = XmlReader.Create(sr))
            {
                xr.MoveToElement();
                var xObj = new XmlSerializer(typeof(Pessoa));

                pessoa = (Pessoa)xObj.Deserialize(xr);
            }

            sXML = "<Operacao><CodigoOperacao>OP001</CodigoOperacao><CodigoSistema>1</CodigoSistema><NomeSistema>BY5</NomeSistema><NomeProduto>SWAP</NomeProduto></Operacao>";

            sr = new StringReader(sXML);
            Operacao oper;

            using (var xr = XmlReader.Create(sr))
            {
                xr.MoveToElement();
                var xObj = new XmlSerializer(typeof(Operacao));

                oper = (Operacao)xObj.Deserialize(xr);
            }

        }
    }

    [Serializable()]
    public class Operacao
    {
        private string codigoOperacaoField;
        private int codigoSistemaField;
        private string nomeSistemaField;
        private string nomeProdutoField;
        private System.Nullable<System.DateTime> dataInicioField;
        private System.Nullable<System.DateTime> dataFimField;
        private decimal valorOperacaoField;
        private string codigoLimiteOriginalField;
        private string codigoLimiteField;
        private System.Nullable<decimal> valorRCPOriginalField;
        private int iC_SOLICITADOField;
        private System.Nullable<decimal> valorRcpField;
        private System.Nullable<decimal> valorMtmField;
        private string codigoOperadorField;
        private System.Nullable<System.DateTime> dataRegistroOperadorField;
        private string codigoOperadorRiscoField;
        private System.Nullable<System.DateTime> dataRegistroRiscoField;
        private string descricaoMotivoField;
        private System.Nullable<System.DateTime> dataAtualizacaoField;
        private string nomeIndexador1Field;
        private string nomeIndexador2Field;
        private int statusOperacaoField;
        private string reservaOperadorField;
        private string parIndexadorField;
        private string codigoAuditorField;
        private System.DateTime dataAprovacaoField;
        private System.Nullable<int> codigoTipoOperacaoNDFField;
        private System.Nullable<int> codigoTipoOpcaoField;
        private System.Nullable<int> codigoTipoOperacaoField;
        private System.Nullable<decimal> valorStrikeField;
        private System.Nullable<bool> valorRCPCadastradoField;
        private System.Nullable<bool> auditadoField;
        private string nomeIndexadorRcpBancoField;
        private string nomeIndexadorRcpClienteField;
        private string nomeIndexadorRcpBancoOriginalField;
        private string nomeIndexadorRcpClienteOriginalField;
        //private Limite limiteField;
        //private Limite limiteOriginalField;
        private bool combinacaoPassivaField;

        /// <remarks/>
        [XmlElementAttribute(Order = 0)]
        public string CodigoOperacao
        {
            get
            {
                return this.codigoOperacaoField;
            }
            set
            {
                this.codigoOperacaoField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 1)]
        public int CodigoSistema
        {
            get
            {
                return this.codigoSistemaField;
            }
            set
            {
                this.codigoSistemaField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 2)]
        public string NomeSistema
        {
            get
            {
                return this.nomeSistemaField;
            }
            set
            {
                this.nomeSistemaField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 3)]
        public string NomeProduto
        {
            get
            {
                return this.nomeProdutoField;
            }
            set
            {
                this.nomeProdutoField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(IsNullable = true, Order = 4)]
        public System.Nullable<System.DateTime> DataInicio
        {
            get
            {
                return this.dataInicioField;
            }
            set
            {
                this.dataInicioField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(IsNullable = true, Order = 5)]
        public System.Nullable<System.DateTime> DataFim
        {
            get
            {
                return this.dataFimField;
            }
            set
            {
                this.dataFimField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 6)]
        public decimal ValorOperacao
        {
            get
            {
                return this.valorOperacaoField;
            }
            set
            {
                this.valorOperacaoField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 7)]
        public string CodigoLimiteOriginal
        {
            get
            {
                return this.codigoLimiteOriginalField;
            }
            set
            {
                this.codigoLimiteOriginalField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 8)]
        public string CodigoLimite
        {
            get
            {
                return this.codigoLimiteField;
            }
            set
            {
                this.codigoLimiteField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(IsNullable = true, Order = 9)]
        public System.Nullable<decimal> ValorRCPOriginal
        {
            get
            {
                return this.valorRCPOriginalField;
            }
            set
            {
                this.valorRCPOriginalField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 10)]
        public int IC_SOLICITADO
        {
            get
            {
                return this.iC_SOLICITADOField;
            }
            set
            {
                this.iC_SOLICITADOField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(IsNullable = true, Order = 11)]
        public System.Nullable<decimal> ValorRcp
        {
            get
            {
                return this.valorRcpField;
            }
            set
            {
                this.valorRcpField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(IsNullable = true, Order = 12)]
        public System.Nullable<decimal> ValorMtm
        {
            get
            {
                return this.valorMtmField;
            }
            set
            {
                this.valorMtmField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 13)]
        public string CodigoOperador
        {
            get
            {
                return this.codigoOperadorField;
            }
            set
            {
                this.codigoOperadorField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(IsNullable = true, Order = 14)]
        public System.Nullable<System.DateTime> DataRegistroOperador
        {
            get
            {
                return this.dataRegistroOperadorField;
            }
            set
            {
                this.dataRegistroOperadorField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 15)]
        public string CodigoOperadorRisco
        {
            get
            {
                return this.codigoOperadorRiscoField;
            }
            set
            {
                this.codigoOperadorRiscoField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(IsNullable = true, Order = 16)]
        public System.Nullable<System.DateTime> DataRegistroRisco
        {
            get
            {
                return this.dataRegistroRiscoField;
            }
            set
            {
                this.dataRegistroRiscoField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 17)]
        public string DescricaoMotivo
        {
            get
            {
                return this.descricaoMotivoField;
            }
            set
            {
                this.descricaoMotivoField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(IsNullable = true, Order = 18)]
        public System.Nullable<System.DateTime> DataAtualizacao
        {
            get
            {
                return this.dataAtualizacaoField;
            }
            set
            {
                this.dataAtualizacaoField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 19)]
        public string NomeIndexador1
        {
            get
            {
                return this.nomeIndexador1Field;
            }
            set
            {
                this.nomeIndexador1Field = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 20)]
        public string NomeIndexador2
        {
            get
            {
                return this.nomeIndexador2Field;
            }
            set
            {
                this.nomeIndexador2Field = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 21)]
        public int StatusOperacao
        {
            get
            {
                return this.statusOperacaoField;
            }
            set
            {
                this.statusOperacaoField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 22)]
        public string ReservaOperador
        {
            get
            {
                return this.reservaOperadorField;
            }
            set
            {
                this.reservaOperadorField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 23)]
        public string ParIndexador
        {
            get
            {
                return this.parIndexadorField;
            }
            set
            {
                this.parIndexadorField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 24)]
        public string CodigoAuditor
        {
            get
            {
                return this.codigoAuditorField;
            }
            set
            {
                this.codigoAuditorField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 25)]
        public System.DateTime DataAprovacao
        {
            get
            {
                return this.dataAprovacaoField;
            }
            set
            {
                this.dataAprovacaoField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(IsNullable = true, Order = 26)]
        public System.Nullable<int> CodigoTipoOperacaoNDF
        {
            get
            {
                return this.codigoTipoOperacaoNDFField;
            }
            set
            {
                this.codigoTipoOperacaoNDFField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(IsNullable = true, Order = 27)]
        public System.Nullable<int> CodigoTipoOpcao
        {
            get
            {
                return this.codigoTipoOpcaoField;
            }
            set
            {
                this.codigoTipoOpcaoField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(IsNullable = true, Order = 28)]
        public System.Nullable<int> CodigoTipoOperacao
        {
            get
            {
                return this.codigoTipoOperacaoField;
            }
            set
            {
                this.codigoTipoOperacaoField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(IsNullable = true, Order = 29)]
        public System.Nullable<decimal> ValorStrike
        {
            get
            {
                return this.valorStrikeField;
            }
            set
            {
                this.valorStrikeField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(IsNullable = true, Order = 30)]
        public System.Nullable<bool> ValorRCPCadastrado
        {
            get
            {
                return this.valorRCPCadastradoField;
            }
            set
            {
                this.valorRCPCadastradoField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(IsNullable = true, Order = 31)]
        public System.Nullable<bool> Auditado
        {
            get
            {
                return this.auditadoField;
            }
            set
            {
                this.auditadoField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 32)]
        public string NomeIndexadorRcpBanco
        {
            get
            {
                return this.nomeIndexadorRcpBancoField;
            }
            set
            {
                this.nomeIndexadorRcpBancoField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 33)]
        public string NomeIndexadorRcpCliente
        {
            get
            {
                return this.nomeIndexadorRcpClienteField;
            }
            set
            {
                this.nomeIndexadorRcpClienteField = value;

            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 34)]
        public string NomeIndexadorRcpBancoOriginal
        {
            get
            {
                return this.nomeIndexadorRcpBancoOriginalField;
            }
            set
            {
                this.nomeIndexadorRcpBancoOriginalField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute(Order = 35)]
        public string NomeIndexadorRcpClienteOriginal
        {
            get
            {
                return this.nomeIndexadorRcpClienteOriginalField;
            }
            set
            {
                this.nomeIndexadorRcpClienteOriginalField = value;
            }
        }

        /// <remarks/>
        //[XmlElementAttribute(Order = 36)]
        //public Limite Limite
        //{
        //    get
        //    {
        //        return this.limiteField;
        //    }
        //    set
        //    {
        //        this.limiteField = value;
        //        this.RaisePropertyChanged("Limite");
        //    }
        //}

        ///// <remarks/>
        //[XmlElementAttribute(Order = 37)]
        //public Limite LimiteOriginal
        //{
        //    get
        //    {
        //        return this.limiteOriginalField;
        //    }
        //    set
        //    {
        //        this.limiteOriginalField = value;
        //        this.RaisePropertyChanged("LimiteOriginal");
        //    }
        //}

        /// <remarks/>
        [XmlElementAttribute(Order = 38)]
        public bool CombinacaoPassiva
        {
            get
            {
                return this.combinacaoPassivaField;
            }
            set
            {
                this.combinacaoPassivaField = value;

            }
        }
    }
}
