using System;
using System.Collections.Generic;

namespace Sample.AnaliseCombinatoria
{

    public class Board
    {
        public class Cell
        {
            public int Column { get; set; }
            public int Row { get; set; }
            public string Value { get; set; }
            public string ValidValues { get; set; }
        }

        private readonly static Board _instance = new Board();

        Random _random;
        private int _operador;
        private int _dimensao;

        #region [ propriedades ]

        public static Board Instance { get { return _instance; } }

        public Cell[,] Matriz { get; private set; }

        #endregion

        private Board()
        {
            _operador = (DateTime.Now.Millisecond % 4) + 1;
            _random = new Random();
        }

        public void Carregar(int pDimension)
        {
            _dimensao = pDimension;

            for (int i = 0; i < 1000; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" <<<<<<<<  PREPARANDO MATRIZ >>>>>>>>");
                Console.ForegroundColor = ConsoleColor.White;

                PrepararMatriz();

                if (_dimensao == 5)
                {
                    //SetValue(0,0,"4");	SetValue(0,1,"1");	SetValue(0,2,"3");	SetValue(0,3,"5");	SetValue(0,4,"2");
                    //SetValue(1,0,"2");	SetValue(1,1,"4");	SetValue(1,2,"5");	SetValue(1,3,"3");	SetValue(1,4,"1");
                    //SetValue(2,0,"1");	

                    //SetValue(0, 0, "4"); SetValue(0, 1, "1"); SetValue(0, 2, "3"); SetValue(0, 3, "5"); SetValue(0, 4, "2");
                    //SetValue(1, 0, "2"); SetValue(1, 1, "4"); SetValue(1, 2, "5"); SetValue(1, 3, "3"); SetValue(1, 4, "1");
                    //SetValue(2, 0, "1");
                }

                if (_dimensao == 6)
                {
                    //SetValue(0, 0, "2"); SetValue(0, 1, "5"); SetValue(0, 2, "3"); SetValue(0, 3, "4"); SetValue(0, 4, "6"); SetValue(0, 5, "1");
                    //SetValue(1, 0, "3"); SetValue(1, 1, "2"); SetValue(1, 2, "5"); SetValue(1, 3, "6"); SetValue(1, 4, "1"); SetValue(1, 5, "4");
                    //SetValue(2, 0, "6"); SetValue(2, 1, "4"); SetValue(2, 2, "2");

                    //SetValue(0, 0, "5"); SetValue(0, 1, "4"); SetValue(0, 2, "1"); SetValue(0, 3, "6"); SetValue(0, 4, "3"); SetValue(0, 5, "2");
                    //SetValue(1, 0, "3"); SetValue(1, 1, "2"); SetValue(1, 2, "4"); SetValue(1, 3, "5"); SetValue(1, 4, "6"); SetValue(1, 5, "1");
                    //SetValue(2, 0, "2"); SetValue(2, 1, "3"); SetValue(2, 2, "5"); SetValue(2, 3, "4"); SetValue(2, 4, "1"); SetValue(2, 5, "6");
                    //SetValue(3, 0, "4"); SetValue(3, 1, "1");

                    //SetValue(0, 0, "4"); SetValue(0, 1, "1"); SetValue(0, 2, "5"); SetValue(0, 3, "6"); SetValue(0, 4, "3"); SetValue(0, 5, "2");
                    //SetValue(1, 0, "5"); SetValue(1, 1, "4"); SetValue(1, 2, "6"); SetValue(1, 3, "3"); SetValue(1, 4, "2"); SetValue(1, 5, "1");
                    //SetValue(2, 0, "6"); SetValue(2, 1, "5"); SetValue(2, 2, "1"); SetValue(2, 3, "2"); SetValue(2, 4, "4"); SetValue(2, 5, "3");
                    //SetValue(3, 0, "1"); //SetValue(3, 1, "2"); //SetValue(3, 2, "234>23"); SetValue(3, 3, "45"); SetValue(3, 4, "56"); SetValue(3, 5, "456");

                    //SetValue(0, 0, "4"); SetValue(0, 1, "2"); SetValue(0, 2, "3"); SetValue(0, 3, "1"); SetValue(0, 4, "6"); SetValue(0, 5, "5");
                    //SetValue(1, 0, "2"); SetValue(1, 1, "5"); SetValue(1, 2, "4"); SetValue(1, 3, "3"); SetValue(1, 4, "1"); SetValue(1, 5, "6");
                    //SetValue(2, 0, "3"); SetValue(2, 1, "1"); SetValue(2, 2, "5"); SetValue(2, 3, "6"); SetValue(2, 4, "4"); SetValue(2, 5, "2");
                    //SetValue(3, 0, "5"); //SetValue(3, 1, "346>34"); SetValue(3, 2, "126"); SetValue(3, 3, "24"); SetValue(3, 4, "23"); SetValue(3, 5, "134>34");


                }
                Sortear();
                //SortearNumeros();

                if (!TestarIntegridade())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n<<<<< ERRO DE INTEGRIDADE DOS NUMEROS SORTEADOS! {0} >>>>>\n\n", i);
                    i--;
                }
                else
                    Console.ForegroundColor = ConsoleColor.DarkGreen;

            }

