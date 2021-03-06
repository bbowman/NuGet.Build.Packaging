﻿// The following code was generated by Microsoft Visual Studio 2005.
// The test owner should check each test for validity.
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using PropertyPageBaseTest.Mocks;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio;
namespace PropertyPageBaseTest
{
    [TestClass()]
    public class PageViewTest
    {
        [TestMethod()]
        public void ConstructorTest()
        {
            TestIPageViewSite testPageViewSite = new TestIPageViewSite();

            TestPageView target = new TestPageView(testPageViewSite);
            Assert.IsNotNull(target);
        }

        [TestMethod()]
        public void DesignerContstructorTest()
        {
            TestPageView target = new TestPageView();
            Assert.IsNotNull(target);
            PropertyPageBase_PageViewAccessor accessor = new PropertyPageBase_PageViewAccessor(target);
            Assert.IsNull(accessor.m_propertyControlMap);
        }

        [TestMethod]
        public void m_propertyControlMapTest()
        {
            TestIPageViewSite testPageViewSite = new TestIPageViewSite();

            TestPageView target = new TestPageView(testPageViewSite);
            PropertyPageBase_PageViewAccessor accessor = new PropertyPageBase_PageViewAccessor(target);
            Assert.IsNotNull(accessor.m_propertyControlMap);
        }

        [TestMethod]
        public void PropertyControlTableTest()
        {
            TestIPageViewSite testPageViewSite = new TestIPageViewSite();

            TestPageView pageView = new TestPageView(testPageViewSite);
            PropertyPageBase_PageViewAccessor pageViewAccessor = new PropertyPageBase_PageViewAccessor(pageView);
            PropertyPageBase_PropertyControlMapAccessor mapAccessor = new PropertyPageBase_PropertyControlMapAccessor(pageViewAccessor.m_propertyControlMap);
            Assert.AreEqual(pageView.Table, mapAccessor.m_propertyControlTable);
        }

        [TestMethod]
        public void InitializeTest()
        {
            TestIPageViewSite testPageViewSite = new TestIPageViewSite();

            string value1 = "Value1";
            string value2 = "True";
            string value3 = "NotSet";

            testPageViewSite.PropertyNameValueDictionary.Add("Property1", value1);
            testPageViewSite.PropertyNameValueDictionary.Add("Property2", value2);
            testPageViewSite.PropertyNameValueDictionary.Add("Property3", value3);

            TestPageView pageView = new TestPageView(testPageViewSite);
            TestHostingForm hostingForm = new TestHostingForm();
            using (hostingForm)
            {
                pageView.Initialize(hostingForm, hostingForm.ClientRectangle);

                Assert.IsTrue(hostingForm.Controls.Contains(pageView));
                Assert.AreEqual(hostingForm.ClientRectangle, pageView.DisplayRectangle);

                Assert.AreEqual(value1, pageView.GetControlValue("Control1"));
                Assert.AreEqual(value2, pageView.GetControlValue("Control2"));
            }
        }

