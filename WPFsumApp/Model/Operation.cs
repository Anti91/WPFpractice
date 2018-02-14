using System;

namespace WPFsumApp
{
    public class Operation
    {
        private int id;
        private int firstnumber;
        private string op;
        private int secondnumber;
        private int result;
        private string timestamp;

        public Operation()
        {
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Firstnumber
        {
            get { return firstnumber; }
            set { firstnumber = value; }
        }

        public string Op
        {
            get { return op; }
            set { op = value; }
        }

        public int Secondnumber
        {
            get { return secondnumber; }
            set { secondnumber = value; }
        }

        public int Result
        {
            get { return result; }
            set { result = value; }
        }

        public string Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
    }
}
