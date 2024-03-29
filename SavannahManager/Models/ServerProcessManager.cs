﻿using CommonExtensionLib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7dtd_svmanager_fix_mvvm.Models
{
    public class ServerProcessManager : IDisposable
    {

        private const string CopiedConfigFileName = "serverconfig.savannah.xml";

        private Process p = new Process();

        public int ProcessId { get; private set; }

        public ServerProcessManager(string exeFilePath, string configFilePath)
        {
            var exeDirPath = Path.GetDirectoryName(exeFilePath);
            File.Copy(configFilePath, "{0}/{1}".FormatString(exeDirPath, CopiedConfigFileName), true);

            p.StartInfo = new ProcessStartInfo() {
                FileName = exeFilePath,
                Arguments = string.Format("-logfile 7DaysToDieServer_Data\\output_log.txt -quit -batchmode -nographics -configfile={0} -dedicated", CopiedConfigFileName),
                UseShellExecute = false,
                CreateNoWindow = false,
                RedirectStandardInput = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = Path.GetDirectoryName(exeFilePath) ?? throw new InvalidOperationException()
            };
            p.StartInfo.EnvironmentVariables["SteamAppId"] = "251570";
            p.StartInfo.EnvironmentVariables["SteamGameId"] = "251570";
        }

        public bool ProcessStart(Action<string> failedAction = null)
        {
            try
            {
                p.Start();

                ProcessId = p.Id;
            }
            catch (Win32Exception ex)
            {
                failedAction?.Invoke(ex.Message);
                return false;
            }
            return true;
        }

        public void ProcessKill()
        {
            p.Kill();
        }

        public void Dispose()
        {
            p?.Dispose();
        }
    }
}
