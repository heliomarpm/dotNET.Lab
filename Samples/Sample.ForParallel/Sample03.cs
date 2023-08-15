using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.ForParallel
{
    class Sample03
    {
        private readonly object mutexVtValorPEOriginal = new object();
        private readonly object mutexException = new object();
        private long _numDeIteracoes = 0;
 
        private Exception exceptionThreadParalela = null;
        private AutoResetEvent _sinalTermino;
 
        private Dictionary<DateTime, decimal> _curvaBRL;
        private long _numDeIteracoes = 0;
        private static int _length = 0;

        private static decimal[] _valor;
        public static void Run()
        {
_lenght=10;      
_valor = new  decimal[_lenght];
for (int i = 0; i < 10; i++)
			{
			 
			} } 

        private static void CalcularContribuicaoRiscoOperacao()
        {
                       

_numDeIteracoes = listaDeOperacoes.Count;
            _sinalTermino = new AutoResetEvent(false);
            exceptionThreadParalela = null;
 
            int countLista_ = listaDeOperacoes.Count;
 
            foreach (var operacao in listaDeOperacoes.OrderByDescending(l => l.ValorOperacao))
            {
                List<Object> listParametros = new List<object>();
 
                listParametros.Add(calcularCea);        //0
                listParametros.Add(calculaOperNova);    //1
                listParametros.Add(operacao);           //2
                listParametros.Add(calcularVar1A);      //3
 
                listParametros.Add(operacao.PDOperacao == 0 ? param.PDEstoque : operacao.PDOperacao);        //4
 
                int prazoOperacao = 0;
 
                if (operacao.QtdeDiasPrazoMedio > param.PrazoOperacaoNova)
                    prazoOperacao = param.PrazoOperacaoNova;
                else
                    prazoOperacao = operacao.QtdeDiasPrazoMedio;
 
                listParametros.Add(prazoOperacao);          //5
                listParametros.Add(vKgrupo);                //6
                listParametros.Add(parametrosOriginais);    //7
 
                ThreadPool.QueueUserWorkItem(new WaitCallback(CalcularEmParalelo), listParametros);
            }
 
            if (countLista_ > 0)
            {
                _sinalTermino.WaitOne();
            }
 
            if (exceptionThreadParalela != null)
                throw new Exception(exceptionThreadParalela.Message);
        }
 
        #endregion
 
        #region -- CalcularEmParalelo --
 
        private void CalcularEmParalelo(object parametros)
        {
            try
            {
                ////CalculoCEAUtil _Cea = new CalculoCEAUtil(this._Cea.FormulaParte1, this._Cea.FormulaParte2, this._Cea.InterceptoRegressaoWI, 
                ////                                         this._Cea.CoeficienteRegressaoWI, _Regressao, _RegressaoOriginal, 
                ////                                         this._Cea.Fator_PE_Liquida, this._Cea.KOA, this._Cea.KredutorPisos, this._Cea.KTarget);
                ////_Cea.Idioma = Idioma;
 
                decimal valorEADProjetado = 0;
                decimal valorExposicao = 0;
                decimal valorPerdaEsperada = 0;
                decimal valorExposicaoOriginal = 0;
                decimal valorPerdaEsperadaOriginal = 0;
                ////decimal valorCR = 0;
                ////decimal valorCROriginal = 0;
                decimal Lgd = 0;
 
                int prazoOpBD = 0;
                int prazoMedio = 0;
 
                List<Object> listaDeParametros = (List<object>)parametros;
 
                bool calcularCea = (bool)listaDeParametros[0];
                bool calculaOperNova = (bool)listaDeParametros[1];
                GrupoClientesOperacoesResponse grupoClienteOperacao = (GrupoClientesOperacoesResponse)listaDeParametros[2];
                bool calcularVar1A = (bool)listaDeParametros[3];
                decimal PdOperacaoEstoque = (decimal)listaDeParametros[4];
                int prazoDC = (int)listaDeParametros[5];
                ////decimal[] vKgrupo = listaDeParametros[6] != null ? (decimal[])listaDeParametros[6] : null;
                bool parametrosOriginais = (bool)listaDeParametros[7];
                ////decimal WI = 0;
                decimal pd = 0;
                Lgd = grupoClienteOperacao.PercLgdMitigado;
 
                prazoOpBD = grupoClienteOperacao.QtdeDiasPrazoMedio;
 
                for (int j = 0; j < prazoDC; j++)
                {
                    #region [ calculaOperNova ]
 
                    if (calculaOperNova)
                    {
                        Lgd = param.ListLgdOperacaoNova[j];
                        PdOperacaoEstoque = param.PDOperacao;
                        prazoMedio = param.PrazoMedioOperacaoNovaVetor[j];
                        pd = param.PDOperacao;
                        valorEADProjetado = this.param.EadOperacaoVetor[j];
                    }
                    else
                    {
                        prazoMedio = grupoClienteOperacao.QtdeDiasPrazoMedio - j;
                        valorEADProjetado = Decimal.Multiply(grupoClienteOperacao.ValorOperacaoRaroc, VtFatorCarecagem[j]);
 
                        if (param.PDGrupo != param.PDGrupoOriginal && grupoClienteOperacao.CodigoGrupoCliente == param.CodigoGrupoCliente)
                        {
                            pd = param.PDGrupo;
                        }
                        else
                        {
                            if (param.PDEstoque != param.PDEstoqueOriginal && grupoClienteOperacao.CodigoGrupoCliente != param.CodigoGrupoCliente)
                                pd = param.PDEstoque;
                            else
                                pd = PdOperacaoEstoque;
                        }
                    }
 
                    #endregion
 
                    #region [ calcularVar1A ]
 
                    if (calcularVar1A)
                    {
                        valorExposicao = Decimal.Multiply(valorEADProjetado, Lgd / 100);
                        valorPerdaEsperada = Decimal.Multiply(valorExposicao, pd);
                        ////valorCR = _Cea.VaR1A(VtValorWI[j], valorPerdaEsperada, valorExposicao, false);
 
                        SomaVtValorEAD(j, valorEADProjetado);
                        SomaVtValorExposicao(j, valorExposicao);
                        SomaVtValorPE(j, valorPerdaEsperada);
                        ////SomaContribuicaoSemConcentracao(j, valorCR);
 
                        if (parametrosOriginais)
                        {
                            valorExposicaoOriginal = Decimal.Multiply(valorEADProjetado, Lgd / 100);
                            valorPerdaEsperadaOriginal = Decimal.Multiply(valorExposicao, PdOperacaoEstoque);
 
                            ////WI = _Cea.CalcularWI(param.PDHolding, true);
 
                            ////valorCROriginal = _Cea.VaR1A(WI, valorPerdaEsperadaOriginal, valorExposicaoOriginal, true);
                            SomaVtValorEADOriginal(j, valorEADProjetado);
                            SomaVtValorEADOriginalGrupo(j, valorEADProjetado * (grupoClienteOperacao.CodigoGrupoCliente == param.CodigoGrupoCliente ? 1 : 0));
                            SomaVtValorExposicaoOriginal(j, valorExposicaoOriginal);
                            SomaVtValorPEOriginal(j, valorPerdaEsperadaOriginal);
                            ////SomaContribuicaoSemConcentracaoOriginal(j, valorCROriginal);
                        }
                    }
 
                    #endregion
 
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< --- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    #region [ calcularCea ]
 
                    // Tem que acumular
                    ////if (calcularCea)
                    ////{
                    ////    decimal[] vtValorCalculado;
 
                    ////    if (calculaOperNova)
                    ////        vtValorCalculado = _Cea.VaRRecalibradoOperacao(param.DataReferencia, pd, valorEADProjetado, Lgd, valorCR, vKgrupo[j], grupoClienteOperacao.QtdeDiasPrazoMedio, prazoMedio, param.QtdeDiasPrazoIndeterminado, ref VarRecalibradoResp, j);
                    ////    else
                    ////        vtValorCalculado = _Cea.VaRRecalibradoOperacao(param.DataReferencia, pd, valorEADProjetado, Lgd, valorCR, vKgrupo[j], grupoClienteOperacao.QtdeDiasPrazoMedio, prazoMedio, 0, ref VarRecalibradoResp, j);
 
                    ////    lock (mutexRecalibrado)
                    ////    {
                    ////        VarRecalibradoResp.VaRRecalibrado_BIS_OA[j] += vtValorCalculado[0];
                    ////        VarRecalibradoResp.VaRRecalibrado_BIS_OA_Pisos_Redutor[j] += vtValorCalculado[1];
 
                    ////        if (j == 0)
                    ////        {
                    ////            if (_primeiroCalculoCea.GetValueOrDefault())
                    ////            {
                    ////                grupoClienteOperacao.VaRRecalibrado_BIS_OA_Pisos_Redutor_Antes = vtValorCalculado[1];
                    ////                grupoClienteOperacao.ContribuicaoSemConcentracaoAntes = VtContribuicaoRiscoSemConcentracao[0];
                    ////            }
                    ////            else if (_primeiroCalculoCea.HasValue)
                    ////            {
                    ////                grupoClienteOperacao.VaRRecalibrado_BIS_OA_Pisos_Redutor_Depois = vtValorCalculado[1];
                    ////                grupoClienteOperacao.ContribuicaoSemConcentracaoDepois = VtContribuicaoRiscoSemConcentracao[0];
                    ////            }
                    ////        }
 
                    ////        VarRecalibradoResp.VaRRecalibrado_BIS_OA_Pisos_Redutor_Grupo[j] += vtValorCalculado[1] * (grupoClienteOperacao.CodigoGrupoCliente == param.CodigoGrupoCliente ? 1 : 0);
                    ////    }
                    ////} 
 
                    #endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< --- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                }
            }
            catch (Exception e)
            {
                lock (mutexException)
                {
                    if (exceptionThreadParalela == null)
                        exceptionThreadParalela = e;
                }
            }
            finally
            {
                if (Interlocked.Decrement(ref _numDeIteracoes) == 0)
                {
                    _sinalTermino.Set();
                }
            }
        }
 
        #endregion
    }
}


using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using ibba.raroc.Entidades;
 
namespace ibba.raroc.Negocio
{
    public class ModeloCalculoCEABase
    {
        #region [ VARIAVEIS ]
 
        public int _tamanhoVetores;
        protected decimal[] _vtVaRMarginal;
        protected decimal[] _vtEADOriginalGrupo;
        protected decimal[] _vtCEAEstoque;
        protected decimal[] _vtFatorCarecagem;
 
        protected decimal[] VtValorEAD2;
        protected decimal[] VtValorPE2;
        protected decimal[] VtValorExposicao2;
        protected decimal[] vtPrazoMedio2;
        protected decimal[] VtValorPDMedia;
        protected decimal[] vtPrazoMedio;
        protected decimal[] VtValorLgdMedia;
 
        protected Dictionary<DateTime, decimal> _curvaBRL;
 
        #endregion
 
        #region [ PROPRIEDADES ]
 
        protected SimulacaoCalculoCEAEstoqueParam Parametros { get; set; }
        protected string Idioma { get; set; }
 
        #endregion
 
        public ModeloCalculoCEABase(SimulacaoCalculoCEAEstoqueParam parametros)
        {
            Parametros = parametros;
        }
 
        protected virtual void CarregarVariaveis()
        {
            //if ((this.Parametros.ParamElastReponse.DesvioPadraoPortifolio) <= 0)
            //    throw new SystemException(TraduzMensagens.GetString("parametros_de_elasticidade_desviopadraoportifoli", this.Idioma) + " " +
            //        TraduzMensagens.GetString("detalhes", this.Idioma) + "=>Classe:" + this.GetType().Name + " Metodo: CarregarVariaveis." );
 
            _tamanhoVetores = this.Parametros.PrazoEstoque + 1;
 
            ////_Cea = new CalculoCEAUtil(param.DataReferencia);
            ////_Cea.Idioma = Idioma;
 
            ////_Cea.KTarget = (decimal)(param.ParamElastReponse.RecalibracaoCapitalNivel1);
            ////_Cea.KOA = (decimal)(param.ParamElastReponse.RecalibracaoCapitalNivel2);
            ////_Cea.KredutorPisos = (decimal)(param.ParamElastReponse.RecalibracaoCapitalNivel3);
            ////_Cea.ParametrosElasticidade = param.ParamElastReponse;
            ////_Cea.CarregarVariaveisR1A();
 
            ////_Regressao = _Cea.DeveUsarVetorWiParaSegmento(param.SegmentoCNPJ, param.DataReferencia);
            ////_RegressaoOriginal = _Cea.DeveUsarVetorWiParaSegmento(param.SegmentoCNPJOriginal, param.DataReferencia);
 
            ////_Cea.UsarRegressaoNoVetorWi = _Regressao;
 
            _vtVaRMarginal = new decimal[_tamanhoVetores];
            _vtEADOriginalGrupo = new decimal[_tamanhoVetores];
            _vtCEAEstoque = new decimal[_tamanhoVetores];
            _vtFatorCarecagem = new decimal[_tamanhoVetores];
 
            if (Parametros.PrazoEstoque > Parametros.PrazoOperacaoNova)
                Parametros.CurvaBRL = (new ExtratorCurvaBDS()).CriaVetorComFatoresDaCurva(Parametros.DataInicioOpNova, Parametros.PrazoEstoque + 1, "BRL");
 
        }
 
        protected void CalcularFatorCarecagem()
        {
            decimal fator = 1;
            for (int i = 0; i < _tamanhoVetores; i++)
            {
                if (i % 180 == 0)
                {
                    fator = Parametros.CurvaBRL[Parametros.DataInicioOpNova.AddDays(i)];
                }
                _vtFatorCarecagem[i] = Parametros.CurvaBRL[Parametros.DataInicioOpNova.AddDays(i)] / fator;
            }
        }
 
        protected void CalcularValoresMedios(List<GrupoClientesOperacoesResponse> pOperacoes, bool operacoesEstoque)
        {
            decimal valorEADProjetado;
            decimal valorExposicao;
            decimal valorPerdaEsperada;
            decimal lgd;
            decimal valorEAD;
            decimal pd;
            int prazoOperacao;
            int prazoMedioDiv;
 
            foreach (var operacao in pOperacoes.OrderByDescending(l => l.ValorOperacao))
            {
                if (operacao.QtdeDiasPrazoMedio > Parametros.PrazoOperacaoNova)
                    prazoOperacao = Parametros.PrazoOperacaoNova;
                else
                    prazoOperacao = operacao.QtdeDiasPrazoMedio;
 
                for (int j = 0; j < prazoOperacao; j++)
                {
                    if (!operacoesEstoque)
                    {
                        lgd = Parametros.ListLgdOperacaoNova[j];
                        valorEADProjetado = Parametros.EadOperacaoVetor[j];
                        pd = Parametros.PDOperacao;
                        prazoMedioDiv = Parametros.PrazoMedioOperacaoNovaVetor[j];
                    }
                    else
                    {
                        lgd = operacao.PercLgdMitigado;
                        valorEADProjetado = decimal.Multiply(operacao.ValorOperacaoRaroc, _vtFatorCarecagem[j]);
 
                        if (Parametros.PDGrupo != Parametros.PDGrupoOriginal && operacao.CodigoGrupoCliente == Parametros.CodigoGrupoCliente)
                            pd = Parametros.PDGrupo;
                        else if (Parametros.PDEstoque != Parametros.PDEstoqueOriginal && operacao.CodigoGrupoCliente != Parametros.CodigoGrupoCliente)
                            pd = Parametros.PDEstoque;
                        else
                            pd = operacao.PDOperacao == 0 ? Parametros.PDEstoque : operacao.PDOperacao;
 
                        prazoMedioDiv = operacao.QtdeDiasPrazoMedio - j;
                    }
 
                    valorExposicao = decimal.Multiply(valorEADProjetado, lgd / 100);
                    valorPerdaEsperada = decimal.Multiply(valorExposicao, pd);
 
                    VtValorEAD2[j] += valorEADProjetado;
                    VtValorPE2[j] += valorPerdaEsperada;
                    VtValorExposicao2[j] += valorExposicao;
                    vtPrazoMedio2[j] += decimal.Multiply(valorExposicao, prazoMedioDiv);
                }
            }
 
            #region [ Media Operacao Holding ]
 
            if (operacoesEstoque)
            {
                pd = 0;
                prazoOperacao = Convert.ToInt32(Parametros.PrazoOperacaoHoldingOriginal) + 1;
                valorEADProjetado = 0;
                valorExposicao = 0;
                valorPerdaEsperada = 0;
                valorEAD = Parametros.ValorRiscoLiquidoGrupo - Parametros.ValorRiscoLiquidoGrupoIbba;
 
                for (int j = 0; j < prazoOperacao; j++)
                {
                    if (Parametros.PDEstoque != Parametros.PDEstoqueOriginal)
                        pd = Parametros.PDEstoque;
                    else
                        pd = Parametros.PDItau;
 
                    valorEADProjetado = decimal.Multiply(valorEAD, _vtFatorCarecagem[j]);
                    valorExposicao = decimal.Multiply(valorEADProjetado, Parametros.LGDItau);
                    valorPerdaEsperada = decimal.Multiply(valorExposicao, pd);
 
                    VtValorEAD2[j] += valorEADProjetado;
                    VtValorExposicao2[j] += valorExposicao;
                    VtValorPE2[j] += valorPerdaEsperada;
                    vtPrazoMedio2[j] += decimal.Multiply(valorExposicao, prazoOperacao - j);
                }
            }
 
            #endregion
 
            #region [ Calculo Valores Medios ]
 
            for (int j = 0; j < _tamanhoVetores; j++)
            {
                if (VtValorExposicao2[j] != 0)
                {
                    VtValorPDMedia[j] = decimal.Divide(VtValorPE2[j], VtValorExposicao2[j]);
                    vtPrazoMedio[j] = decimal.Divide(vtPrazoMedio2[j], VtValorExposicao2[j]);
                }
 
                if (VtValorEAD2[j] != 0)
                    VtValorLgdMedia[j] = decimal.Divide(VtValorExposicao2[j], VtValorEAD2[j]);
 
            }
 
            #endregion
        }
    }
 
    public class CalcularCEARiskFrontier: ModeloCalculoCEABase, IModeloCalculoCEA
    {
        public CalcularCEARiskFrontier()
            : base(null)
        { }
 
        public CalcularCEARiskFrontier(SimulacaoCalculoCEAEstoqueParam parametros)
            : base(parametros)
        { }
 
        protected override void CarregarVariaveis()
        {
            base.CarregarVariaveis();
        }
 
        #region IModeloCalculoCEA Members
 
        public virtual void IniciarCalculo(SimulacaoCalculoCEAEstoqueParam pParametros, string pIdioma)
        {
            base.Parametros = pParametros;
            this.Idioma = pIdioma;
 
            this.CarregarVariaveis();
 
            base.CalcularFatorCarecagem();
            base.CalcularValoresMedios(Parametros.ListOperacoesEstoque, true);
        }
 
        public decimal[] VaRMarginal
        {
            get { return base._vtVaRMarginal; }
        }
 
        public decimal[] EADOriginalGrupo
        {
            get { return base._vtEADOriginalGrupo; }
        }
 
        public decimal[] CEAEstoqueGrupo
        {
            get { return base._vtCEAEstoque; }
        }
 
        public decimal[] PerdaInesperadaNivel1 { get { return new decimal[base._tamanhoVetores]; } }
        public decimal[] PerdaInesperadaNivel2 { get { return new decimal[base._tamanhoVetores]; } }
 
        #endregion
    }
 
 
    public class CEAVetores
    {
        public int Lenght { get; private set; }
 
        public decimal[] PE { get; set; }
        public decimal[] EAD { get; set; }
        public decimal[] Exposicao { get; set; }
        public decimal[] PDMedia { get; set; }
        public decimal[] LGDMedia { get; set; }
        public decimal[] PrazoMedio { get; set; }
 
        public CEAVetores(int lenght)
        {
            Lenght = lenght;
            Reset();
        }
 
        public void Reset()
        {
            PE = new decimal[Lenght];
            EAD = new decimal[Lenght];
            Exposicao = new decimal[Lenght];
            PDMedia = new decimal[Lenght];
            LGDMedia = new decimal[Lenght];
            PrazoMedio = new decimal[Lenght];
        }
 
        public void CopyTo(CEAVetores destino)
        {
            PE.CopyTo(destino.PE, 0);
            EAD.CopyTo(destino.EAD, 0);
            Exposicao.CopyTo(destino.Exposicao, 0);
            PDMedia.CopyTo(destino.PDMedia, 0);
            LGDMedia.CopyTo(destino.LGDMedia, 0);
            PrazoMedio.CopyTo(destino.PrazoMedio, 0);
        }
    }
 
    public class SimulacaoCalculoCEARiskFrontier: IModeloCalculoCEA
    {
        #region -- Propriedades / Variaveis --
 
        private SimulacaoCalculoCEAEstoqueParam param;
        private string Idioma;
 
        private CEAVetores _vetoresAux;
        private CEAVetores _vetoresEstoque;
        private CEAVetores _vetoresCarteira;
 
        private decimal[] vtVarMarginal;
        private decimal[] VtFatorCarecagem;
 
        private decimal[] VtValorPE;
        private decimal[] VtValorPE2;
        private decimal[] VtValorPEOriginal;
 
        private decimal[] VtValorEAD;
        private decimal[] VtValorEAD2;
        private decimal[] VtValorEADOriginal;
        private decimal[] VtValorEADOriginalGrupo;
 
        private decimal[] VtValorExposicao;
        private decimal[] VtValorExposicao2;
        private decimal[] VtValorExposicaoOriginal;
        
        private decimal[] VtValorPDMedia;
        private decimal[] VtValorLgdMedia;
        
        // Vetores RiskFrontier
        private decimal[] vtEadEstoque;
        private decimal[] vtEadCarteira;
        private decimal[] vtPdMediaEstoque;
        private decimal[] vtPdMediaCarteira;
        private decimal[] vtLgdMediaEstoque;
        private decimal[] vtLgdMediaCarteira;
        private decimal[] vtPrazoMedioEstoque;
        private decimal[] vtPrazoMedioCarteira;
        private decimal[] vtPrazoMedio;
        private decimal[] vtPrazoMedio2;
        private decimal[] vtCEAEstoque;
        private decimal[] vtCEACarteira;
 
        private readonly object mutexVtValorEAD = new object();
        private readonly object mutexVtValorExposicao = new object();
        private readonly object mutexVtValorPE = new object();
        private readonly object mutexVtValorEADOriginal = new object();
        private readonly object mutexVtValorEADOriginalGrupo = new object();
        private readonly object mutexVtValorExposicaoOriginal = new object();
        private readonly object mutexVtValorPEOriginal = new object();
        private readonly object mutexException = new object();
 
        private Exception exceptionThreadParalela = null;
        private AutoResetEvent _sinalTermino;
 
        private Dictionary<DateTime, decimal> _curvaBRL;
        private long _numDeIteracoes = 0;
        private int _length = 0;
 
        private const string TIPO_CLIENTE = "J";
        private const int COD_SUBCANAL = 4;
 
        private enum CopiarVetores
        {
            Estoque,
            Carteira
        }
 
        #endregion
 
        private void FatorCarecagem()
        {
            decimal fator = 1;
            for (int i = 0; i < _length; i++)
            {
                if (i % 180 == 0)
                {
                    fator = _curvaBRL[param.DataInicioOpNova.AddDays(i)];
                }
                VtFatorCarecagem[i] = _curvaBRL[param.DataInicioOpNova.AddDays(i)] / fator;
            }
        }
 
        #region -- IniciarCalculo --
 
        private int stepDebug;
        private void ExportarMemoriaVetores()
        {
            //return;
            string sheetDebug = "DEBUG Step " + stepDebug.ToString();
            stepDebug++;
 
#if DEBUG
            //vtVarMarginal.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "vtVarMarginal");
            //VtFatorCarecagem.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "VtFatorCarecagem");
 
            VtValorPE.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "VtValorPE");
            VtValorPE2.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "VtValorPE2");
            _vetoresAux.PE.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "_vetoresAux.PE");
            _vetoresEstoque.PE.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "_vetoresEstoque.PE");
            VtValorPEOriginal.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "VtValorPEOriginal");           
            VtValorEAD.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "VtValorEAD");
            VtValorEAD2.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "VtValorEAD2");
            VtValorEADOriginal.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "VtValorEADOriginal");
            VtValorEADOriginalGrupo.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "VtValorEADOriginalGrupo");
            vtEadEstoque.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "vtEadEstoque");
            vtEadCarteira.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "vtEadCarteira");
 
            VtValorExposicao.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "VtValorExposicao");
            VtValorExposicao2.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "VtValorExposicao2");
            _vetoresAux.Exposicao.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "_vetoresAux.Exposicao");
            VtValorExposicaoOriginal.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "VtValorExposicaoOriginal");
            _vetoresEstoque.Exposicao.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "_vetoresEstoque.Exposicao");
 
            VtValorPDMedia.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "VtValorPDMedia");
            _vetoresAux.PDMedia.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "_vetoresAux.PDMedia");
            _vetoresEstoque.PDMedia.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "_vetoresEstoque.PDMedia");
            vtPdMediaEstoque.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "vtPdMediaEstoque");
            vtPdMediaCarteira.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "vtPdMediaCarteira");
 
            _vetoresAux.LGDMedia.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "_vetoresAux.LGDMedia");
            VtValorLgdMedia.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "VtValorLgdMedia");
            vtLgdMediaEstoque.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "vtLgdMediaEstoque");
            _vetoresEstoque.LGDMedia.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "_vetoresEstoque.LGDMedia");
            vtLgdMediaCarteira.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "vtLgdMediaCarteira");
 
            // Vetores RiskFrontier
            _vetoresAux.PrazoMedio.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "_vetoresAux.PrazoMedio");            
            vtPrazoMedio.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "vtPrazoMedio");
            vtPrazoMedio2.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "vtPrazoMedio2");
            _vetoresEstoque.PrazoMedio.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "_vetoresEstoque.PrazoMedio");
            vtPrazoMedioEstoque.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "vtPrazoMedioEstoque");
            vtPrazoMedioCarteira.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "vtPrazoMedioCarteira");
 
            vtCEAEstoque.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "vtCEAEstoque");
            vtCEACarteira.AdicionarMemoriaCalculo(param.HashCodeMemoriaCalculo, sheetDebug, "vtCEACarteira");
