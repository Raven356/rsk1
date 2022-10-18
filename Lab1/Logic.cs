using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab1
{
    class Logic
    {
        public List<List<string>> Values { get; set; } = new List<List<string>>
        {
            new List<string>{ "Т1", "С1", "Т2", "Т4", "Т5"},
            new List<string>{ "Т5", "Т1", "Т3", "Т2", "Т4"},
            new List<string>{ "Т5", "С1", "Т1", "Т2", "Т3", "Ф2", "Ф3", "Р1"},
            new List<string>{ "Т1", "С1", "Т2", "Т3", "Т4"},
            new List<string>{ "Т2", "С2", "Т3", "Т4", "Т5"},
            new List<string>{ "Т1", "С3", "Ф2", "Т4", "Т5"},
            new List<string>{ "Т1", "С1", "Т2", "Т3", "С2", "Т4", "Т5"},
            new List<string>{ "Т1", "С1", "С2", "Т2", "С3", "Ф2", "Т4", "Т5"},
            new List<string>{ "Т1", "Т2", "С3", "Ф2", "Т4", "Ф3", "Ф4", "Т5"},
            new List<string>{ "Т2", "С3", "Ф2", "Т4", "Т5", "Ф3", "Ф4"},
            new List<string>{ "Т1", "С1", "Т2", "С3", "Ф2", "Т4", "Ф3", "Ф4"},
            new List<string>{ "Т1", "С1", "Т2", "Ф3", "Т5", "С3", "Ф2", "Т4"},
            new List<string>{ "Т2", "Ф1", "Ф2", "Т1", "С3", "Р1", "Т4", "Т5"},
            new List<string>{ "Т1", "С3", "Ф2", "Т4", "Т5"}
        };
        private List<string> unique;
        public List<List<int>> Nvalues = new List<List<int>>();
        public int[,] ContiguityMatrix;
        public List<List<int>> UnUnique = new List<List<int>>();

        public void GetUnique()
        {
            if (Values == null)
                return;
            unique = new List<string>();
            foreach (var x in Values[0])
            {
                unique.Add(x);
            }
            for (int i = 1; i < Values.Count; i++)
            {
                for (int j = 0; j < Values[i].Count; j++)
                {
                    if (!unique.Contains(Values[i][j]))
                        unique.Add(Values[i][j]);
                }
            }
            CreateContiguityMatrix();
        }

        public void CreateContiguityMatrix()
        {
            int[,] contiguityMatrix = new int[Values.Count, unique.Count];
            List<List<int>> unUnique = new List<List<int>>();
            for (int i = 0; i < Values.Count; i++)
            {
                for (int j = 0; j < unique.Count; j++)
                {
                    if (Values[i].Contains(unique[j]))
                    {
                        contiguityMatrix[i, j] = 1;
                    }
                    else
                    {
                        contiguityMatrix[i, j] = 0;
                    }
                }
            }

           
            for (int i = 0; i < contiguityMatrix.GetLength(0); i++)
            {
                unUnique.Add(new List<int>());
                for (int k = i; k < contiguityMatrix.GetLength(0); k++)
                {
                    //for(int l = 0; l < k; l++)
                    //{
                    //    unUnique[i].Add(unUnique[l][k]);
                    //}
                    unUnique[i].Add(0);
                    for (int j = 0; j < contiguityMatrix.GetLength(1); j++)
                    {
                        if (contiguityMatrix[i, j] != contiguityMatrix[k, j])
                        {
                            unUnique[i][^1]++;
                        }

                    }
                }
            }

            ContiguityMatrix = contiguityMatrix;

            for (int i = 0; i < unUnique.Count; i++)
            {
                UnUnique.Add(new List<int>());
                for (int j = 0; j < unUnique[i].Count; j++)
                {
                    UnUnique[i].Add(unUnique[i][j]);
                }
            }

            CreateTable(unUnique);
        }

        public void CreateTable(List<List<int>> values)
        {
            //int[,] test = new int[values.Count, values.Count];
            //for(int i = 0; i < values.Count; i++)
            //{
            //    for(int j = 0; j < values[i].Count; j++)
            //    {
            //        if(i > j)
            //        {
            //            test[i, j] = values[j][i];
            //        }
            //        else if(i == j)
            //        {
            //            test[i, j] = 0;
            //        }
            //        else
            //        {
            //            test[i, j] = values[i][j];
            //        }
            //    }
            //}
            for (int i = 0; i < values.Count; i++)
            {
                for (int j = 1; j < values[i].Count; j++)
                {
                    values[i][j] = unique.Count - values[i][j];
                }
            }


            for (int i = 0; i < values.Count; i++)
            {
                Nvalues.Add(new List<int>());
                for (int j = 0; j < values[i].Count; j++)
                {
                    Nvalues[i].Add(values[i][j]);
                }
            }


            GetPairs(values);
        }

        public void GetPairs(List<List<int>> values)
        {
            List<List<string>> answer = new List<List<string>>();
            //Dictionary<int, List<int>> answer = new Dictionary<int, List<int>>();
            bool extra = false;
            for (int i = 0; i < values.Count; i++)
            {
                for (int j = 0; j < values[i].Count; j++)
                {
                    if (values[i][j] == values.Max(x => x.Max()) && values[i][j] != 0)
                    {
                        //if (answer.ContainsKey(values.Max(x => x.Max())))
                        //{
                        //    foreach (var x in answer)
                        //    {
                        //        if (x.Key == values.Max(x => x.Max()))
                        //        {
                        //            List<int> temp = x.Value;
                        //            temp.Add(i);
                        //            temp.Add(j);
                        //            answer.Remove(x.Key);
                        //            answer.Add(values.Max(x => x.Max()), temp);
                        //            break;
                        //        }
                        //    }
                        //}
                        //else
                        //    answer.Add(values.Max(x => x.Max()), new List<int> { i, j });
                        answer.Add(new List<string>());
                        string answ = $"{i + 1}, {j + 1 }";



                        for (int i1 = 0; i1 < values.Count; i1++)
                        {
                            if (j < values[i1].Count)
                            {
                                if (values[i1][j] == values.Max(x => x.Max()) && i1 != i)
                                {
                                    extra = true;
                                    values[i1][j] = 0;
                                    answ += $", {i1 + 1}";
                                    SetZeroI(i1, values);
                                    SetZeroJ(i1, values);
                                }
                            }

                        }
                        if (extra)
                        {
                            SetZeroJ(j, values);
                            extra = false;
                        }


                        for (int j1 = 0; j1 < values[i].Count; j1++)
                        {
                            if (i < values.Count)
                            {
                                if (values[i][j1] == values.Max(x => x.Max()) && j1 != j)
                                {
                                    values[i][j1] = 0;
                                    answ += $", {j1 + 1}";
                                    SetZeroI(j1, values);
                                    SetZeroJ(j1, values);
                                }
                            }
                        }
                        if (extra)
                        {
                            SetZeroI(i, values);
                            extra = false;
                        }

                        SetZero(i, j, values);
                        SetZero(j, i, values);
                        values[i][j] = 0;
                        i = 0;
                        j = 0;

                        answer[answer.Count - 1].Add(answ);
                    }
                }
            }
            //Dictionary<int, List<int>> final = new Dictionary<int, List<int>>();
            //foreach(var x in answer)
            //{
            //    List<int> temp = x.Value.Distinct().ToList();
            //    int key = x.Key;
            //    final.Add(key, temp);
            //}

            for (int i = 0; i < answer.Count; i++)
            {
                for (int j = 0; j < answer[i].Count; j++)
                    answer[i][j] = string.Join(", ", answer[i][j].Split(", ").Distinct());
            }
            Console.WriteLine();
        }

        public void SetZeroJ(int j, List<List<int>> values)
        {
            for (int i1 = 0; i1 < values.Count; i1++)
            {
                if (j < values[i1].Count)
                    values[i1][j] = 0;
            }
        }

        public void SetZeroI(int i, List<List<int>> values)
        {
            for (int j1 = 0; j1 < values[i].Count; j1++)
            {
                if (i < values.Count)
                    values[i][j1] = 0;
            }
        }

        public void SetZero(int i, int j, List<List<int>> values)
        {
            SetZeroI(i, values);
            SetZeroJ(j, values);
        }
    }
}