            string str;
            for (int x = 0; x < _dimensao; x++)
            {
                str = "";
                for (int y = 0; y < _dimensao; y++)
                {
                    str += Matriz[x, y].Value.ToString() + " ";
                }
                Console.WriteLine(str);
            }

            //Console.Read();
        }

        private void PrepararMatriz()
        {
            string values = "";

            for (int val = 1; val <= _dimensao; val++)
                values += val.ToString();

            this.Matriz = new Cell[_dimensao, _dimensao];

            for (int row = 0; row < _dimensao; row++)
            {
                for (int col = 0; col < _dimensao; col++)
                {
                    Matriz[col, row] = new Cell()
                    {
                        Value = "0",
                        ValidValues = values,
                        Row = row,
                        Column = col
                    };
                }
            }
        }

        private void Sortear()
        {
            for (int x = 0; x < _dimensao; x++)
            {
                SetRowNumbers(x);
            }
        }

        private void SetRowNumbers(int row)
        {
            List<string> resetValues = new List<string>();
            string validValues;
            string value = "";
            int count;
            bool testOK;

            //guarda os valores para restauração se algo sair errado
            if (_dimensao > 4)
            {
                for (int y = 0; y < _dimensao; y++)
                    resetValues.Add(Matriz[row, y].ValidValues);
            }

            for (int y = 0; y < _dimensao; y++)
            {
                testOK = false;
                validValues = Matriz[row, y].ValidValues;
                count = 0;

                if (_dimensao > 4)
                {
                    #region [ verificar possível valor único ]

                    //antes de selecionar valor aleatorio, verifica se existe algum numero unico ]
                    //ex: 34 | 45 | 45 -> se for seleciona o valor 4 na primeira celula, irá tornar impossível resolver 
                    for (int i = 0; i < validValues.Length; i++)
                    {
                        value = validValues[i].ToString();

                        //Verificando se existe valor igual na coluna
                        testOK = true;
                        for (int x2 = row + 1; x2 < _dimensao; x2++)
                        {
                            if (Matriz[x2, y].ValidValues.Contains(value))
                            {
                                testOK = false;
                                break;
                            }
                        }

                        //Se valor único finaliza
                        if (testOK) break;
                    }

                    #endregion

                    #region [ verifica valores duplicados ]

                    if (testOK)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("REGRA UNITARIO [{0},{1}] {2} => {3}", row, y, validValues, value);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        //Verificando valores em duplicidade na linha
                        string values = validValues;

                        if (!testOK)
                            for (int y2 = y + 1; y2 < _dimensao; y2++)
                            {
                                if (Matriz[row, y2].ValidValues.Length == 2)
                                {
                                    value = Matriz[row, y2].ValidValues;
                                    count = 1;
                                    for (int yp = y2 + 1; yp < _dimensao; yp++)
                                    {
                                        if (value.Equals(Matriz[row, yp].ValidValues))
                                        {
                                            count++;
                                        }
                                        testOK = (count.Equals(2));

                                        if (testOK) break;
                                    }
                                }

                                if (testOK) break;
                            }

                        if (testOK)
                        {
                            for (int i = 0; i < value.Length; i++)
                            {
                                values = values.Replace(value[i].ToString(), "");
                            }
                        }

                        testOK = false;
                        if (values != "" && values != validValues)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("REGRA DUPLAS [{0},{1}] {2} => {3}", row, y, validValues, values);
                            Console.ForegroundColor = ConsoleColor.White;

                            validValues = values;
                        }
                    }

                    #endregion
                }

                if (!testOK)
                {
                    if (validValues.Length >= 1)
                    {
                        int pos = _random.Next(1, validValues.Length + 1);
                        value = validValues.Substring(pos - 1, 1);
                    }
                    else
                        value = validValues;
                }

                testOK = value != "";

                if (testOK)
                    SetValue(row, y, value);
                else
                    break;

            }

            //para tabuleiros maior que 4x4 deve testar integridade
            if (_dimensao > 4 && !TestRowNumbers(row))
            {
                //Restaura valores para tentar novamente
                for (int x = row; x < _dimensao; x++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n<<<< RESTAURANDO EIXO X{0}", x);

                    for (int y = 0; y < resetValues.Count; y++)
                    {
                        Console.WriteLine("[{0},{1}] {2} => {3}", x, y, Matriz[x, y].ValidValues, resetValues[y]);

                        Matriz[x, y].ValidValues = resetValues[y];
                        Matriz[x, y].Value = "0";
                    }
                }
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.White;
                SetRowNumbers(row);
            }

        }

        private bool TestRowNumbers(int row)
        {
            bool nok = false;
            string value;


            for (int y = 0; y < _dimensao; y++)
            {
                value = Matriz[row, y].Value;

                if (value == "0" || value == "")
                    nok = true;

                if (!nok)
                    for (int y2 = y + 1; y2 < _dimensao; y2++)
                    {
                        if (Matriz[row, y2].Value.Equals(value))
                            nok = true;
                    }
                if (nok) break;
            }

            return !(nok);
        }

        private void SortearNumeros()
        {
            string value;

            for (int x = 0; x < _dimensao; x++)
            {
                for (int y = 0; y < _dimensao; y++)
                {
                    value = Matriz[x, y].Value;
                    //Se ainda não tem valor definido
                    if (value.Equals("0"))
                    {
                        string validValues = Matriz[x, y].ValidValues;

                        if (validValues.Length > 1)
                        {
                            value = RandomValue(x, y, validValues);
                        }
                        else
                        {
                            value = validValues;
                        }

                        SetValue(x, y, value);
                    }
                }
            }
        }

        private string RandomValue(int x, int y, string values)
        {
            string value = "";

            //só há necessidade em tabuleiros maiores que 4x4
            if (_dimensao > 4)
            {
                string validValues = values;
                bool testOK = false;
                int count;

                #region [ verificar possível valor único ]

                //antes de selecionar valor aleatorio, verifica se existe algum numero unico ]
                //ex: 34 | 45 | 45 -> se for seleciona o valor 4 na primeira celula, irá tornar impossível resolver 
                for (int i = 0; i < values.Length; i++)
                {
                    value = values[i].ToString();

                    //Verificando se existe valor igual na coluna
                    testOK = true;
                    for (int x2 = x + 1; x2 < _dimensao; x2++)
                    {
                        if (Matriz[x2, y].ValidValues.Contains(value))
                        {
                            testOK = false;
                            break;
                        }
                    }

                    if (!testOK)
                    {
                        //Verificando se existe valor igual na linha
                        testOK = true;
                        for (int y2 = y + 1; y2 < _dimensao; y2++)
                        {
                            if (Matriz[x, y2].ValidValues.Contains(value))
                            {
                                testOK = false;
                                break;
                            }
                        }
                    }

                    //Se valor único finaliza
                    if (testOK) break;
                }

                //Apartir daqui busca por valores unicos em todas as colunas
                if (x >= 3)
                {
                    bool jump = false;
                    string uniqueValue = "";
                    for (int y2 = y + 1; y2 < _dimensao; y2++)
                    {
                        for (int i = 0; i < Matriz[x, y2].ValidValues.Length; i++)
                        {
                            jump = false;
                            uniqueValue = Matriz[x, y2].ValidValues[i].ToString();
                            for (int yy2 = y2 + 1; yy2 < _dimensao; yy2++)
                            {
                                if (Matriz[x, yy2].ValidValues.Contains(uniqueValue))
                                {
                                    jump = true;
                                    break;
                                }
                            }
                            if (!jump)
                                SetValue(x, y2, uniqueValue);
                        }
                    }
                }

                #endregion

                #region [ verifica valores duplicados ]

                if (testOK)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("REGRA UNITARIO [{0},{1}] {2} => {3}", x, y, values, value);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    //Verificando duplicidade na coluna
                    for (int x2 = x + 1; x2 < _dimensao; x2++)
                    {
                        if (Matriz[x2, y].ValidValues.Length == 2)
                        {
                            value = Matriz[x2, y].ValidValues;
                            count = 1;
                            for (int xp = x2 + 1; xp < _dimensao; xp++)
                            {
                                if (value.Equals(Matriz[xp, y].ValidValues))
                                {
                                    count++;
                                }
                                testOK = (count.Equals(2));

                                if (testOK) break;
                            }
                        }

                        if (testOK) break;
                    }

                    //Verificando duplicidade na linha
                    if (!testOK)
                        for (int y2 = y + 1; y2 < _dimensao; y2++)
                        {
                            if (Matriz[x, y2].ValidValues.Length == 2)
                            {
                                value = Matriz[x, y2].ValidValues;
                                count = 1;
                                for (int yp = y2 + 1; yp < _dimensao; yp++)
                                {
                                    if (value.Equals(Matriz[x, yp].ValidValues))
                                    {
                                        count++;
                                    }
                                    testOK = (count.Equals(2));

                                    if (testOK) break;
                                }
                            }

                            if (testOK) break;
                        }

                    if (testOK)
                    {
                        for (int i = 0; i < value.Length; i++)
                        {
                            validValues = validValues.Replace(value[i].ToString(), "");
                        }
                    }

                    value = "";
                    if (validValues != "" && validValues != values)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("REGRA DUPLAS [{0},{1}] {2} => {3}", x, y, values, validValues);
                        Console.ForegroundColor = ConsoleColor.White;

                        values = validValues;
                    }
                }

                #endregion

                #region [ verificar possíveis celulas duplas ]
                /*
                if (value == "")
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        value = values[i].ToString();
                        count = 0;

                        //conta quantos vezes o valor se repete no restande coluna
                        for (int x2 = x + 1; x2 < _dimensao; x2++)
                        {
                            if (Matriz[x2, y].ValidValues.Contains(value))
                                count++;
                        }

                        if (count != 2)
                        {
                            count = 0;
                            //conta quantos vezes o valor se repete no restande linha
                            for (int y2 = y + 1; y2 < _dimensao; y2++)
                            {
                                if (Matriz[x, y2].ValidValues.Contains(value))
                                    count++;
                            }
                        }

                        if (count == 2)
                            validValues = validValues.Replace(value, "");

                        if (validValues.Length == 1)
                            break;
                    }

                    value = "";

                    if (validValues != "" && validValues != values)
                        values = validValues;


                }
                */
                #endregion

                #region [ duplas v3]
                //if (!testOK && Matriz[x, y].ValidValues.Length >= 3)
                //{
                //    value = "";
                //    count = 0;
                //    for (int y2 = y + 1; y2 < _dimensao; y2++)
                //    {
                //        if (Matriz[x, y2].ValidValues.Length == 2)
                //            count++;
                //    }

                //    if (count > 1)
                //    {
                //        //permutacao                         
                //        var curPermute = GetListPermute(values, 2);

                //        for (int y2 = y + 1; y2 < _dimensao; y2++)
                //        {
                //            var outPermute = GetListPermute(Matriz[x, y2].ValidValues, 2);
                //            foreach (var item in outPermute)
                //            {
                //                if (curPermute.ToList().Contains(item))
                //                {
                //                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                //                    Console.WriteLine("PERMUTACAO [{0},{1}] {2} => {3}", x, y, values, item);
                //                    Console.WriteLine("PERMUTACAO [{0},{1}] {2} => {3}", x, y2, Matriz[x, y2].ValidValues, item);
                //                    Console.ForegroundColor = ConsoleColor.White;

                //                    values = item;
                //                    Matriz[x, y2].ValidValues = item;
                //                    testOK=true;
                //                }

                //                if (testOK) break;
                //            }

                //            if (testOK) break;
                //        }
                //    }
                //}
                #endregion

            }


            //Se nao existe valor unico dentro dessa celula então seleciona aleatório
            if (value == "")
            {
                if (values.Length >= 1)
                {
                    int pos = _random.Next(1, values.Length + 1);
                    value = values.Substring(pos - 1, 1);
                }
                else
                    value = values;
            }

            return value;
        }


        public static List<string> GetListPermute(string inputValues, int fixedSize)
        {
            List<string> result = new List<string>();
            string[] input = new string[inputValues.Length];
            string combination = "";

            for (int i = 0; i < inputValues.Length; i++)
            {
                input[i] = inputValues[i].ToString();
            }

            for (int size = 1; size <= inputValues.Length; size++)
            {
                foreach (IEnumerable<string> permutation in Permutation.Permute<string>(input, (fixedSize > 0 ? fixedSize : size)))
                {
                    foreach (string p in permutation)
                    {
                        combination += p;
                    }
                    result.Add(combination);
                    combination = string.Empty;
                }
            }

            return result;
        }


        private void SetValue(int x, int y, string value)
        {
            //bool resul = Matriz[x, y].Value!="";

            if (Matriz[x, y].Value == "0")
            {
                Console.WriteLine("\n");
                Console.WriteLine("SetNumber [{0},{1}] => {2}", x, y, value);

                Matriz[x, y].ValidValues = value.ToString();
                Matriz[x, y].Value = value;

                //Removendo duplicidade do eixo Y
                for (int x2 = 0; x2 < _dimensao; x2++)
                {
                    //Se for uma celula diferente e não teve o valor definido
                    if (x2 != x && Matriz[x2, y].Value.Equals("0"))
                    {
                        Console.WriteLine("[{0},{1}] {2} => {3}", x2, y, Matriz[x2, y].ValidValues, Matriz[x2, y].ValidValues.Replace(value.ToString(), ""));
                        Matriz[x2, y].ValidValues = Matriz[x2, y].ValidValues.Replace(value.ToString(), "");

                        if (Matriz[x2, y].ValidValues.Length == 1)
                            SetValue(x2, y, Matriz[x2, y].ValidValues);
                    }
                }

                //Removendo duplicidade do eixo X
                for (int y2 = 0; y2 < _dimensao; y2++)
                {
                    //Se for uma celula diferente e não teve o valor definido
                    if (y2 != y && Matriz[x, y2].Value.Equals("0"))
                    {
                        Console.WriteLine("[{0},{1}] {2} => {3}", x, y2, Matriz[x, y2].ValidValues, Matriz[x, y2].ValidValues.Replace(value.ToString(), ""));
                        Matriz[x, y2].ValidValues = Matriz[x, y2].ValidValues.Replace(value.ToString(), "");

                        if (Matriz[x, y2].ValidValues.Length == 1)
                            SetValue(x, y2, Matriz[x, y2].ValidValues);
                    }
                }

            }

        }

        /// <summary>
        /// Testar integridade dos numeros sorteados
        /// </summary>
        /// <returns></returns>
        private bool TestarIntegridade()
        {
            bool nok = false;
            string value;
            for (int x = 0; x < _dimensao; x++)
            {
                for (int y = 0; y < _dimensao; y++)
                {
                    value = Matriz[x, y].Value;

                    if (value == "0")
                        nok = true;

                    if (!nok)
                        if (Matriz[x, y].ValidValues.Length > 1)
                            nok = true;

                    if (!nok)
                        for (int x2 = x + 1; x2 < _dimensao; x2++)
                        {
                            if (Matriz[x2, y].Value.Equals(value))
                                nok = true;
                        }

                    if (!nok)
                        for (int y2 = y + 1; y2 < _dimensao; y2++)
                        {
                            if (Matriz[x, y2].Value.Equals(value))
                                nok = true;
                        }

                    if (nok) break;
                }

                if (nok) break;
            }

            return !(nok);
        }

    }
}
