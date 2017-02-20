using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionGoo.Standard.Extensions;
using NSpeedTest.Models;

namespace NSpeedTest.Client
{
    public class SpeedTestResult
    {
        public double UploadSpeed { get; set; }
        public double DownloadSpeed { get; set; }
        public string ServerInfo { get; set; }
        public string TestName { get; set; }
    }

    public static class Uploader
    {
        public static async Task<bool> Upload(double upload, double download, Server server)
        {
            var us = new SpeedTestResult
            {
                DownloadSpeed = download,
                UploadSpeed = upload,
                ServerInfo = server.Serialise(),
                TestName = "MSFT"
            };

            var url =
                "https://functionplayground.azurewebsites.net/api/InternetUpSpeedTest?code=a7jinsvJmWdcILhjo5F05jJxekdrz6qhpOgQlTGn0Rt3a0a2qHn9/w==";

            await url.Post(us.Serialise());

            return true;
        }
    }
}
