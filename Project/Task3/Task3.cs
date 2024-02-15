using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    /// <summary>
    /// Json.
    /// </summary>
    public class Task3
    {
        protected string TESTS = @"C:\Users\Евгений\Desktop\Задачи от Перфомас лаб\Project\Project\Task3\tests.json";
        protected string VALUES = @"C:\Users\Евгений\Desktop\Задачи от Перфомас лаб\Project\Project\Task3\values.json";
        protected string REPORT = @"C:\Users\Евгений\Desktop\Задачи от Перфомас лаб\Project\Project\Task3\report.json";
        protected string jsonTests = "";
        protected string jsonValues = "";
        protected Values values;
        protected Tests tests;

        /// <summary>
        /// Основная работа.
        /// </summary>
        public void Work()
        {
            ClearElements();
            if (CheckFiles().Item2 == true)
            {
                CheckFiles();
                ReadFiles();
                EditingInJsonFile();
            }
            else
            {
                Console.WriteLine(CheckFiles().Item1);
            }
        }

        private void ClearElements()
        {
            jsonTests = "";
            jsonValues = "";
            values = null;
            tests = null;
        }

        /// <summary>
        /// Проверка файлов.
        /// </summary>
        /// <returns></returns>
        private (string, bool) CheckFiles()
        {
            string text = "";
            bool contains = true;
            if (!File.Exists(TESTS))
            {
                text = "Нет файла: tests.json\r\n";
                contains = false;
            }
            if (!File.Exists(VALUES))
            {
                contains = false;
                text += "Нет файла: values.json\r\n";
            }
            if (!File.Exists(REPORT))
            {
                FileStream fs = File.Create(REPORT);
                fs.Close();
            }
            return (text, contains);
        }

        protected void ReadFiles()
        {
            jsonTests = File.ReadAllText(TESTS);
            jsonValues = File.ReadAllText(VALUES);
            tests = Newtonsoft.Json.JsonConvert.DeserializeObject<Tests>(jsonTests);
            values = Newtonsoft.Json.JsonConvert.DeserializeObject<Values>(jsonValues);
        }

        protected void EditingInJsonFile()
        {
            foreach (var el in values.values)
            {
                for (int i = 0; i < tests.tests.Length; i++)
                {
                    var t = tests.tests[i];

                    if (t.id == el.id)
                    {
                        t.value = el.value;
                        break;
                    }

                    if (tests.tests[i].values != null)
                    {
                        foreach (var el1 in tests.tests[i].values)
                        {
                            if (el1.id == el.id)
                            {
                                el1.value = el.value;
                                break;
                            }
                        }
                    }
                }
            }
            WriteInJsonFile(JsonConvert.SerializeObject(tests));
        }

        protected void WriteInJsonFile(string _inputJson)
        {
            File.WriteAllText(REPORT, _inputJson);
        }
    }


    public class Values
    {
        public Value[] values { get; set; }
    }

    public class Value
    {
        public int id { get; set; }
        public string value { get; set; }
    }

    public class Tests
    {
        public Test[] tests { get; set; }
    }

    public class Test
    {
        public int id { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public Value[] values { get; set; }
    }

    public class Valuee
    {
        public int id { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public Value1[] values { get; set; }
    }

    public class Value1
    {
        public int id { get; set; }
        public string title { get; set; }
        public Value2[] values { get; set; }
    }

    public class Value2
    {
        public int id { get; set; }
        public string title { get; set; }
        public string value { get; set; }
    }

}
