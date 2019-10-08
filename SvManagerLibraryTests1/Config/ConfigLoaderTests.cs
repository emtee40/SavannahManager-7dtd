﻿using CommonExtensionLib.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SvManagerLibrary.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvManagerLibrary.Config.Tests
{
    [TestClass()]
    public class ConfigLoaderTests
    {
        public ConfigLoader GetConfigLoader()
        {
            var xmlPath = "{0}\\{1}".FormatString(AppDomain.CurrentDomain.BaseDirectory, "TestData\\Test.xml");
            return new ConfigLoader(xmlPath);
        }

        [TestMethod()]
        public void AddValueTest()
        {
            var loader = GetConfigLoader();
            loader.AddValue("test", "test value");

            var info = loader.GetValue("test");
            var exp = new ConfigInfo
            {
                PropertyName = "test",
                Value = "test value"
            };

            Assert.AreEqual(exp, info);
        }

        [TestMethod()]
        public void AddValuesTest()
        {
            var loader = GetConfigLoader();
            var values = new ConfigInfo[]
            {
                new ConfigInfo { PropertyName = "test", Value = "test value" },
                new ConfigInfo { PropertyName = "test2", Value = "test value 2" }
            };
            loader.AddValues(values);

            var dict = loader.GetAll();
            var exp = new Dictionary<string, ConfigInfo>
            {
                { "ServerName", new ConfigInfo() { PropertyName = "ServerName", Value = "My Game Host" } },
                { "ServerName2", new ConfigInfo() { PropertyName = "ServerName2", Value = "My Game Host" } },
                { "ServerDescription", new ConfigInfo() { PropertyName = "ServerDescription", Value = "A 7 Days to Die server" } },
                { "ServerWebsiteURL", new ConfigInfo() { PropertyName = "ServerWebsiteURL", Value = "" } },
                { "test", new ConfigInfo { PropertyName = "test", Value = "test value" } },
                { "test2", new ConfigInfo { PropertyName = "test2", Value = "test value 2" } },
            };

            CollectionAssert.AreEqual(exp, dict);
        }

        [TestMethod()]
        public void ChangeValueTest()
        {
            var loader = GetConfigLoader();
            loader.ChangeValue("ServerName", "test value");

            var info = loader.GetValue("ServerName");
            var exp = new ConfigInfo
            {
                PropertyName = "ServerName",
                Value = "test value"
            };

            Assert.AreEqual(exp, info);
        }

        [TestMethod()]
        public void GetValueTest()
        {
            var loader = GetConfigLoader();
            var info = loader.GetValue("ServerName");
            var exp = new ConfigInfo
            {
                PropertyName = "ServerName",
                Value = "My Game Host"
            };

            Assert.AreEqual(exp, info);
        }

        [TestMethod()]
        public void ClearTest()
        {
            var loader = GetConfigLoader();
            loader.Clear();

            CollectionAssert.AreEqual(new Dictionary<string, ConfigInfo>(), loader.GetAll());
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var loader = GetConfigLoader();
            var dict = loader.GetAll();
            var exp = new Dictionary<string, ConfigInfo>
            {
                { "ServerName", new ConfigInfo() { PropertyName = "ServerName", Value = "My Game Host" } },
                { "ServerName2", new ConfigInfo() { PropertyName = "ServerName2", Value = "My Game Host" } },
                { "ServerDescription", new ConfigInfo() { PropertyName = "ServerDescription", Value = "A 7 Days to Die server" } },
                { "ServerWebsiteURL", new ConfigInfo() { PropertyName = "ServerWebsiteURL", Value = "" } }
            };

            CollectionAssert.AreEqual(exp, dict);
        }

        [TestMethod()]
        public void WriteTest()
        {
            var xmlPath = "{0}\\{1}".FormatString(AppDomain.CurrentDomain.BaseDirectory, "TestData\\Config.xml");
            var exp = File.ReadAllText(xmlPath);

            var loader = GetConfigLoader();
            using (var stream = new MemoryStream())
            {
                loader.Write(stream);
                stream.Seek(0, SeekOrigin.Begin);

                var buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                var act = Encoding.UTF8.GetString(buffer) + "\r\n";

                Assert.AreEqual(exp, act);
            }
        }
    }
}