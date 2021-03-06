﻿// The following code was generated by Microsoft Visual Studio 2005.
// The test owner should check each test for validity.
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using PropertyPageBase;
using PropertyPageBaseTest.Mocks;
namespace PropertyPageBaseTest
{
    [TestClass()]
    public class PropertyStoreTest
    {


        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod()]
        public void DisposeTest()
        {
            PropertyStore target = new PropertyStore();
            TestIVsBrowseObject dataObject = new TestIVsBrowseObject();
            TestIVsHierarchy hierarchy = new TestIVsHierarchy();
            dataObject.Hierarchy = hierarchy;
            TestDTEProject dteProject = new TestDTEProject();
            hierarchy.dteProject = dteProject;
            TestDTEProperties dteProperties = new TestDTEProperties();
            dteProject.ProjectProperties = dteProperties;

            target.Initialize(dataObject);
            PropertyPageBase_PropertyStoreAccessor accessor = new PropertyPageBase_PropertyStoreAccessor(target);
            Assert.IsNotNull(accessor.m_dteProject);
            Assert.IsNotNull(accessor.m_propertiesToUse);

            target.Dispose();

            Assert.IsNull(accessor.m_dteProject);
            Assert.IsNull(accessor.m_propertiesToUse);
        }

        [TestMethod()]
        public void InitializeTest()
        {
            PropertyStore target = new PropertyStore();

            TestIVsBrowseObject dataObject = new TestIVsBrowseObject();
            TestIVsHierarchy hierarchy = new TestIVsHierarchy();
            dataObject.Hierarchy = hierarchy;
            TestDTEProject dteProject = new TestDTEProject();
            hierarchy.dteProject = dteProject;

            target.Initialize(dataObject);
            PropertyPageBase_PropertyStoreAccessor accessor = new PropertyPageBase_PropertyStoreAccessor(target);
            Assert.AreEqual(dteProject, accessor.m_dteProject);
            Assert.AreEqual(dteProject.ProjectProperties, accessor.m_propertiesToUse);
        }

        [TestMethod()]
        public void PersistTest()
        {
            string propertyName = "Property1";
            string propertyValue = "Value1"; 

            PropertyStore target = new PropertyStore();
            TestIVsBrowseObject dataObject = new TestIVsBrowseObject();
            TestIVsHierarchy hierarchy = new TestIVsHierarchy();
            dataObject.Hierarchy = hierarchy;
            TestDTEProject dteProject = new TestDTEProject();
            hierarchy.dteProject = dteProject;
            TestDTEProperties dteProjectProperties = new TestDTEProperties();
            dteProject.ProjectProperties = dteProjectProperties;
            TestDTEProperty property1 = new TestDTEProperty();
            property1.PropertyValue = "NotSet";
            dteProjectProperties.Properties.Add(propertyName, property1);

            target.Initialize(dataObject);
            target.Persist(propertyName, propertyValue);

            Assert.AreEqual(propertyValue, property1.PropertyValue);
        }

        [TestMethod]
        public void ProperyValueTest()
        {
            string propertyName = "Property1";
            string propertyValue = "Value1"; 

            PropertyStore target = new PropertyStore();
            TestIVsBrowseObject dataObject = new TestIVsBrowseObject();
            TestIVsHierarchy hierarchy = new TestIVsHierarchy();
            dataObject.Hierarchy = hierarchy;
            TestDTEProject dteProject = new TestDTEProject();
            hierarchy.dteProject = dteProject;
            TestDTEProperties dteProjectProperties = new TestDTEProperties();
            dteProject.ProjectProperties = dteProjectProperties;
            TestDTEProperty property1 = new TestDTEProperty();
            property1.PropertyValue = propertyValue;
            dteProjectProperties.Properties.Add(propertyName, property1);

            target.Initialize(dataObject);
            string actualPropertyValue = target.PropertyValue(propertyName);
            Assert.AreEqual(propertyValue, actualPropertyValue);
        }

        [TestMethod]
        public void InitializeWithConfigObjectTest()
        {
            string activeConfigName = "Debug";
            string activePlatformName = "x86";
            string displayName = activeConfigName + "|" + activePlatformName;

            PropertyStore target = new PropertyStore();
            TestIVsCfgBrowseObject dataObject = new TestIVsCfgBrowseObject();
            dataObject.ConfigName = displayName;
            TestIVsHierarchy hierarchy = new TestIVsHierarchy();
            dataObject.Hierarchy = hierarchy;
            TestDTEProject dteProject = new TestDTEProject();
            hierarchy.dteProject = dteProject;
            TestConfigurationManager configManager = new TestConfigurationManager();
            dteProject.ConfigManager = configManager;
            configManager.SupportedPlatform = activePlatformName;
            PropertyPageBaseTest.Mocks.TestConfiguration testConfig = new PropertyPageBaseTest.Mocks.TestConfiguration();
            configManager.SupportedConfigs.Add(activeConfigName, testConfig);
            configManager.ActiveConfig = testConfig;
            testConfig.ConfigPlatformName = activePlatformName;
            TestDTEProperties configProperties = new TestDTEProperties();
            testConfig.ConfigProperties = configProperties;

            target.Initialize(dataObject);
            PropertyPageBase_PropertyStoreAccessor accessor = new PropertyPageBase_PropertyStoreAccessor(target);
            Assert.AreEqual(dteProject, accessor.m_dteProject);
            Assert.AreEqual(configProperties, accessor.m_propertiesToUse);
        }
    }


}
