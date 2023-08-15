using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using ClosedXML.Excel;
using ibba.raroc.Entidades;

namespace Sample.UsandoClosedXml
{
     public static class Extensions
    {
        public static T GetValue<T>(this List<T> vetor, int index)
        {
            T value = default(T);
 
            if (index < vetor.Count)
            {
                value = vetor[index];
            }
 
            return value;
        }
 
        public static decimal AdicionarMemoriaCalculo(this decimal param, int hashCode, string sheetName, string nomeColuna)
        {
            DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna, XLCellValues.Number, param);
            return param;
        }
 
        public static int AdicionarMemoriaCalculo(this int param, int hashCode, string sheetName, string nomeColuna)
        {
            DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna, XLCellValues.Number, param);
            return param;
        }
 
        public static string AdicionarMemoriaCalculo(this string param, int hashCode, string sheetName, string nomeColuna)
        {
            DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna, XLCellValues.Text, param);
            return param;
        }
 
        public static DateTime AdicionarMemoriaCalculo(this DateTime param, int hashCode, string sheetName, string nomeColuna)
        {
            DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna, XLCellValues.DateTime, param);
            return param;
        }
 
        public static bool AdicionarMemoriaCalculo(this bool param, int hashCode, string sheetName, string nomeColuna)
        {
            DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna, XLCellValues.Text, param);
            return param;
        }
 
        public static double AdicionarMemoriaCalculo(this double param, int hashCode, string sheetName, string nomeColuna)
        {
            DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna, XLCellValues.Number, param);
            return param;
        }
 
        public static List<DateTime> AdicionarMemoriaCalculo(this List<DateTime> enumerable, int hashCode, string sheetName, string nomeColuna)
        {
            if (enumerable != null && enumerable.Count > 0)
            {
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna, XLCellValues.DateTime, enumerable.AsEnumerable());
            }
 
            return enumerable;
        }
 
        public static List<decimal> AdicionarMemoriaCalculo(this List<decimal> enumerable, int hashCode, string sheetName, string nomeColuna)
        {
            if (enumerable != null && enumerable.Count > 0)
            {
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna, XLCellValues.Number, enumerable.AsEnumerable());
            }
 
            return enumerable;
        }
 
        public static List<double> AdicionarMemoriaCalculo(this List<double> enumerable, int hashCode, string sheetName, string nomeColuna)
        {
            if (enumerable != null && enumerable.Count > 0)
            {
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna, XLCellValues.Number, enumerable.AsEnumerable());
            }
 
            return enumerable;
        }
 
        public static DateTime[] AdicionarMemoriaCalculo(this DateTime[] enumerable, int hashCode, string sheetName, string nomeColuna)
        {
            if (enumerable != null && enumerable.Length > 0)
            {
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna, XLCellValues.Number, enumerable.AsEnumerable());
            }
 
            return enumerable;
        }
 
        public static decimal[] AdicionarMemoriaCalculo(this decimal[] enumerable, int hashCode, string sheetName, string nomeColuna)
        {
            if (enumerable != null && enumerable.Length > 0)
            {
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna, XLCellValues.Number, enumerable.AsEnumerable());
            }
 
            return enumerable;
        }
 
        public static double[] AdicionarMemoriaCalculo(this double[] enumerable, int hashCode, string sheetName, string nomeColuna)
        {
            if (enumerable != null && enumerable.Length > 0)
            {
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna, XLCellValues.Number, enumerable.AsEnumerable());
            }
 
            return enumerable;
        }
 
        public static int[] AdicionarMemoriaCalculo(this int[] enumerable, int hashCode, string sheetName, string nomeColuna)
        {
            if (enumerable != null && enumerable.Length > 0)
            {
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna, XLCellValues.Number, enumerable.AsEnumerable());
            }
 
            return enumerable;
        }
 
        public static Dictionary<DateTime, decimal> AdicionarMemoriaCalculo(this Dictionary<DateTime, decimal> enumerable, int hashCode, string sheetName, string nomeColuna)
        {
            if (enumerable != null && enumerable.Count > 0)
            {
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna + " Data", XLCellValues.DateTime, enumerable.Keys.AsEnumerable());
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna + " Valor", XLCellValues.Number, enumerable.Values.AsEnumerable());
            }
 
            return enumerable;
        }
 
        public static Dictionary<string, decimal> AdicionarMemoriaCalculo(this Dictionary<string, decimal> enumerable, int hashCode, string sheetName, string nomeColuna)
        {
            if (enumerable != null && enumerable.Count > 0)
            {
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna + " Nome", XLCellValues.DateTime, enumerable.Keys.AsEnumerable());
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna + " Valor", XLCellValues.Number, enumerable.Values.AsEnumerable());
            }
 
            return enumerable;
        }
 
        public static TipoVisao<Dictionary<DateTime, decimal?>> AdicionarMemoriaCalculo(this TipoVisao<Dictionary<DateTime, decimal?>> enumerable, int hashCode, string sheetName, string nomeColuna)
        {
            if (enumerable != null && enumerable.Total.Count > 0)
            {
                List<string> valores = new List<string>();
 
                enumerable.Total.Values.ForEach(d =>
                    {
                        if (d.HasValue)
                            valores.Add(d.ToString());
                        else
                            valores.Add(string.Empty);
                    }
                );
 
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna + " - Total", XLCellValues.Text, valores.AsEnumerable());
            }
 
            if (enumerable != null && enumerable.Credito.Count > 0)
            {
                List<string> valores = new List<string>();
 
                enumerable.Credito.Values.ForEach(d =>
                {
                    if (d.HasValue)
                        valores.Add(d.ToString());
                    else
                        valores.Add(string.Empty);
                }
                );
 
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna + " - Credito", XLCellValues.Text, valores.AsEnumerable());
            }
 
            return enumerable;
        }
 
        public static List<GrupoClientesOperacoesResponse> AdicionarMemoriaCalculo(this List<GrupoClientesOperacoesResponse> enumerable, int hashCode, string sheetName)
        {
            if (enumerable != null && enumerable.Count > 0)
            {
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "CodigoGrupoCliente", XLCellValues.Text, enumerable.Select(g => g.CodigoGrupoCliente));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "CodRiskRating", XLCellValues.Text, enumerable.Select(g => g.CodRiskRating));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "DataAbertura", XLCellValues.DateTime, enumerable.Select(g => g.DataAbertura));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "DataVencimento", XLCellValues.DateTime, enumerable.Select(g => g.DataVencimento));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "ValorOperacao", XLCellValues.Number, enumerable.Select(g => g.ValorOperacao));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "ValorRiscoConcordata", XLCellValues.Number, enumerable.Select(g => g.ValorRiscoConcordata));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "QtdeDiasPrazoMedio", XLCellValues.Number, enumerable.Select(g => g.QtdeDiasPrazoMedio));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "ValorOperacaoRaroc", XLCellValues.Number, enumerable.Select(g => g.ValorOperacaoRaroc));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "PercLgdMitigado", XLCellValues.Number, enumerable.Select(g => g.PercLgdMitigado));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "ValorEadClean", XLCellValues.Number, enumerable.Select(g => g.ValorEadClean));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "ValorEadMitigado", XLCellValues.Number, enumerable.Select(g => g.ValorEadMitigado));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "ValorEadComplexas", XLCellValues.Number, enumerable.Select(g => g.ValorEadComplexas));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "PDOperacao", XLCellValues.Number, enumerable.Select(g => g.PDOperacao));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "VaRRecalibrado_BIS_OA_Pisos_Redutor_Antes", XLCellValues.Number, enumerable.Select(g => g.VaRRecalibrado_BIS_OA_Pisos_Redutor_Antes));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "VaRRecalibrado_BIS_OA_Pisos_Redutor_Depois", XLCellValues.Number, enumerable.Select(g => g.VaRRecalibrado_BIS_OA_Pisos_Redutor_Depois));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "ContribuicaoSemConcentracaoAntes", XLCellValues.Number, enumerable.Select(g => g.ContribuicaoSemConcentracaoAntes));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "ContribuicaoSemConcentracaoDepois", XLCellValues.Number, enumerable.Select(g => g.ContribuicaoSemConcentracaoDepois));
            }
 
            return enumerable;
        }
 
        public static List<ProjecaoCalculoRiscoHistorico> AdicionarMemoriaCalculo(this List<ProjecaoCalculoRiscoHistorico> enumerable, int hashCode, string sheetName)
        {
            if (enumerable != null && enumerable.Count > 0)
            {
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "IDGrupoCliente", XLCellValues.Number, enumerable.Select(g => g.IDGrupoCliente));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "DataBaseHistorico", XLCellValues.DateTime, enumerable.Select(g => g.DataBaseHistorico));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "IndicadorTipoProjecaoRisco", XLCellValues.Text, enumerable.Select(g => g.TipoProjecaoRisco.ToString()));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "ValorSaldoMedio", XLCellValues.Number, enumerable.Select(g => g.ValorSaldoMedio));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "ValorCusto", XLCellValues.Number, enumerable.Select(g => g.ValorCusto));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "ValorCEA", XLCellValues.Number, enumerable.Select(g => g.ValorCEA));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "ValorPisCofins", XLCellValues.Number, enumerable.Select(g => g.ValorPisCofins));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "ValorMargem", XLCellValues.Number, enumerable.Select(g => g.ValorMargem));
            }
 
            return enumerable;
        }
 
        public static Dictionary<string, decimal[]> AdicionarMemoriaCalculo(this Dictionary<string, decimal[]> enumerable, int hashCode, string sheetName)
        {
            if (enumerable != null && enumerable.Count > 0)
            {
                foreach (var item in enumerable)
                {
                    DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, item.Key, XLCellValues.Text, item.Value.AsEnumerable());
                }
            }
 
            return enumerable;
        }
 
        public static Dictionary<string, double[]> AdicionarMemoriaCalculo(this Dictionary<string, double[]> enumerable, int hashCode, string sheetName)
        {
            foreach (var item in enumerable)
            {
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, item.Key, XLCellValues.Text, item.Value.AsEnumerable());
            }
 
            return enumerable;
        }
 
        public static List<ObterDiasUteisResponse> AdicionarMemoriaCalculo(this List<ObterDiasUteisResponse> enumerable, int hashCode, string sheetName)
        {
            if (enumerable != null && enumerable.Count > 0)
            {
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "Data", XLCellValues.Number, enumerable.Select(g => g.Data));
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, "DiaUtil", XLCellValues.Text, enumerable.Select(g => g.DiaUtil));
            }
 
            return enumerable;
        }
 
        public static TipoVisao<List<decimal>> AdicionarMemoriaCalculo(this TipoVisao<List<decimal>> enumerable, int hashCode, string sheetName, string nomeColuna)
        {
            if (enumerable != null && enumerable.Total.Count > 0)
            {
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna + " - Total", XLCellValues.Number, enumerable.Total.AsEnumerable());
            }
 
            if (enumerable != null && enumerable.Credito.Count > 0)
            {
                DadosCalculoExcel.Intance.Adicionar(hashCode, sheetName, nomeColuna + " - Credito", XLCellValues.Number, enumerable.Credito.AsEnumerable());
            }
 
            return enumerable;
        }
    }
}
