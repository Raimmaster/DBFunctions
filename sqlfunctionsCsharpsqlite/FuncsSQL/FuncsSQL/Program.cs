using System;
using System.Data.SQLite;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace FuncsSQL
{
    public class Program
    {

        public static void Main(String[] args)
        {
            var conn = new SQLiteConnection("Data Source=C:\\chinook.db");
            //var conn = new SQLiteConnection();
            conn.Open();

            BindFunction(conn, new PmtSQLiteFunction());
            BindFunction(conn, new PingSQLiteFunction());
            BindFunction(conn, new Bin2DecSQLiteFunction());
            BindFunction(conn, new Dec2BinSQLiteFunction());
            BindFunction(conn, new F2CSQLiteFunction());
            BindFunction(conn, new C2FSQLiteFunction());
            BindFunction(conn, new FactorialSQLiteFunction());
            BindFunction(conn, new Dec2HexSQLiteFunction());
            BindFunction(conn, new Hex2DecSQLiteFunction());
            BindFunction(conn, new Hex2DecSQLiteFunction());
            BindFunction(conn, new CompareStringSQLiteFunction());
            BindFunction(conn, new RepeatSQLiteFunction());
            BindFunction(conn, new TrimSQLiteFunction());

            while (true)
            {
                try
                {
                    string sql = Console.ReadLine().ToLower();

                    string[] split = sql.Split(null);

                    if (split.Length == 0)
                        continue;

                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    if (split[0] == "select")
                    {
                        SQLiteDataReader reader = command.ExecuteReader();
                        PrintReader(reader);
                    }
                    else
                        command.ExecuteNonQuery();


                }
                catch (Exception e)
                {

                }
            }
        }

        private static void PrintReader(SQLiteDataReader reader)
        {
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; ++i)
                {
                    var column_name = reader.GetName(i).ToString();
                    Console.Write(column_name + ": " + reader[column_name] + " ");
                }
                Console.WriteLine();
            }


            Console.Read();
        }

        [SQLiteFunction(Name = "PING", Arguments = 1, FuncType = FunctionType.Scalar)]
        public class PingSQLiteFunction : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                return PingHost((string)args[0]); ;
            }
        }


        [SQLiteFunction(Name = "PMT", Arguments = 3, FuncType = FunctionType.Scalar)]
        public class PmtSQLiteFunction : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                double tasa = Double.Parse(args[0].ToString());
                int numPeriodos = Int32.Parse(args[1].ToString());
                double prestamo = Double.Parse(args[2].ToString());
                return (prestamo * tasa) / (1 - Math.Pow((1 + tasa), (-numPeriodos)));
            }
        }


        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
        }

        static void BindFunction(SQLiteConnection connection, SQLiteFunction function)
        {
            var attributes = function.GetType().GetCustomAttributes(typeof(SQLiteFunctionAttribute), true).Cast<SQLiteFunctionAttribute>().ToArray();
            if (attributes.Length == 0)
            {
                throw new InvalidOperationException("SQLiteFunction doesn't have SQLiteFunctionAttribute");
            }
            connection.BindFunction(attributes[0], function);
        }


        [SQLiteFunction(Name = "BIN2DEC", Arguments = 1, FuncType = FunctionType.Scalar)]
        public class Bin2DecSQLiteFunction : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                string binary = args[0].ToString();
                return Convert.ToInt32(binary, 2);
            }
        }

        [SQLiteFunction(Name = "DEC2BIN", Arguments = 1, FuncType = FunctionType.Scalar)]
        public class Dec2BinSQLiteFunction : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                int value = int.Parse(args[0].ToString());
                return Convert.ToString(value, 2);
            }
        }

        [SQLiteFunction(Name = "C2F", Arguments = 1, FuncType = FunctionType.Scalar)]
        public class C2FSQLiteFunction : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                double celsius = Convert.ToDouble(args[0].ToString());
                return ((9.0 / 5.0) * celsius) + 32; ;
            }
        }

        [SQLiteFunction(Name = "F2C", Arguments = 1, FuncType = FunctionType.Scalar)]
        public class F2CSQLiteFunction : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                double fahrenheit = Convert.ToDouble(args[0].ToString());
                return (fahrenheit - 32) * 5 / 9;
            }
        }
        
        [SQLiteFunction(Name = "FACTORIAL", Arguments = 1, FuncType = FunctionType.Scalar)]
        public class FactorialSQLiteFunction : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                int value = int.Parse(args[0].ToString());
                int result = 1;
                for (int i = 1; i <= value; i++)
                    result *= i;
                return result;
            }
        }

        [SQLiteFunction(Name = "DEC2HEX", Arguments = 1, FuncType = FunctionType.Scalar)]
        public class Dec2HexSQLiteFunction : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                int number = Int32.Parse(args[0].ToString());
                return Convert.ToString(number, 16);
            }
        }

        [SQLiteFunction(Name = "HEX2DEC", Arguments = 1, FuncType = FunctionType.Scalar)]
        public class Hex2DecSQLiteFunction : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                string hexa = args[0].ToString();
                return Convert.ToInt32(hexa, 16);
            }
        }

        [SQLiteFunction(Name = "COMPARESTRING", Arguments = 2, FuncType = FunctionType.Scalar)]
        public class CompareStringSQLiteFunction : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                string str1 = args[0].ToString();
                string str2 = args[1].ToString();
                return str1.CompareTo(str2);
            }
        }
        

        [SQLiteFunction(Name = "TRIM", Arguments = 2, FuncType = FunctionType.Scalar)]
        public class TrimSQLiteFunction : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                string str = args[0].ToString();
                char replaceChar = args[1].ToString()[0];
                str = str.TrimStart(replaceChar);
                str = str.TrimEnd(replaceChar);
                return str;
            }
        }


        [SQLiteFunction(Name = "REPEAT", Arguments = 2, FuncType = FunctionType.Scalar)]
        public class RepeatSQLiteFunction : SQLiteFunction
        {
            public override object Invoke(object[] args)
            {
                var sb = new StringBuilder();
                string str = args[0].ToString();
                int cantidad = Int32.Parse(args[1].ToString());
                for (int i = 0; i < cantidad; i++)
                {
                    sb.Append(str);
                }
                return sb.ToString();
            }
        }
    }
}
