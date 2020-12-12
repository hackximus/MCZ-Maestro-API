using MCZ_Maestro_API.Interfaces;
using MCZ_Maestro_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace MCZ_Maestro_API.Services
{
    public class MaestroService : IMaestroService
    {
        private readonly List<MaestroCommand> _maestroCommands;
        private MaestroCommand _maestrocommand;
        private string _webaddress = "ws://192.168.120.1:81/";
        
        /// <summary>
        /// Add all commands to the service
        /// </summary>
        public MaestroService()
        {
            this._maestroCommands = new List<MaestroCommand>();
            this._maestroCommands.Add(new MaestroCommand(42, "Temperature_Setpoint"));
            this._maestroCommands.Add(new MaestroCommand(51, "Boiler_Setpoint"));
            this._maestroCommands.Add(new MaestroCommand(1111, "Chronostat"));
            this._maestroCommands.Add(new MaestroCommand(1108, "Chronostat_T1"));
            this._maestroCommands.Add(new MaestroCommand(1109, "Chronostat_T2"));
            this._maestroCommands.Add(new MaestroCommand(1101, "Chronostat_T3"));
            this._maestroCommands.Add(new MaestroCommand(36, "Power_Level"));
            this._maestroCommands.Add(new MaestroCommand(45, "Silent_Mode"));
            this._maestroCommands.Add(new MaestroCommand(35, "Active_Mode"));
            this._maestroCommands.Add(new MaestroCommand(41, "Eco_Mode"));
            this._maestroCommands.Add(new MaestroCommand(50, "Sound_Effects"));
            this._maestroCommands.Add(new MaestroCommand(34, "Power"));
            this._maestroCommands.Add(new MaestroCommand(37, "Fan_State"));
            this._maestroCommands.Add(new MaestroCommand(40, "Control_Mode"));
        }

        /// <summary>
        /// Return all Commands
        /// </summary>
        public IEnumerable<MaestroCommand> AllCommands
        {
            get { return _maestroCommands; }
        }

        /// <summary>
        /// Find command over the ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public MaestroCommand Find (int id)
        {
            return _maestroCommands.FirstOrDefault(item => item.Id == id);
        }

        /// <summary>
        /// Write data to the device
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="value">Value</param>
        public void WriteData(int id, int value)
        {
            _maestrocommand = _maestroCommands.FirstOrDefault(item => item.Id == id);
            CheckId(_maestrocommand, value);

            using (var ws = new WebSocket(_webaddress))
            {
                ws.Connect();
                System.Threading.Thread.Sleep(1000);

                if (ws.ReadyState.ToString() == "Open")
                {
                    ws.Send(_maestrocommand.ToString()); 
                }
 
            }

        }

        /// <summary>
        /// Check the ID of the maestro command and than return the right value back to the object
        /// </summary>
        /// <param name="maestroCommand"></param>
        /// <returns></returns>
        private MaestroCommand CheckId(MaestroCommand maestroCommand, int value)
        {
            switch (maestroCommand.Id)
            {
                case 42:
                case 51: 
                case 1108:
                case 1109:
                case 1101:
                    maestroCommand.Value = value * 2;
                    break;

                case 1111:
                case 45:
                case 35:
                case 41:
                case 50:
                case 40:
                    if (value == 0)
                    {
                        maestroCommand.Value = 1;
                    }
                    else if (value > 1)
                    {
                        maestroCommand.Value = 1;
                    }
                    else
                    {
                        maestroCommand.Value = 0;
                    }
                    break;

                case 34:
                    if (value == 0 || value > 1)
                    {
                        maestroCommand.Value = 40;
                    }
                    else
                    {
                        maestroCommand.Value = value;
                    }
                    break;

                case 37:
                case 36:
                    if (value >= 6)
                    {
                        maestroCommand.Value = 6;
                    }
                    else
                    {
                        maestroCommand.Value = value;
                    }
                    break;

                default:
                    break;
            }

            return maestroCommand;
        }
    }
}
