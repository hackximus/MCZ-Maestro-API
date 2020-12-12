using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCZ_Maestro_API.Models
{
    public class MaestroCommand
    {
        private int _id;
        private string _command;
        private int _value;
        private string _info;

        public MaestroCommand()
        {

        }

        /// <summary>
        /// Maestero Command
        /// </summary>
        /// <param name="id">ID of the Command</param>
        /// <param name="command">Command</param>
        public MaestroCommand(int id, string command)
        {
            this._id = id;
            this._command = command;
            this.Info = string.Empty;
        }

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get => _id; set => _id = value; }
        /// <summary>
        /// Command
        /// </summary>
        public string Command { get => _command; set => _command = value; }

        /// <summary>
        /// Value
        /// </summary>
        public int Value { get => _value; set => _value = value; }

        /// <summary>
        /// Info
        /// </summary>
        public string Info { get => _info; set => _info = value; }

        /// <summary>
        /// To String Method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("C|WriteParametri|{0}|{1}", Id, Value);
        }
    }
}