#endif
        }
 
        public void IniciarCalculo(SimulacaoCalculoCEAEstoqueParam pParametros, string pIdioma)
        {
            this.param = pParametros;
            this.Idioma = pIdioma;
            stepDebug = 0;
 
            CarregarVariaveis();
            FatorCarecagem();
 
            #region [ calcular estoque ]
            
            CalcularValoresMedios(param.ListOperacoesEstoque, true);
            _vetoresAux.CopyTo(_vetoresEstoque);
            
            // Step 1 
            CalcularContribuicaoRiscoOperacao(true, false, false, param.ListOperacoesEstoque, true);            
            ExportarMemoriaVetores();   //0
 
            // Step 2 
            if (param.CalculaHolding)
                CalcularContribuicaoRiscoHolding(true, false, true);
 
            ExportarMemoriaVetores();   //1
 
            // Step 3, 4 e 5
            ////VtValorKGrupoAntes = CalcularKGrupo(VtValorKGrupoAntes);
 
            ////ZerarVetores();
 
            ////_primeiroCalculoCea = true;
 
            ////CalcularContribuicaoRiscoOperacao(false, true, false, param.ListOperacoesEstoque, true, null);//// VtValorKGrupoAntes);
 
            ////if (param.CalculaHolding)
            ////    CalcularContribuicaoRiscoHolding(false, true, true, null);////VtValorKGrupoAntes);
 
            //Calcular CEA com modelo RiskFroontier
            //vtCEAEstoque = CalcularCEA();
 
            vtCEAEstoque = CalcularCEA(_length, VtValorEAD, VtValorPDMedia, vtPrazoMedio, VtValorLgdMedia,
                                        param.PesoCarteira, param.CodigoCabecaVisaoGrupo, param.R2, param.SegmentoModelo);
 
            ExportarMemoriaVetores();   //2
 
            CopiarVetoresCalculados(CopiarVetores.Estoque);
            ExportarMemoriaVetores();   //3
 
            #endregion
 
            ////VarRecalibradoResp.VaRRecalibrado_BIS_OA.CopyTo(VarRecalibradoRespEstoque.VaRRecalibrado_BIS_OA, 0);
            ////VarRecalibradoResp.VaRRecalibrado_BIS_OA_Pisos_Redutor_Grupo.CopyTo(VarRecalibradoRespEstoque.VaRRecalibrado_BIS_OA_Pisos_Redutor_Grupo, 0);
            ////VarRecalibradoResp.VaRRecalibrado_BIS_OA_Pisos_Redutor.CopyTo(VarRecalibradoRespEstoque.VaRRecalibrado_BIS_OA_Pisos_Redutor_Grupo, 0);
 
            ////CopiarVetoresCalculados();
 
            // Zera Vetores
            ////////////ZerarVetores();
 
            // Recuperar valores dos vetores
            ////RecuperarVetores();
 
            #region [ calcular nova operacao ]
 
            CalcularValoresMedios(param.ListOperacoesNovas, false);
 
            // Step 8
            ////CalcularContribuicaoRiscoOperacao(false, false, true, param.ListOperacoesNovas, true);
 
 
            // Step 9, 10 e 11
            ////VtValorKGrupoDepois = new decimal[_lenght];
            ////VtValorKGrupoDepois = CalcularKGrupo(VtValorKGrupoDepois);
 
            // Zera Vetores
            ////ZerarVetores();
 
            // Step 12
            ////_primeiroCalculoCea = false;
 
            //////////CalcularContribuicaoRiscoOperacao(false, true, false, param.ListOperacoesEstoque, true, null);////VtValorKGrupoDepois);
 
            //////////// TODO: IGNORAR QUANDO FOR GRUPO NOVO
            //////////if (param.CalculaHolding)
            //////////    CalcularContribuicaoRiscoHolding(false, true, true, null);////VtValorKGrupoDepois);
 
            // Step 14
            ////_primeiroCalculoCea = null;
 
            CalcularContribuicaoRiscoOperacao(false, true, true, param.ListOperacoesNovas, true, null);////VtValorKGrupoDepois);
            ExportarMemoriaVetores();   //4
 
            // Calcular CEA com modelo RiskFroontier
            vtCEACarteira = CalcularCEA(_length, VtValorEAD, VtValorPDMedia, vtPrazoMedio, VtValorLgdMedia,
                                        param.PesoCarteira, param.CodigoCabecaVisaoGrupo, param.R2, param.SegmentoModelo);
 
            ExportarMemoriaVetores();   //5
 
            CopiarVetoresCalculados(CopiarVetores.Carteira);
            ExportarMemoriaVetores();   //6
 
            #endregion
 
 
            CalcularResultadoFinal(param.PerdaEsperadaLiquida, param.EadOperacaoVetor, param.PercentualPisoCEA);
            ExportarMemoriaVetores();   //7
 
            AdicionarMemoriaCalculo();
        }
 
        /// <summary>
        /// Iniciar o calculo para grupo sem estoque
        /// </summary>        
        public void IniciarCalculo(ParametroModeloCEASemEstoque pParametros)
        {
            _length = pParametros.PrazoDCOperacao;
 
            #region [ CarregarVetores ]
 
            this.vtVarMarginal = new decimal[_length];          // CEA
            this.vtLgdMediaCarteira = new decimal[_length];
            this.vtPrazoMedio = new decimal[_length];
            this.vtPdMediaCarteira = new decimal[_length];
 
            this.vtCEAEstoque = new decimal[_length];
            this.vtCEACarteira = new decimal[_length];
            this.PerdaInesperadaNivel1 = new decimal[_length];
            this.PerdaInesperadaNivel2 = new decimal[_length];
 
            for (int i = 0; i < _length; i++)
            {
                vtLgdMediaCarteira[i] = decimal.Divide(pParametros.LGDNovaOperacao[i], 100);
                vtPdMediaCarteira[i] = pParametros.PDNovaOperacao;
                vtPrazoMedio[i] = pParametros.PrazoMedioNovaOperacao[i];
            }
 
            #endregion
 
            this.vtVarMarginal = CalcularCEA(pParametros.PrazoDCOperacao, pParametros.EADNovaOperacao, vtPdMediaCarteira,
                                             vtPrazoMedio, vtLgdMediaCarteira, pParametros.PesoCarteira,
                                             pParametros.CodigoCabecaVisaoGrupo, pParametros.RQuadrado, pParametros.SegmentoModelo);
 
            vtVarMarginal.CopyTo(vtCEACarteira, 0);
            CalcularResultadoFinal(pParametros.PELiquidaNovaOperacao, pParametros.EADNovaOperacao, pParametros.PercentualPisoCEA);
 
            #region Adicionar memória de calculo
 
            pParametros.SegmentoModelo.AdicionarMemoriaCalculo(pParametros.HashCodeParent, "Parametro", "Codigo Segmento Modelo");
            COD_SUBCANAL.AdicionarMemoriaCalculo(pParametros.HashCodeParent, "Parametro", "Codigo Subcanal");
            TIPO_CLIENTE.AdicionarMemoriaCalculo(pParametros.HashCodeParent, "Parametro", "Tipo de Cliente");
            pParametros.CodigoCabecaVisaoGrupo.AdicionarMemoriaCalculo(pParametros.HashCodeParent, "Parametro", "CNPJ Raiz Cliente");
            pParametros.PesoCarteira.AdicionarMemoriaCalculo(pParametros.HashCodeParent, "Parametro", "Peso da Carteira");
            pParametros.RQuadrado.AdicionarMemoriaCalculo(pParametros.HashCodeParent, "Parametro", "Valor R2");
 
            pParametros.EADNovaOperacao.AdicionarMemoriaCalculo(pParametros.HashCodeParent, "Vetores", "EAD Carteira");
            vtPdMediaCarteira.AdicionarMemoriaCalculo(pParametros.HashCodeParent, "Vetores", "PD Média Carteira");
            vtLgdMediaCarteira.AdicionarMemoriaCalculo(pParametros.HashCodeParent, "Vetores", "LGD Média Carteira");
            vtPrazoMedio.AdicionarMemoriaCalculo(pParametros.HashCodeParent, "Vetores", "Prazo Médio Carteira");
            vtCEACarteira.AdicionarMemoriaCalculo(pParametros.HashCodeParent, "Vetores", "CEA Carteira");
            PerdaInesperadaNivel1.AdicionarMemoriaCalculo(pParametros.HashCodeParent, "Vetores", "Perda Inesperada Nível 1");
            PerdaInesperadaNivel2.AdicionarMemoriaCalculo(pParametros.HashCodeParent, "Vetores", "Perda Inesperada Nível 2");
 
            #endregion
        }
 
        public decimal[] VaRMarginal
        {
            ////get { return this.VarRecalibradoResp.VaRRecalibrado_BIS_OA_Pisos_Redutor; }
            get { return this.vtVarMarginal; }
        }
 
        public decimal[] EADOriginalGrupo
        {
            get { return this.VtValorEADOriginalGrupo; }
        }
 
        public decimal[] CEAEstoqueGrupo
        {
            ////get { return this.VarRecalibradoRespEstoque.VaRRecalibrado_BIS_OA_Pisos_Redutor; }
            get { return this.vtCEAEstoque; }
        }
 
        public decimal[] PerdaInesperadaNivel1 { get; private set; }
        public decimal[] PerdaInesperadaNivel2 { get; private set; }
 
        private void AdicionarMemoriaCalculo()
        {
            int hashCode = this.param.HashCodeMemoriaCalculo;
 
            this.param.SegmentoModelo.AdicionarMemoriaCalculo(hashCode, "Parametro", "Codigo Segmento Modelo");
            COD_SUBCANAL.AdicionarMemoriaCalculo(hashCode, "Parametro", "Codigo Subcanal");
            TIPO_CLIENTE.AdicionarMemoriaCalculo(hashCode, "Parametro", "Tipo de Cliente");
            this.param.CodigoCabecaVisaoGrupo.AdicionarMemoriaCalculo(hashCode, "Parametro", "CNPJ Raiz Cliente");
            this.param.PesoCarteira.AdicionarMemoriaCalculo(hashCode, "Parametro", "Peso da Carteira");
            this.param.R2.AdicionarMemoriaCalculo(hashCode, "Parametro", "Valor R2");
 
            this.VtValorExposicao.AdicionarMemoriaCalculo(hashCode, "Vetores", "VtValorExposicao");
            this.VtValorPE.AdicionarMemoriaCalculo(hashCode, "Vetores", "VtValorPE");
            this.VtValorEADOriginal.AdicionarMemoriaCalculo(hashCode, "Vetores", "VtValorEADOriginal");
            this.VtValorEADOriginalGrupo.AdicionarMemoriaCalculo(hashCode, "Vetores", "VtValorEADOriginalGrupo");
            this.VtValorExposicaoOriginal.AdicionarMemoriaCalculo(hashCode, "Vetores", "VtValorExposicaoOriginal");
            this.VtValorPEOriginal.AdicionarMemoriaCalculo(hashCode, "Vetores", "VtValorPEOriginal");
            this.VtValorExposicao2.AdicionarMemoriaCalculo(hashCode, "Vetores", "VtValorExposicaoMedia");
            this.VtFatorCarecagem.AdicionarMemoriaCalculo(hashCode, "Vetores", "VtFatorCarecagem");
            this.param.EadOperacaoVetor.AdicionarMemoriaCalculo(hashCode, "Vetores", "EAD Capital");
            this.vtEadEstoque.AdicionarMemoriaCalculo(hashCode, "Vetores", "EAD Estoque");
            this.vtLgdMediaEstoque.AdicionarMemoriaCalculo(hashCode, "Vetores", "LGD Média Estoque");
            this.vtPdMediaEstoque.AdicionarMemoriaCalculo(hashCode, "Vetores", "PD Média Estoque");
            this.vtPrazoMedioEstoque.AdicionarMemoriaCalculo(hashCode, "Vetores", "Prazo Médio Estoque");
            this.vtCEAEstoque.AdicionarMemoriaCalculo(hashCode, "Vetores", "CEA Estoque");
            this.vtEadCarteira.AdicionarMemoriaCalculo(hashCode, "Vetores", "EAD Carteira");
            this.vtLgdMediaCarteira.AdicionarMemoriaCalculo(hashCode, "Vetores", "LGD Média Carteira");
            this.vtPdMediaCarteira.AdicionarMemoriaCalculo(hashCode, "Vetores", "PD Média Carteira");
            this.vtPrazoMedioCarteira.AdicionarMemoriaCalculo(hashCode, "Vetores", "Prazo Médio Carteira");
            this.vtCEACarteira.AdicionarMemoriaCalculo(hashCode, "Vetores", "CEA Carteira");
            this.vtVarMarginal.AdicionarMemoriaCalculo(hashCode, "Vetores", "VaRMarginal Analitico");
 
            this.PerdaInesperadaNivel1.AdicionarMemoriaCalculo(hashCode, "Vetores", "Perda Inesperada Nível 1");
            this.PerdaInesperadaNivel2.AdicionarMemoriaCalculo(hashCode, "Vetores", "Perda Inesperada Nível 2");
 
            this.param.ListOperacoesEstoque.AdicionarMemoriaCalculo(hashCode, "Operações Grupo");
        }
 
        #endregion
 
        #region -- CalcularContribuicaoRiscoOperacao --
 
        private void CalcularContribuicaoRiscoOperacao(bool parametrosOriginais, bool calcularCea, bool calculaOperNova, List<GrupoClientesOperacoesResponse> listaDeOperacoes, bool calcularVar1A, decimal[] vKgrupo = null)
        {
            _numDeIteracoes = listaDeOperacoes.Count;
            _sinalTermino = new AutoResetEvent(false);
            exceptionThreadParalela = null;
 
            int countLista_ = listaDeOperacoes.Count;
 
            foreach (var operacao in listaDeOperacoes.OrderByDescending(l => l.ValorOperacao))
            {
                List<Object> listParametros = new List<object>();
 
                listParametros.Add(calcularCea);        //0
                listParametros.Add(calculaOperNova);    //1
                listParametros.Add(operacao);           //2
                listParametros.Add(calcularVar1A);      //3
 
                listParametros.Add(operacao.PDOperacao == 0 ? param.PDEstoque : operacao.PDOperacao);        //4
 
                int prazoOperacao = 0;
 
                if (operacao.QtdeDiasPrazoMedio > param.PrazoOperacaoNova)
                    prazoOperacao = param.PrazoOperacaoNova;
                else
                    prazoOperacao = operacao.QtdeDiasPrazoMedio;
 
                listParametros.Add(prazoOperacao);          //5
                listParametros.Add(vKgrupo);                //6
                listParametros.Add(parametrosOriginais);    //7
 
                ThreadPool.QueueUserWorkItem(new WaitCallback(CalcularEmParalelo), listParametros);
            }
 
            if (countLista_ > 0)
            {
                _sinalTermino.WaitOne();
            }
 
            if (exceptionThreadParalela != null)
                throw new Exception(exceptionThreadParalela.Message);
        }
 
        #endregion
 
        #region -- CalcularEmParalelo --
 
        private void CalcularEmParalelo(object parametros)
        {
            try
            {
                ////CalculoCEAUtil _Cea = new CalculoCEAUtil(this._Cea.FormulaParte1, this._Cea.FormulaParte2, this._Cea.InterceptoRegressaoWI, 
                ////                                         this._Cea.CoeficienteRegressaoWI, _Regressao, _RegressaoOriginal, 
                ////                                         this._Cea.Fator_PE_Liquida, this._Cea.KOA, this._Cea.KredutorPisos, this._Cea.KTarget);
                ////_Cea.Idioma = Idioma;
 
                decimal valorEADProjetado = 0;
                decimal valorExposicao = 0;
                decimal valorPerdaEsperada = 0;
                decimal valorExposicaoOriginal = 0;
                decimal valorPerdaEsperadaOriginal = 0;
                ////decimal valorCR = 0;
                ////decimal valorCROriginal = 0;
                decimal Lgd = 0;
 
                int prazoOpBD = 0;
                int prazoMedio = 0;
 
                List<Object> listaDeParametros = (List<object>)parametros;
 
                bool calcularCea = (bool)listaDeParametros[0];
                bool calculaOperNova = (bool)listaDeParametros[1];
                GrupoClientesOperacoesResponse grupoClienteOperacao = (GrupoClientesOperacoesResponse)listaDeParametros[2];
                bool calcularVar1A = (bool)listaDeParametros[3];
                decimal PdOperacaoEstoque = (decimal)listaDeParametros[4];
                int prazoDC = (int)listaDeParametros[5];
                ////decimal[] vKgrupo = listaDeParametros[6] != null ? (decimal[])listaDeParametros[6] : null;
                bool parametrosOriginais = (bool)listaDeParametros[7];
                ////decimal WI = 0;
                decimal pd = 0;
                Lgd = grupoClienteOperacao.PercLgdMitigado;
 
                prazoOpBD = grupoClienteOperacao.QtdeDiasPrazoMedio;
 
                for (int j = 0; j < prazoDC; j++)
                {
                    #region [ calculaOperNova ]
 
                    if (calculaOperNova)
                    {
                        Lgd = param.ListLgdOperacaoNova[j];
                        PdOperacaoEstoque = param.PDOperacao;
                        prazoMedio = param.PrazoMedioOperacaoNovaVetor[j];
                        pd = param.PDOperacao;
                        valorEADProjetado = this.param.EadOperacaoVetor[j];
                    }
                    else
                    {
                        prazoMedio = grupoClienteOperacao.QtdeDiasPrazoMedio - j;
                        valorEADProjetado = Decimal.Multiply(grupoClienteOperacao.ValorOperacaoRaroc, VtFatorCarecagem[j]);
 
                        if (param.PDGrupo != param.PDGrupoOriginal && grupoClienteOperacao.CodigoGrupoCliente == param.CodigoGrupoCliente)
                        {
                            pd = param.PDGrupo;
                        }
                        else
                        {
                            if (param.PDEstoque != param.PDEstoqueOriginal && grupoClienteOperacao.CodigoGrupoCliente != param.CodigoGrupoCliente)
                                pd = param.PDEstoque;
                            else
                                pd = PdOperacaoEstoque;
                        }
                    }
 
                    #endregion
 
                    #region [ calcularVar1A ]
 
                    if (calcularVar1A)
                    {
                        valorExposicao = Decimal.Multiply(valorEADProjetado, Lgd / 100);
                        valorPerdaEsperada = Decimal.Multiply(valorExposicao, pd);
                        ////valorCR = _Cea.VaR1A(VtValorWI[j], valorPerdaEsperada, valorExposicao, false);
 
                        SomaVtValorEAD(j, valorEADProjetado);
                        SomaVtValorExposicao(j, valorExposicao);
                        SomaVtValorPE(j, valorPerdaEsperada);
                        ////SomaContribuicaoSemConcentracao(j, valorCR);
 
                        if (parametrosOriginais)
                        {
                            valorExposicaoOriginal = Decimal.Multiply(valorEADProjetado, Lgd / 100);
                            valorPerdaEsperadaOriginal = Decimal.Multiply(valorExposicao, PdOperacaoEstoque);
 
                            ////WI = _Cea.CalcularWI(param.PDHolding, true);
 
                            ////valorCROriginal = _Cea.VaR1A(WI, valorPerdaEsperadaOriginal, valorExposicaoOriginal, true);
                            SomaVtValorEADOriginal(j, valorEADProjetado);
                            SomaVtValorEADOriginalGrupo(j, valorEADProjetado * (grupoClienteOperacao.CodigoGrupoCliente == param.CodigoGrupoCliente ? 1 : 0));
                            SomaVtValorExposicaoOriginal(j, valorExposicaoOriginal);
                            SomaVtValorPEOriginal(j, valorPerdaEsperadaOriginal);
                            ////SomaContribuicaoSemConcentracaoOriginal(j, valorCROriginal);
                        }
                    }
 
                    #endregion
 
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< --- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    #region [ calcularCea ]
 
                    // Tem que acumular
                    ////if (calcularCea)
                    ////{
                    ////    decimal[] vtValorCalculado;
 
                    ////    if (calculaOperNova)
                    ////        vtValorCalculado = _Cea.VaRRecalibradoOperacao(param.DataReferencia, pd, valorEADProjetado, Lgd, valorCR, vKgrupo[j], grupoClienteOperacao.QtdeDiasPrazoMedio, prazoMedio, param.QtdeDiasPrazoIndeterminado, ref VarRecalibradoResp, j);
                    ////    else
                    ////        vtValorCalculado = _Cea.VaRRecalibradoOperacao(param.DataReferencia, pd, valorEADProjetado, Lgd, valorCR, vKgrupo[j], grupoClienteOperacao.QtdeDiasPrazoMedio, prazoMedio, 0, ref VarRecalibradoResp, j);
 
                    ////    lock (mutexRecalibrado)
                    ////    {
                    ////        VarRecalibradoResp.VaRRecalibrado_BIS_OA[j] += vtValorCalculado[0];
                    ////        VarRecalibradoResp.VaRRecalibrado_BIS_OA_Pisos_Redutor[j] += vtValorCalculado[1];
 
                    ////        if (j == 0)
                    ////        {
                    ////            if (_primeiroCalculoCea.GetValueOrDefault())
                    ////            {
                    ////                grupoClienteOperacao.VaRRecalibrado_BIS_OA_Pisos_Redutor_Antes = vtValorCalculado[1];
                    ////                grupoClienteOperacao.ContribuicaoSemConcentracaoAntes = VtContribuicaoRiscoSemConcentracao[0];
                    ////            }
                    ////            else if (_primeiroCalculoCea.HasValue)
                    ////            {
                    ////                grupoClienteOperacao.VaRRecalibrado_BIS_OA_Pisos_Redutor_Depois = vtValorCalculado[1];
                    ////                grupoClienteOperacao.ContribuicaoSemConcentracaoDepois = VtContribuicaoRiscoSemConcentracao[0];
                    ////            }
                    ////        }
 
                    ////        VarRecalibradoResp.VaRRecalibrado_BIS_OA_Pisos_Redutor_Grupo[j] += vtValorCalculado[1] * (grupoClienteOperacao.CodigoGrupoCliente == param.CodigoGrupoCliente ? 1 : 0);
                    ////    }
                    ////} 
 
                    #endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< --- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                }
            }
            catch (Exception e)
            {
                lock (mutexException)
                {
                    if (exceptionThreadParalela == null)
                        exceptionThreadParalela = e;
                }
            }
            finally
            {
                if (Interlocked.Decrement(ref _numDeIteracoes) == 0)
                {
                    _sinalTermino.Set();
                }
            }
        }
 
        #endregion
 
        #region -- CalcularContribuicaoRiscoHolding --
 
        private void CalcularContribuicaoRiscoHolding(bool parametrosOriginais, bool calcularCea, bool calcularVar1A, decimal[] vKgrupo = null, bool calcularNova = false)//InfoGrupo.PrazoMedioEstoque 
        {
            ////CalculoCEAUtil _Cea = new CalculoCEAUtil(this._Cea.FormulaParte1, this._Cea.FormulaParte2, this._Cea.InterceptoRegressaoWI, this._Cea.CoeficienteRegressaoWI, _Regressao, _RegressaoOriginal, this._Cea.Fator_PE_Liquida, this._Cea.KOA, this._Cea.KredutorPisos, this._Cea.KTarget);
            ////_Cea.Idioma = Idioma;
 
            decimal valorEAD;
            decimal valorEADProjetado = 0;
            decimal valorExposicao;
            decimal valorPerdaEsperada;
 
            valorEAD = param.ValorRiscoLiquidoGrupo - param.ValorRiscoLiquidoGrupoIbba;
 
            int prazoDC = Convert.ToInt32(param.PrazoOperacaoHoldingOriginal) + 1;
            decimal pd = 0;
            ////decimal WI = 0;
 
            for (int j = 0; j < prazoDC; j++)
            {
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< --- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // *************** Step 2 - Inicio
                if (param.PDEstoque != param.PDEstoqueOriginal)
                    pd = param.PDEstoque;
                else
                    pd = param.PDItau;
 
                if (calcularVar1A)
                {
                    valorEADProjetado = decimal.Multiply(valorEAD, VtFatorCarecagem[j]);
                    valorExposicao = decimal.Multiply(valorEADProjetado, param.LGDItau);
                    valorPerdaEsperada = decimal.Multiply(valorExposicao, pd);
 
                    if (parametrosOriginais)
                    {
                        VtValorEADOriginal[j] += valorEADProjetado;
                        VtValorExposicaoOriginal[j] += decimal.Multiply(valorEADProjetado, param.LGDItauOriginal);
                        VtValorPEOriginal[j] += decimal.Multiply(valorExposicao, param.PDItauOriginal);
                    }
 
                    VtValorEAD[j] += valorEADProjetado;
                    VtValorExposicao[j] += valorExposicao;
                    VtValorPE[j] += valorPerdaEsperada;
 
                    ////if (j == 0)
                    ////{
                    ////    WI = _Cea.CalcularWI(param.PDHolding, true);
 
                    ////    VtContribuicaoRiscoComConcentracao[j] = _Cea.VaR1A(WI, (valorExposicao * param.PDItauOriginal), VtValorExposicao[j], false);
 
                    ////    if (parametrosOriginais)
                    ////        crEstoque = decimal.Subtract((_Cea.VaR1A(WI, VtValorPEOriginal[j], VtValorExposicaoOriginal[j], true)), VtValorPEOriginal[j]) / param.KgrupoEstoque + decimal.Subtract(VtValorPEOriginal[j], VtContribuicaoRiscoSemConcentracaoOriginal[j]);
                    ////}
 
                    ////// *************** Step 2 - Fim
                    ////VtContribuicaoRiscoSemConcentracao[j] += crEstoque;
                }
 
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< --- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // *************** Step 7 - Inicio
                ////if (calcularCea)
                ////{
                ////    decimal[] vtValorCalculado = _Cea.VaRRecalibradoOperacao(param.DataReferencia, pd, valorEADProjetado, param.LGDItau * 100, crEstoque, vKgrupo[j], (int)Math.Ceiling(param.PrazoOperacaoHolding), (int)Math.Ceiling(param.PrazoOperacaoHolding - j), 0, ref VarRecalibradoResp, j);
                ////    VarRecalibradoResp.VaRRecalibrado_BIS_OA[j] += vtValorCalculado[0];
                ////    VarRecalibradoResp.VaRRecalibrado_BIS_OA_Pisos_Redutor[j] += vtValorCalculado[1];
                ////}
 
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< --- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            }
        }
 
        #endregion
 
        #region -- Copiar/Recuperar de Vetores --
 
        private void CopiarVetoresCalculados(CopiarVetores eCopiar)
        {
            switch (eCopiar)
            {
                case CopiarVetores.Estoque:
                    VtValorEAD.CopyTo(vtEadEstoque, 0);
                    VtValorPDMedia.CopyTo(vtPdMediaEstoque, 0);
                    VtValorLgdMedia.CopyTo(vtLgdMediaEstoque, 0);
                    vtPrazoMedio.CopyTo(vtPrazoMedioEstoque, 0);
                    break;
 
                case CopiarVetores.Carteira:
                    VtValorEAD.CopyTo(vtEadCarteira, 0);
                    VtValorPDMedia.CopyTo(vtPdMediaCarteira, 0);
                    VtValorLgdMedia.CopyTo(vtLgdMediaCarteira, 0);
                    vtPrazoMedio.CopyTo(vtPrazoMedioCarteira, 0);
                    break;
                default:
                    break;
            }
        }
 
        //////private void CopiarVetoresCalculados()
        //////{
        //////    VtValorEAD.CopyTo(VtValorEADCopia, 0);
        //////    VtValorExposicao.CopyTo(VtValorExposicaoCopia, 0);
        //////    VtValorPE.CopyTo(VtValorPECopia, 0);
        //////    ////VtContribuicaoRiscoSemConcentracao.CopyTo(VtContribuicaoRiscoSemConcentracaoCopia, 0);
        //////    ////VtContribuicaoRiscoComConcentracao.CopyTo(VtContribuicaoRiscoComConcentracaoCopia, 0);
        //////}
 
        //////private void RecuperarVetores()
        //////{
        //////    VtValorEADCopia.CopyTo(VtValorEAD, 0);
        //////    VtValorExposicaoCopia.CopyTo(VtValorExposicao, 0);
        //////    VtValorPECopia.CopyTo(VtValorPE, 0);
        //////    ////VtContribuicaoRiscoSemConcentracaoCopia.CopyTo(VtContribuicaoRiscoSemConcentracao, 0);
        //////    ////VtContribuicaoRiscoComConcentracaoCopia.CopyTo(VtContribuicaoRiscoComConcentracao, 0);
        //////}
 
        #endregion
 
        #region -- Somadores --
 
        private void CalcularValoresMedios(List<GrupoClientesOperacoesResponse> pOperacoes, bool operacoesEstoque)
        {
            ////CalculoCEAUtil _Cea = new CalculoCEAUtil(this._Cea.FormulaParte1, this._Cea.FormulaParte2, this._Cea.InterceptoRegressaoWI, this._Cea.CoeficienteRegressaoWI, _Regressao, _RegressaoOriginal, this._Cea.Fator_PE_Liquida, this._Cea.KOA, this._Cea.KredutorPisos, this._Cea.KTarget);
            ////_Cea.Idioma = Idioma;
 
            decimal valorEADProjetado;
            decimal valorExposicao;
            decimal valorPerdaEsperada;
            decimal lgd;
            decimal valorEAD;
            decimal pd;
            int prazoOperacao;
            int prazoMedioDiv;
 
            foreach (var operacao in pOperacoes.OrderByDescending(l => l.ValorOperacao))
            {
                if (operacao.QtdeDiasPrazoMedio > param.PrazoOperacaoNova)
                    prazoOperacao = param.PrazoOperacaoNova;
                else
                    prazoOperacao = operacao.QtdeDiasPrazoMedio;
 
                for (int i = 0; i < prazoOperacao; i++)
                {
                    if (!operacoesEstoque)
                    {
                        lgd = param.ListLgdOperacaoNova[i];
                        valorEADProjetado = param.EadOperacaoVetor[i];
                        pd = param.PDOperacao;
                        prazoMedioDiv = param.PrazoMedioOperacaoNovaVetor[i];
                    }
                    else
                    {
                        lgd = operacao.PercLgdMitigado;
                        valorEADProjetado = Decimal.Multiply(operacao.ValorOperacaoRaroc, VtFatorCarecagem[i]);
 
                        if (param.PDGrupo != param.PDGrupoOriginal && operacao.CodigoGrupoCliente == param.CodigoGrupoCliente)
                            pd = param.PDGrupo;
                        else if (param.PDEstoque != param.PDEstoqueOriginal && operacao.CodigoGrupoCliente != param.CodigoGrupoCliente)
                            pd = param.PDEstoque;
                        else
                            pd = operacao.PDOperacao == 0 ? param.PDEstoque : operacao.PDOperacao;
 
                        prazoMedioDiv = operacao.QtdeDiasPrazoMedio - i;
                    }
 
                    valorExposicao = Decimal.Multiply(valorEADProjetado, lgd / 100);
                    valorPerdaEsperada = decimal.Multiply(valorExposicao, pd);
 
                    VtValorEAD2[i] += valorEADProjetado;
                    VtValorPE2[i] += valorPerdaEsperada;
                    VtValorExposicao2[i] += valorExposicao;
                    vtPrazoMedio2[i] += decimal.Multiply(valorExposicao, prazoMedioDiv);
 
                    _vetoresAux.EAD[i] += valorEADProjetado;
                    _vetoresAux.PE[i] += valorPerdaEsperada;
                    _vetoresAux.Exposicao[i] += valorExposicao;
                }
            }
 
            #region [ Media Operacao Holding ]
 
            if (operacoesEstoque)
            {
                pd = 0;
                prazoOperacao = Convert.ToInt32(param.PrazoOperacaoHoldingOriginal) + 1;
                valorEADProjetado = 0;
                valorExposicao = 0;
                valorPerdaEsperada = 0;
                valorEAD = param.ValorRiscoLiquidoGrupo - param.ValorRiscoLiquidoGrupoIbba;
 
                for (int i = 0; i < prazoOperacao; i++)
                {
                    if (param.PDEstoque != param.PDEstoqueOriginal)
                        pd = param.PDEstoque;
                    else
                        pd = param.PDItau;
 
                    valorEADProjetado = decimal.Multiply(valorEAD, VtFatorCarecagem[i]);
                    valorExposicao = decimal.Multiply(valorEADProjetado, param.LGDItau);
                    valorPerdaEsperada = decimal.Multiply(valorExposicao, pd);
 
                    VtValorEAD2[i] += valorEADProjetado;
                    VtValorExposicao2[i] += valorExposicao;
                    VtValorPE2[i] += valorPerdaEsperada;
                    vtPrazoMedio2[i] += decimal.Multiply(valorExposicao, prazoOperacao - i);
 
                    _vetoresAux.EAD[i] += valorEADProjetado;
                    _vetoresAux.PE[i] += valorPerdaEsperada;
                    _vetoresAux.Exposicao[i] += valorExposicao;
                }
            }
 
            #endregion
 
            for (int i = 0; i < _length; i++)
            {
                if (_vetoresAux.Exposicao[i] != 0)
                {
                    _vetoresAux.PDMedia[i] = decimal.Divide(_vetoresAux.PE[i], _vetoresAux.Exposicao[i]);
                    _vetoresAux.PrazoMedio[i] = decimal.Divide(vtPrazoMedio2[i], _vetoresAux.Exposicao[i]);
                }
                if (_vetoresAux.EAD[i] != 0)
                    _vetoresAux.LGDMedia[i] = decimal.Divide(_vetoresAux.Exposicao[i], _vetoresAux.EAD[i]);
 
                if (VtValorExposicao2[i] != 0)
                {
                    VtValorPDMedia[i] = decimal.Divide(VtValorPE2[i], VtValorExposicao2[i]);
                    ////VtValorWI[j] = _Cea.CalcularWI(VtValorPDMedia[j], false);
                    vtPrazoMedio[i] = decimal.Divide(vtPrazoMedio2[i], VtValorExposicao2[i]);
                }
 
                if (VtValorEAD2[i] != 0)
                    VtValorLgdMedia[i] = decimal.Divide(VtValorExposicao2[i], VtValorEAD2[i]);
 
            }
        }
 
        ////private void SomaContribuicaoSemConcentracao(int index, decimal num)
        ////{
        ////    lock (mutexContribuicaoSemConcentracao)
        ////    {
        ////        VtContribuicaoRiscoSemConcentracao[index] += num;
        ////    }
        ////}
 
        ////private void SomaContribuicaoSemConcentracaoOriginal(int index, decimal num)
        ////{
        ////    lock (mutexContribuicaoSemConcentracaoOriginal)
        ////    {
        ////        VtContribuicaoRiscoSemConcentracaoOriginal[index] += num;
        ////    }
        ////}
 
        private void SomaVtValorEAD(int index, decimal num)
        {
            lock (mutexVtValorEAD)
            {
                VtValorEAD[index] += num;
            }
        }
 
        private void SomaVtValorEADOriginal(int index, decimal num)
        {
            lock (mutexVtValorEADOriginal)
            {
                VtValorEADOriginal[index] += num;
            }
        }
 
        private void SomaVtValorEADOriginalGrupo(int index, decimal num)
        {
            lock (mutexVtValorEADOriginalGrupo)
            {
                VtValorEADOriginalGrupo[index] += num;
            }
        }
 
        private void SomaVtValorExposicao(int index, decimal num)
        {
            lock (mutexVtValorExposicao)
            {
                VtValorExposicao[index] += num;
            }
        }
 
        private void SomaVtValorExposicaoOriginal(int index, decimal num)
        {
            lock (mutexVtValorExposicaoOriginal)
            {
                VtValorExposicaoOriginal[index] += num;
            }
        }
 
        private void SomaVtValorPE(int index, decimal num)
        {
            lock (mutexVtValorPE)
            {
                VtValorPE[index] += num;
            }
        }
 
        private void SomaVtValorPEOriginal(int index, decimal num)
        {
            lock (mutexVtValorPEOriginal)
            {
                VtValorPEOriginal[index] += num;
                //_vetoresEstoque.PE[index] += num;
            }
        }
 
        #endregion
 
        #region -- CarregarVariaveis --
 
        private void CarregarVariaveis()
        {
            //if ((param.ParamElastReponse.DesvioPadraoPortifolio) <= 0)
            //    throw new SystemException(TraduzMensagens.GetString("parametros_de_elasticidade_desviopadraoportifoli", Idioma) + " " +
            //        TraduzMensagens.GetString("detalhes", Idioma) + "=>Classe:SimulacaoCalculoCEAEstoque Metodo: CarregarVariaveis.");
 
            ////_Cea = new CalculoCEAUtil(param.DataReferencia);
            ////_Cea.Idioma = Idioma;
 
            ////_Cea.KTarget = (decimal)(param.ParamElastReponse.RecalibracaoCapitalNivel1);
            ////_Cea.KOA = (decimal)(param.ParamElastReponse.RecalibracaoCapitalNivel2);
            ////_Cea.KredutorPisos = (decimal)(param.ParamElastReponse.RecalibracaoCapitalNivel3);
            ////_Cea.ParametrosElasticidade = param.ParamElastReponse;
            ////_Cea.CarregarVariaveisR1A();
 
            ////_Regressao = _Cea.DeveUsarVetorWiParaSegmento(param.SegmentoCNPJ, param.DataReferencia);
            ////_RegressaoOriginal = _Cea.DeveUsarVetorWiParaSegmento(param.SegmentoCNPJOriginal, param.DataReferencia);
 
            ////_Cea.UsarRegressaoNoVetorWi = _Regressao;
 
            _length = param.PrazoEstoque + 1;
 
            _vetoresAux = new CEAVetores(_length);
            _vetoresEstoque = new CEAVetores(_length);
            _vetoresCarteira = new CEAVetores(_length);
 
            vtVarMarginal = new decimal[_length];
 
            if (param.PrazoEstoque > param.PrazoOperacaoNova)
                _curvaBRL = (new ExtratorCurvaBDS()).CriaVetorComFatoresDaCurva(param.DataInicioOpNova, param.PrazoEstoque + 1, "BRL");
            else
                _curvaBRL = param.CurvaBRL;
 
            ////VtValorEADCopia = new decimal[_length];
            VtValorEADOriginal = new decimal[_length];
            VtValorEADOriginalGrupo = new decimal[_length];
 
            ////VtValorExposicaoCopia = new decimal[_length];
            VtValorExposicaoOriginal = new decimal[_length];
 
            ////VtValorPECopia = new decimal[_length];
            VtValorPEOriginal = new decimal[_length];
            ////VtContribuicaoRiscoSemConcentracaoCopia = new decimal[_lenght];
            ////VtContribuicaoRiscoSemConcentracaoOriginal = new decimal[_lenght];
 
            ////VtContribuicaoRiscoComConcentracaoCopia = new decimal[_lenght];
            ////VtContribuicaoRiscoComConcentracao = new decimal[_lenght];
            VtFatorCarecagem = new decimal[_length];
 
            ////VarRecalibradoResp = new VaRRecalibradoResponse();
            ////VarRecalibradoRespEstoque = new VaRRecalibradoResponse();
 
            ////VarRecalibradoRespEstoque.VaRRecalibrado_BIS_OA = new decimal[_lenght];
            ////VarRecalibradoRespEstoque.VaRRecalibrado_BIS_OA_Pisos_Redutor = new decimal[_lenght];
            ////VarRecalibradoRespEstoque.VaRRecalibrado_BIS_OA_Pisos_Redutor_Grupo = new decimal[_lenght];
 
            VtValorPDMedia = new decimal[_length];
            ////VtValorWI = new decimal[_lenght];
            VtValorLgdMedia = new decimal[_length];
            VtValorExposicao2 = new decimal[_length];
            VtValorEAD2 = new decimal[_length];
            VtValorPE2 = new decimal[_length];
            vtPrazoMedio2 = new decimal[_length];
 
            ////VtValorKGrupoAntes = new decimal[_lenght];
 
            vtEadCarteira = new decimal[_length];
            vtEadEstoque = new decimal[_length];
            vtPdMediaCarteira = new decimal[_length];
            vtPdMediaEstoque = new decimal[_length];
            vtLgdMediaCarteira = new decimal[_length];
            vtLgdMediaEstoque = new decimal[_length];
            vtPrazoMedioCarteira = new decimal[_length];
            vtPrazoMedioEstoque = new decimal[_length];
            vtPrazoMedio = new decimal[_length];
            vtCEAEstoque = new decimal[_length];
            vtCEACarteira = new decimal[_length];
 
            ////ZerarVetores();
            VtValorEAD = new decimal[_length];
            VtValorExposicao = new decimal[_length];
            VtValorPE = new decimal[_length];
 
            PerdaInesperadaNivel1 = new decimal[_length];
            PerdaInesperadaNivel2 = new decimal[_length];
        }
 
        #endregion
 
        #region -- Calcular CEA --
 
        // Calculo CEA Estoque/Carteira
        private decimal[] CalcularCEA(int pTamanhoVetores, decimal[] pVetorEAD, decimal[] pVetorPD, decimal[] pVetorDuration, decimal[] pVetorLGD,
                                      decimal pPesoCarteira, string pCnpjGrupo, decimal pRquadrado, int pSegmentoModelo)
        {
            try
            {
                int duration = pVetorDuration.Where(w => !w.Equals(0)).Count();
                var result = new decimal[pTamanhoVetores];
 
                int maxDuration = 7200;
 
                var paramCeaRF = new CH5.ParametrosCea();
                var listCurvasRF = new List<CH5.ParametrosCeaCurva>();
 
                //if (pTamanhoVetores - 1 < maxDuration) maxDuration = pTamanhoVetores - 1;
                if (duration < maxDuration) maxDuration = duration;
 
                // Parâmetros da Curva
                for (int i = 0; i < maxDuration; i++)
                {
                    if (pVetorEAD[i] > 0)
                        listCurvasRF.Add(new CH5.ParametrosCeaCurva()
                        {
                            Ead = (decimal)pVetorEAD[i],
                            Pd = (decimal)pVetorPD[i],
                            Duration = pVetorDuration[i],
                            Lgd = pVetorLGD[i],
                            Peso = pPesoCarteira
                        });
                }
 
                if (listCurvasRF.Count > 0)
                {
                    // Parâmetros CEA
                    paramCeaRF.CnpjCliente = pCnpjGrupo;
                    paramCeaRF.CodigoRiskFrontier = 0;
                    paramCeaRF.IdentificadorTipoCliente = TIPO_CLIENTE;
                    paramCeaRF.Rquadrado = pRquadrado;
                    paramCeaRF.SegmentoModelo = pSegmentoModelo;
                    paramCeaRF.Subcanal = COD_SUBCANAL;
                    paramCeaRF.Login = ConfigurationManager.AppSettings["LoginCh5"].ToString(); //"lyIXPDGQgu6PbIf3of+o1Q==";
                    paramCeaRF.Senha = ConfigurationManager.AppSettings["SenhaCh5"].ToString(); //"MRyJ6Mfj3e1ICfn9x8WfUQ==";
                    paramCeaRF.Curva = listCurvasRF;
 
                    var service = new CH5.CalculadoraClient();
                    var listCurvaRetorno = new List<CH5.ParametrosCeaCurvaRetorno>();
 
                    listCurvaRetorno = service.EfetuarCalculo(paramCeaRF);
 
                    // Popular o Retorno
                    for (int i = 0; i < listCurvaRetorno.Count; i++)
                    {
                        result[i] = listCurvaRetorno[i].Resultado;
                    }
 
                    // Replicar o CEA do último dia para operações com prazo superior ao tamanho maximo do Retorno.
                    decimal retValue = result[listCurvaRetorno.Count() - 1];
 
                    for (int i = listCurvaRetorno.Count(); i < duration; i++)
                    {
                        result[i] = retValue;
                    }
 
                }
 
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Detalhes=>Classe: SimulacaoCalculoCEARiskFrontier Metodo: CalcularCEA");
            }
        }
 
        // CEA Operação Nova
        private void CalcularResultadoFinal(decimal[] pPELiquidaNovaOperacao, decimal[] pEADNovaOperacao, decimal pPercentualPisoCEA)
        {
            for (int i = 0; i < _length; i = i + 1)
            {
                if (ParametrosDoSistema.Instance.NovaFormula(Idioma))
                {
                    PerdaInesperadaNivel1[i] = (vtCEACarteira[i] - vtCEAEstoque[i]);
                    PerdaInesperadaNivel2[i] = PerdaInesperadaNivel1[i] * (ParametrosDoSistema.Instance.FatorPerdaInesperadaN2(Idioma, true) / 100);
                    vtVarMarginal[i] = Math.Max(PerdaInesperadaNivel1[i] + pPELiquidaNovaOperacao.ToList().GetValue(i), pEADNovaOperacao.ToList().GetValue(i) * pPercentualPisoCEA);
                }
                else
                {
                    vtVarMarginal[i] = Math.Max(vtCEACarteira[i] - vtCEAEstoque[i], pEADNovaOperacao.ToList().GetValue(i) * pPercentualPisoCEA);
                }
 
                if (vtVarMarginal[i] < 0.01M)
                    vtVarMarginal[i] = 0;
            }
 
        }
 
        #endregion
    }
}