        [TestMethod]
        public void GetSetControlValueTest()
        {
            TestIPageViewSite testPageView = new TestIPageViewSite();

            TestPageView pageView = new TestPageView(testPageView);

            string value1 = "Value1";
            string value2 = "True";

            pageView.SetControlValue("Control1", value1);
            pageView.SetControlValue("Control2", value2);

            Assert.AreEqual(value1, pageView.GetControlValue("Control1"));
            Assert.AreEqual(value2, pageView.GetControlValue("Control2"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetBadControlValueTest()
        {
            TestIPageViewSite testPageViewSite = new TestIPageViewSite();
            TestPageView pageView = new TestPageView(testPageViewSite);

            pageView.GetControlValue("label1");
        }

        [TestMethod]
        public void MoveViewTest()
        {
            TestIPageViewSite testPageViewSite = new TestIPageViewSite();

            string value1 = "Value1";
            string value2 = "True";
            string value3 = "NotSet";

            testPageViewSite.PropertyNameValueDictionary.Add("Property1", value1);
            testPageViewSite.PropertyNameValueDictionary.Add("Property2", value2);
            testPageViewSite.PropertyNameValueDictionary.Add("Property3", value3);
            TestPageView pageView = new TestPageView(testPageViewSite);

            TestHostingForm hostingForm = new TestHostingForm();
            using (hostingForm)
            {
                pageView.Initialize(hostingForm, hostingForm.ClientRectangle);
                Rectangle newRectangle = hostingForm.ClientRectangle;
                newRectangle.Width = newRectangle.Width - 1;
                newRectangle.Height = newRectangle.Height - 1;
                pageView.MoveView(newRectangle);
                Assert.AreEqual(newRectangle, pageView.DisplayRectangle);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ViewDoesNotOverridePropertyControlTable()
        {
            TestIPageViewSite pageViewSite = new TestIPageViewSite();
            MockPageView pageView = new MockPageView(pageViewSite);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DisposeTest()
        {
            TestIPageViewSite testPageViewSite = new TestIPageViewSite();

            string value1 = "Value1";
            string value2 = "True";
            string value3 = "NotSet";

            testPageViewSite.PropertyNameValueDictionary.Add("Property1", value1);
            testPageViewSite.PropertyNameValueDictionary.Add("Property2", value2);
            testPageViewSite.PropertyNameValueDictionary.Add("Property3", value3);

            TestPageView pageView = new TestPageView(testPageViewSite);
            TestHostingForm hostingForm = new TestHostingForm();
            using (hostingForm)
            {
                pageView.Initialize(hostingForm, hostingForm.ClientRectangle);
                pageView.Dispose();
                pageView.GetControlValue("Control1");
            }
        }

        [TestMethod]
        public void ShowViewHideViewTest()
        {
            TestIPageViewSite testPageViewSite = new TestIPageViewSite();

            TestPageView pageView = new TestPageView(testPageViewSite);
            pageView.ShowView();
            Assert.IsTrue(pageView.Visible, "Page's Visible property is false");
            pageView.HideView();
            Assert.IsFalse(pageView.Visible, "Page's Visisble property is true");
        }

        [TestMethod]
        public void ProcessAcceleratorTest()
        {
            TestIPageViewSite testPageViewSite = new TestIPageViewSite();

            TestPageView pageView = new TestPageView(testPageViewSite);

            TestControl testControl = new TestControl();
            testControl.MessagesIRecognize.Add(int.MaxValue - 1);
            pageView.Controls.Add(testControl);
            testControl.CreateControl();

            Message recognizedMessage = new Message();
            recognizedMessage.Msg = int.MaxValue - 1;
            recognizedMessage.LParam = new IntPtr(1);
            recognizedMessage.WParam = new IntPtr(2);
            recognizedMessage.HWnd = testControl.Handle;

            Message unrecognizedMessage = new Message();
            unrecognizedMessage.Msg = int.MaxValue;
            unrecognizedMessage.LParam = new IntPtr(1);
            unrecognizedMessage.WParam = new IntPtr(2);
            unrecognizedMessage.HWnd = testControl.Handle;


            int hr = pageView.ProcessAccelerator(ref recognizedMessage);
            Assert.AreEqual(VSConstants.S_OK, hr);
            Assert.IsTrue(testControl.MessagesAskedToProcess.Contains(recognizedMessage));

            hr = pageView.ProcessAccelerator(ref unrecognizedMessage);
            Assert.AreEqual(VSConstants.S_FALSE, hr);
            Assert.IsFalse(testControl.MessagesAskedToProcess.Contains(unrecognizedMessage));
        }

        [TestMethod]
        public void UserEditCompleteTest()
        {
            TestIPageViewSite testPageViewSite = new TestIPageViewSite();

            string value1 = "Value1";
            string value2 = "True";
            string value3 = "NotSet";

            testPageViewSite.PropertyNameValueDictionary.Add("Property1", value1);
            testPageViewSite.PropertyNameValueDictionary.Add("Property2", value2);
            testPageViewSite.PropertyNameValueDictionary.Add("Property3", value3);

            TestPageView pageView = new TestPageView(testPageViewSite);
            TestHostingForm hostingForm = new TestHostingForm();
            using (hostingForm)
            {
                pageView.Initialize(hostingForm, hostingForm.DisplayRectangle);
                string expectedControlName = "Control3";
                string expectedValue = "ValueSet";

                string actualControlName = null;
                string actualValue = null;

                pageView.UserEditComplete += delegate(string controlName, string value) { actualControlName = controlName; actualValue = value; };
                TestTextBox testTextBox = pageView.Controls["Control3"] as TestTextBox;
                testTextBox.Text = expectedValue;
                testTextBox.ValidateNow();
                Assert.AreEqual(expectedControlName, actualControlName);
                Assert.AreEqual(expectedValue, actualValue);

                expectedControlName = "Control2";
                expectedValue = "False";

                CheckBox testCheckBox = pageView.Controls["Control2"] as CheckBox;
                testCheckBox.Checked = false;
                Assert.AreEqual(expectedControlName, actualControlName);
                Assert.AreEqual(expectedValue, actualValue);
            }
        }

        [TestMethod]
        public void ViewSizeTest()
        {
            TestPageView pageView = new TestPageView();

            Assert.AreEqual(pageView.Size, pageView.ViewSize);
        }

        [TestMethod]
        public void RefreshPropertyValuesTest()
        {
            TestIPageViewSite testPageViewSite = new TestIPageViewSite();

            string value1 = "Value1";
            string value2 = "True";
            string value3 = "NotSet";

            string value1Changed = "Value1Changed";
            string value2Changed = "False";
            string value3Changed = "Set";

            testPageViewSite.PropertyNameValueDictionary.Add("Property1", value1);
            testPageViewSite.PropertyNameValueDictionary.Add("Property2", value2);
            testPageViewSite.PropertyNameValueDictionary.Add("Property3", value3);

            TestPageView pageView = new TestPageView(testPageViewSite);
            TestHostingForm hostingForm = new TestHostingForm();
            using (hostingForm)
            {
                pageView.Initialize(hostingForm, hostingForm.ClientRectangle);

                Assert.IsTrue(hostingForm.Controls.Contains(pageView));
                Assert.AreEqual(hostingForm.ClientRectangle, pageView.DisplayRectangle);

                Assert.AreEqual(value1, pageView.GetControlValue("Control1"));
                Assert.AreEqual(value2, pageView.GetControlValue("Control2"));

                testPageViewSite.PropertyNameValueDictionary["Property1"] = value1Changed;
                testPageViewSite.PropertyNameValueDictionary["Property2"] = value2Changed;
                testPageViewSite.PropertyNameValueDictionary["Property3"] = value3Changed;

                pageView.RefreshPropertyValues();

                Assert.AreEqual(value1Changed, pageView.GetControlValue("Control1"));
                Assert.AreEqual(value2Changed, pageView.GetControlValue("Control2"));
            }
        }

    }


}
