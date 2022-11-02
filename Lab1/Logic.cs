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
        public List<List<int>> Answer = new List<List<int>>();
        public List<List<int>> GroupedAnswer = new List<List<int>>();

        public void GetUnique()
        {
            Answer = new List<List<int>>();
            GroupedAnswer = new List<List<int>>();
            UnUnique = new List<List<int>>();
            Nvalues = new List<List<int>>();
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
            
            for (int i = 0; i < values.Count; i++)
            {
                for (int j = 1; j < values[i].Count; j++)
                {
                    values[i][j] = unique.Count - values[i][j];
                }
            }

            for(int i = 0; i < values.Count; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    values[i].Insert(j, 0);
                }
            }

            for(int i = 0; i < values.Count; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    values[i][j] = values[j][i];
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
            List<List<int>> answer = new List<List<int>>();
            bool extra = false;
            for (int i = 0; i < values.Count; i++)
            {
                for (int j = 0; j < values[i].Count; j++)
                {
                    if (values[i][j] == values.Max(x => x.Max()) && values[i][j] != 0)
                    {
                        
                        List<int> answ = new List<int> { i + 1, j + 1  };



                        for (int i1 = 0; i1 < values.Count; i1++)
                        {
                            if (j < values[i1].Count)
                            {
                                if (values[i1][j] == values.Max(x => x.Max()) && i1 != i)
                                {
                                    extra = true;
                                    values[i1][j] = 0;
                                    answ.Add(i1 + 1);
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
                                    answ.Add(j1 + 1);
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

                        answer.Add(answ);
                    }
                }
            }

            int amount = 0;
            foreach(var x in answer)
            {
                amount += x.Count;
            }
            if (amount + 1 == values.Count)
            {
                List<int> elements = new List<int>();
                foreach (var x in answer)
                {
                    foreach (var y in x) {
                        elements.Add(y);
                    }
                }
                elements.Sort();
                for(int i = 0; i < values.Count; i++)
                {
                    if(elements[i] != i + 1)
                    {
                        answer.Add(new List<int>());
                        answer[^1].Add(i + 1);
                        break;
                    }
                }
            }

            for (int i = 0; i < answer.Count; i++)
            {
                for (int j = 0; j < answer[i].Count; j++)
                    answer[i] =  answer[i].Distinct().ToList();
            }
            Answer = answer;
            GroupedGroups();
        }

        //RSK2
        public void GroupedGroups()
        {
            Dictionary<List<int>, List<string>> dictionary = new Dictionary<List<int>, List<string>>();
            foreach(var x in Answer)
            {
                List<string> temp = new List<string>();
                foreach(var y in x)
                {
                    temp.AddRange(Values[y - 1]);
                }
                temp = temp.Distinct().ToList();
                dictionary.Add(x, temp);
            }
            dictionary = SortDictionary(dictionary);
            for (int i = 0; i < dictionary.Count; i++)
            {
                dictionary = ConsumeFullGroup(dictionary, i);
                dictionary = ConsumeLonelyVictim(dictionary, i);
            }
            foreach (var x in dictionary)
            {
                List<int> temp = new List<int>();
                temp.AddRange(x.Key);
                GroupedAnswer.Add(temp);
            }
            Console.WriteLine();
        }


        public Dictionary<List<int>, List<string>> ConsumeFullGroup(Dictionary<List<int>, List<string>> dictionary, int i)
        {
            List<KeyValuePair<List<int>, List<string>>> myList = dictionary.ToList();
            for (int j = i + 1; j < myList.Count; j++)
            {
                bool notConsumable = false;
                foreach (var x in myList[j].Value)
                {
                    if (!myList[i].Value.Contains(x))
                    {
                        notConsumable = true;
                    }
                }
                if (!notConsumable)
                {
                    List<int> temp = new List<int>();
                    temp.AddRange(myList[i].Key);
                    temp.AddRange(myList[j].Key);
                    KeyValuePair<List<int>, List<string>> tempI = new KeyValuePair<List<int>, List<string>>(myList[i].Key, myList[i].Value);
                    KeyValuePair<List<int>, List<string>> tempJ = new KeyValuePair<List<int>, List<string>>(myList[j].Key, myList[j].Value);
                    myList.Add(new KeyValuePair<List<int>, List<string>>(temp, myList[i].Value));
                    myList.Remove(tempI);
                    myList.Remove(tempJ);
                }
            }
            return SortDictionary(myList.Select(x => new { x.Key, x.Value }).ToDictionary(x => x.Key, x => x.Value));
        }

        public Dictionary<List<int>, List<string>> ConsumeLonelyVictim(Dictionary<List<int>, List<string>> dictionary, int i)
        {
            List<KeyValuePair<List<int>, List<string>>> myList = SortDictionary(dictionary).ToList();
            for(int j = i + 1; j < myList.Count; j++)
            {
                foreach(var x in myList[j].Key)
                {
                    bool notConsumable = false;
                    foreach (var y in Values[x - 1])
                        if (!myList[i].Value.Contains(y))
                        {
                            notConsumable = true;
                            break;
                        }
                    if (!notConsumable)
                    {
                        List<int> numbersI = new List<int>();
                        numbersI.AddRange(myList[i].Key);
                        numbersI.Add(x);

                        List<int> numbersJ = new List<int>();
                        numbersJ.AddRange(myList[j].Key);
                        numbersJ.Remove(x);

                        List<string> keysI = new List<string>();
                        keysI.AddRange(myList[i].Value);

                        List<string> keysJ = new List<string>();
                        foreach(var y in myList[j].Key)
                        {
                            if(y != x)
                            {
                                keysJ.AddRange(Values[y - 1]);
                            }
                        }
                        keysJ = keysJ.Distinct().ToList();

                        KeyValuePair<List<int>, List<string>> oldValuesI = new KeyValuePair<List<int>, List<string>>(myList[i].Key, myList[i].Value);
                        KeyValuePair<List<int>, List<string>> oldValuesJ = new KeyValuePair<List<int>, List<string>>(myList[j].Key, myList[j].Value);

                        myList.Add(new KeyValuePair<List<int>, List<string>>(numbersI, keysI));
                        myList.Add(new KeyValuePair<List<int>, List<string>>(numbersJ, keysJ));
                        myList.Remove(oldValuesI);
                        myList.Remove(oldValuesJ);
                        myList = SortDictionary(myList.Select(x => new { x.Key, x.Value }).ToDictionary(x => x.Key, x => x.Value)).ToList();
                    }
                }
            }
            return SortDictionary(myList.Select(x => new { x.Key, x.Value }).ToDictionary(x => x.Key, x => x.Value));
        }

        public Dictionary<List<int>, List<string>> SortDictionary(Dictionary<List<int>, List<string>> dictionary)
        {
            List<KeyValuePair<List<int>, List<string>>> myList = dictionary.ToList();

            myList.Sort(
                delegate (KeyValuePair<List<int>, List<string>> pair1,
                KeyValuePair<List<int>, List<string>> pair2)
                {
                    if(pair1.Value.Count != pair2.Value.Count)
                        return -pair1.Value.Count + pair2.Value.Count;
                    return -pair1.Key.Count + pair2.Key.Count;
                }
            );
            dictionary = myList.Select(x => new { x.Key, x.Value }).ToDictionary(x => x.Key, x => x.Value);
            return dictionary;
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
