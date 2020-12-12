using MCZ_Maestro_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCZ_Maestro_API.Interfaces
{
    public interface IMaestroService
    {
        /// <summary>
        /// Write Data to the Device
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="value">Value</param>
        void WriteData(int id, int value);

        /// <summary>
        /// All Commands from the Device
        /// </summary>
        IEnumerable<MaestroCommand> AllCommands { get; }

        /// <summary>
        /// Find Maestro Command
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MaestroCommand Find(int id);
    }
}
